
// More robust version, see https://github.com/poilu/raphael-boolean/issues/3
// and https://github.com/DmitryBaranovskiy/raphael/issues/1130
Raphael.isPointInsidePath = function (path, x, y) {
    var bbox = Raphael.pathBBox(path);
    return Raphael.isPointInsideBBox(bbox, x, y) &&
        Raphael.pathIntersectionNumber(path, [["M", x, y], ["l", bbox.width + 10, Math.random()]]) % 2 == 1;
};

// Convert a Raphael path to a string
var pathToString = function(array) {
    return array.join(',').replace(/,?([achlmqrstvxz]),?/gi, '$1');
};

// List obtained by picking from the output of this script:
//   for x in ../Emoji.Wpf/CountryFlags/svg/*svg; do sed 's/<[^g][^>]*>//g' $x | tr ' "' '\n' \
//    | grep = | sort | uniq; done | sort | uniq -c | sort -n
var important_attrs = ['stroke-linejoin', 'stroke-linecap', 'clip-path', 'stroke-width', 'stroke', 'fill', 'style'];

// Close three-point paths (used by clipping and merging)
function closePath(d) {
    let start = d.replace(/M *([^,C ]*, *[^,C ]*).*/, '$1');
    let end = d.replace(/.*C.*,([^C, ]*, *[^C, ]*)/, '$1');
    if (start != end)
        d += 'Z';
    return d;
}

function compressPath(d) {
    return d.replace(/((?![0-9.]) +| +(?![0-9.]))/, '');
}

function formatXml(xml) {
    var ret = '', indent = '';
    var tab = '  ';
    xml.split(/>\s*</).forEach(function(node) {
        if (node.match( /^\/\w/ )) indent = indent.substring(tab.length); // decrease indent by one 'tab'
        ret += indent + '<' + node.replace(/(?<=d="[^"]*)([0-9])(C)/g, '$1 $2') + '>\r\n';
        if (node.match( /^<?\w([^>/]*|[^>]*[^/])$/ )) indent += tab; // increase indent
    });
    ret = ret.replace( /(<[^\/>][^>]*[^\/>]>)\s*(<\/)/g, '$1$2');
    return ret.substring(1, ret.length - 3);
}

function svgToXaml(svg, unicode_id) {
    let g = svg.findOne('g');
    let ret = `<DrawingGroup x:Key="${unicode_id}">\n`;
    for (let p of g.children()) {
        ret += `    <GeometryDrawing`;
        if (p.attr()['fill'] && p.attr('fill') != 'none')
            ret += ` Brush="${p.attr('fill')}"`;
        ret += ` Geometry="`;
        if (!p.attr()['fill-rule'] || p.attr('fill-rule') != 'evenodd')
            ret += 'F1';
        ret += `${compressPath(p.attr('d'))}"`;
        if (p.attr()['stroke']) {
            ret += '>\n';
            ret += '        <GeometryDrawing.Pen>\n';
            ret += '            <Pen';
            if (p.attr()['stroke'])
                ret += ` Brush="${p.attr('stroke')}"`;
            if (p.attr()['stroke-width'])
                ret += ` Thickness="${p.attr('stroke-width')}"`;
            if (p.attr()['stroke-linecap'])
                ret += ` StartLineCap="Round" EndLineCap="Round"`;
            if (p.attr()['stroke-linejoin'])
                ret += ` LineJoin="Round"`;
            if (p.attr()['stroke-miterlimit'])
                ret += ` MiterLimit="${p.attr('stroke-miterlimit')}"`;
            ret += '/>\n';
            ret += '        </GeometryDrawing.Pen>\n';
            ret += '    </GeometryDrawing>\n';
        } else {
            ret += '/>\n';
        }
    }
    ret += '</DrawingGroup>\n';
    return ret;
}

// Load SVG as text
function loadSvg(text) {
    let canvas_holder = document.createElement('svg');
    let canvas = SVG(canvas_holder);
    canvas.svg(text.replace(/>\s*</g, '><'));
    let ret = canvas.children()[0];
    ret._canvas_holder = canvas_holder;
    return ret;
}

// Unload SVG
function unloadSvg(svg) {
    svg._canvas_holder.remove();
}

function correctUngroup(g) {
    for (let e of g.children())
        g.before(e);
    g.remove();
}

// Return true if the two elements are paths with the same attributes
function sameAttributes(p1, p2) {
    if (p1.type != 'path' || p2.type != 'path')
         return false;
    for (let name of important_attrs) {
        if (p1.attr(name) != p2.attr(name))
            return false;
    }
    return true;
}

function simplifyPaths(svg, precision) {
    const match_num = /([0-9]+[.]?[0-9]*|[.][0-9]+)(e[-+]?[0-9]+)?/g;
    const apply = function(e) {
        if (e.type == 'path') {
            for (let a of ['d', 'stroke-width']) {
                if (e.attr()[a]) {
                    let s = e.attr(a).toString();
                    s = s.replace(match_num, function(match, capture) {
                        return Number.parseFloat(match).toFixed(precision) * 1.0;
                    });
                    e.attr(a, s);
                }
            }
        } else {
            for (let c of e.children())
                apply(c);
        }
    }
    apply(svg);
}

// Replace all <use> tags with their targets.
function substituteClones(svg) {
    let ids = {};
    let uses = [];
    let apply = function(e) {
        if (e.type == 'use') {
            // Keep for later (see gd.svg for a <use> node that appears before the id)
            uses.push(e);
        } else if (e.node.id && e.type != 'svg' && e.type != 'clipPath') {
            ids[e.node.id] = e;
            e.attr('id', null);
        }
        for (let e2 of e.children())
            apply(e2, ids);

        while (uses.length) {
            let u = uses.pop();
            let tid = u.attr('xlink:href').replace('#','');
            if (!(tid in ids)) {
                uses.push(u);
                break;
            }
            let clone = ids[tid].clone();
            clone.attr('id', null);
            let g = u.root().group();
            g.add(clone);
            let x = 0, y = 0, transform = null;
            for (let attr in u.attr()) {
                let val = u.attr(attr);
                // See kr.svg: <use ... y="44"/>
                if (attr == 'x')
                    x = val;
                else if (attr == 'y')
                    y = val;
                // Best demonstrated in cw.svg
                else if (attr == 'transform')
                    transform = u.transform();
                else if (attr != 'xlink:href')
                    g.attr(attr, val);
            }
            if (x != 0 || y != 0)
                g.transform({translateX: x, translateY: y})
            if (transform !== null)
                g.transform(transform, true);
            u.replace(g);
            if (u.node.id) {
                // See sb.svg for a <use> node that itself has an id attr
                g.node.id = u.node.id;
                ids[g.node.id] = g;
            }
            // If the resulting group has no attributes, collapse it immediately
            if (g.node.attributes.length == 0) {
                g.replace(clone);
                if (g.node.id) {
                    clone.node.id = g.node.id;
                    ids[clone.node.id] = clone;
                }
            }
        }
    }
    apply(svg);
}

// Work around some weird issues with flatten.js.
// Can be seen in mv.svg and ch.svg; also je.svg
function replaceShapes(svg) {
    let apply = function(e) {
        if (e.type == 'rect') {
            let p = e.root().path();
            let x = e.x(), y = e.y(), w = e.width(), h = e.height();
            let d = `M${x},${y} h${w} v${h} h-${w} v-${h}`;
            // Hack: if there is no fill, make sure the shape has nice corners
            // by adding an extra segment. Fixes: lk.svg (very subtle), mv.svg
            let e_fill = e.fill();
            let e_stroke = e.attr()['stroke'] || 'none';
            if (e_fill == 'none' || e_fill == e_stroke)
                d += `h${w}`; // extra round
            p.attr('d', d);
            for (let a in e.attr())
                p.attr(a, e.attr(a));
            e.replace(p);
        } else if (e.type == 'polygon') {
            let p = e.root().path();
            let points = e.attr('points').split(/\s+/);
            let d = '';
            let oldx = 0, oldy = 0;
            for (let i = 0; i < points.length; i += 2) {
                let x = points[i], y = points[i+1];
                if (d == '')
                    d += `M${x},${y} `;
                else
                    d += `C${oldx},${oldy},${x},${y},${x},${y} `;
                oldx = x;
                oldy = y;
            }
            // Close path with a curve
            if (e.fill() != 'none' && oldx != points[0] || oldy != points[1])
                d += `Z`;
            if (e.fill() == 'none' || e.fill() == e.stroke())
                d += `L${points[2]},${points[3]} Z`; // extra round
            p.attr('d', d);
            for (let a in e.attr())
                p.attr(a, e.attr(a));
            e.replace(p);
        }

        for (let e2 of e.children())
            apply(e2);
    }
    apply(svg);
}

function removeGrid(svg) {
    let viewbox = null;
    let apply = function(e) {
        if (e.node.id == 'grid') {
            e.remove();
            return;
        } else if (e.node.id == 'line') {
            if (e.x() && e.width()) {
                //e.root().attr('viewBox', `${e.x()} ${e.y()} ${e.width()} ${e.height()}`);
            }
        }

        for (let e2 of e.children())
            apply(e2);
    }
    apply(svg);
}

function collapseGroups(svg) {
    let apply = function(e, la) {
        if (e.type == 'g') {
            la = { ...la };
            for (let [a, val] of Object.entries(e.attr())) {
                if (a != 'id') {
                    la[a] = val;
                    e.attr(a, null);
                }
            }
        } else if (e.type == 'path') {
            for (const [a, val] of Object.entries(la)) {
                if (!e.attr()[a])
                    e.attr(a, val);
            }
        }
        for (let e2 of e.children())
            apply(e2, la);
        if (e.type == 'g' && e.node.attributes.length == 0) {
            //e.ungroup();
            correctUngroup(e);
        }
    }
    apply(svg, {});
}

function concatenatePaths(svg) {
    let raph_tmp = document.createElement('div');
    raph_tmp.id = 'raphael_canvas';
    document.body.appendChild(raph_tmp);
    let paper = Raphael('raphael_canvas', 250, 250);

    let dir1 = null;
    let apply = function(e) {
        for (let ch of e.children()) {
            apply(ch);
        }
        // Do not concatenate paths if they have different winding
        let d2 = e.attr('d');
        let path2 = paper.path(d2);
        let dir2 = null;
        try {
            dir2 = paper.getPathDir(path2);
        } catch {
        }
        if (dir1 == dir2 && e.parent() && e.prev() && sameAttributes(e.prev(), e)) {
            let d1 = e.prev().attr('d');
            e.attr('d', d1 + d2);
            e.prev().remove();
        }
        path2.remove();
        dir1 = dir2;
    }

    apply(svg);
    raph_tmp.remove();
}

function mergePaths(svg) {
    let raph_tmp = document.createElement('div');
    raph_tmp.id = 'raphael_canvas';
    document.body.appendChild(raph_tmp);
    let paper = Raphael('raphael_canvas', 250, 250);

    let early_exit = false;
    let apply = function(e) {
        for (let ch of e.children()) {
            apply(ch);
            if (early_exit)
                return;
        }
        if (e.parent() && e.prev() && sameAttributes(e.prev(), e)) {
            let d1 = closePath(e.prev().attr('d'));
            let d2 = closePath(e.attr('d'));
            let path1 = paper.path(d1);
            let path2 = paper.path(d2);

            let merged = paper.union(path1, path2);
            if (merged) {
                e.attr('d', merged);
                //e.attr('stroke-width', Raphael.pathBBox(merged).width / 50);
                //e.attr('stroke', '#000');
                e.prev().remove();
                early_exit = true;
            }
            path1.remove();
            path2.remove();
        }
    }

    apply(svg);
    raph_tmp.remove();
}

function clipPaths(svg) {
    let raph_tmp = document.createElement('div');
    raph_tmp.id = 'raphael_canvas';
    document.body.appendChild(raph_tmp);
    let paper = Raphael('raphael_canvas', 250, 250);

    let cids = {}
    let apply = function(e, clips=[]) {
        // Remember clip paths
        if (e.type == 'clipPath') {
            // FIXME: what if there are several paths?
            cids[e.node.id] = e.children()[0].attr('d');
            e.remove();
        }
        if (e.attr('clip-path')) {
            let cid = e.attr('clip-path').replace(/url\(#(.*)\)/,'$1');
            if (cid in cids) {
                clips = clips.concat([cids[cid]]);
            }
        }
        for (let ch of e.children()) {
            apply(ch, clips);
        }
        if (e.type == 'path' && clips.length) {
            let d1 = closePath(e.attr('d'));
            let path1 = paper.path(d1);
            for (let c of clips) {
                let d2 = closePath(c);
                let path2 = paper.path(d2);
                let merged = paper.intersection(path1, path2);
                e.attr('d', merged);
                path2.remove();
            }
            path1.remove();
        }
        e.attr('clip-path', null);
    }

    apply(svg);
    raph_tmp.remove();
}

function lerp(a, b, t) {
    return a + t * (b - a);
}

// Validate with as.svg
function warp(x, y, is_square) {
    x -= is_square ? 18 : 6;
    let dx = x / (is_square ? 36 : 60);
    let dy = y / 60;
    let x2 = 50 + 241 * x / (is_square ? 52 : 60);
    let y2 = 264 * y / 60 - 30;
    //let x2 = lerp(1.0 - Math.pow(1 - dx, 1.1), Math.pow(dx, 1.1), dy);
    //return [x2 * 60 + 4, y - 4 * Math.sin(x2 * 6.28319)];
    return [x2, y2 + 11 * Math.sin(dx * 6.28319)];
}

function waveEffect(svg, is_square) {
    let raph_tmp = document.createElement('div');
    raph_tmp.id = 'raphael_canvas';
    document.body.appendChild(raph_tmp);
    let paper = Raphael('raphael_canvas', 250, 250);

    let cids = {}
    let scale = 1.0;
    let apply = function(e, clips=[]) {
        if (e.type == 'svg') {
            scale = 320 / e.viewbox().w;
            e.attr('viewBox', '0 0 320 320');
        }
        for (let ch of e.children()) {
            apply(ch, clips);
        }
        if (e.type == 'path') {
            let path = paper.path(e.attr('d'));
            let segments = path.attr('path');
            let new_segments = [];
            let prev_point = null;
            for (let s of segments)  {
                if (s[0] == 'M') {
                    prev_point = [s[1], s[2]];
                    new_segments.push(['M', ...warp(s[1], s[2], is_square)]);
                } else {
                    let warped_points = [];
                    for (let i = 0; i <= 50; ++i) {
                        let p = Raphael.findDotsAtSegment(prev_point[0], prev_point[1], s[1], s[2], s[3], s[4], s[5], s[6], i / 50);
                        warped_points.push(warp(p.x, p.y, is_square));
                    }
                    prev_point = [s[5], s[6]];
                    warped_data = fitCurve(warped_points, 1);
                    for (let w of warped_data) {
                        new_segments.push(['C', w[1][0], w[1][1],
                                                w[2][0], w[2][1],
                                                w[3][0], w[3][1]]);
                    }
                }
            }
            let d2 = pathToString(new_segments);
            e.attr('d', d2);
            if (e.node.attributes['stroke']) {
                e.attr('stroke-width', (e.attr('stroke-width') || 1.0) * scale);
            }
            path.remove();
        }
    }
    apply(svg);
    raph_tmp.remove();
}

function addFlag(svg, is_square) {
    let viewbox = null;
    let apply = function(e) {
        if (e.type == 'svg') {
            e.attr('viewBox', '0 0 320 320');
        }

        for (let e2 of e.children())
            apply(e2);

        if (e.type == 'path') {
            if ((e.attr()['fill'] && (e.fill() == '#000' || e.fill() == '#000000'))
                 || (!e.attr()['fill']))
                e.fill('#383838');
            if (e.attr()['stroke'] && (e.stroke() == '#000' || e.stroke() == '#000000'))
                e.stroke('#383838');
        } else if (e.node.id == 'line') {
            e.node.id = 'flag';
            // Debug
            //e.children()[0].stroke('#f00');
//            if (e.children().length)
//                e.children()[0].remove();
            var p2 = e.root().path();
            if (is_square)
                p2.attr('d', 'm 45.119,0 c -4.83,0 -9.388,0.92 -13.658,2.7 -4.27,1.86 -7.990,4.3 -11.150,7.5 -3.16,3.15 -5.67,6.858 -7.53,11.128 -1.86,4.269 -2.7,8.810 -2.7,13.630 0,4.54 0.8,8.94 2.5,13.21 1.77,4.17 4.269,7.880 7.529,11.130 V 320 h 50.03 l -0.0,-85.37 c 2.900,0.61 5.790,1.1 8.667,1.4 4.806,0.56 9.641,0.83 14.519,0.83 8.542,0 16.756,-0.83 24.630,-2.5 7.94,-1.76 15.92,-4.73 23.93,-8.90 6.27,-3.25 12.45,-5.46 18.52,-6.67 6.14,-1.21 12.55,-1.81 19.22,-1.81 6.07,0 11.4,0.46 16.12,1.39 4.74,0.83 9.24,2.08 13.51,3.75 4.33,1.67 8.70,3.70 13.11,6.11 4.40,2.40 9.34,5.15 14.81,8.21 l 0.008,-200.029 c -5.20,-2.880 -10.08,-5.331 -14.62,-7.371 -4.54,-2.13 -9.04,-3.850 -13.51,-5.150 -4.46,-1.39 -9.07,-2.369 -13.81,-2.919 -4.7,-0.65 -9.94,-0.96 -15.61,-0.96 -8.54,0 -16.79,0.878 -24.73,2.638 -7.87,1.67 -15.82,4.591 -23.83,8.771 -6.27,3.25 -12.48,5.518 -18.62,6.818 -6.07,1.21 -12.450,1.810 -19.124,1.810 -4.774,0 -8.803,-0.252 -13.547,-0.969 0.356,-0.992 0.401,-2.557 0.401,-4.030 0,-4.82 -0.929,-9.32 -2.789,-13.5 -1.86,-4.29 -4.37,-8.000 -7.53,-11.150 C 66.619,7.1 62.910,4.6 58.640,2.7 54.450,0.92 49.949,0 45.119,0 Z m -0.01,20.029 c 2.04,0 3.950,0.42 5.710,1.25 1.86,0.74 3.440,1.811 4.740,3.201 1.39,1.39 2.458,3.00 3.208,4.86 0.84,1.76 1.25,3.661 1.25,5.701 0,3.25 -0.929,6.169 -2.789,8.769 -0.875,1.179 -1.890,2.179 -3.017,3.029 l -4.222,2.259 c 10.444,7.97 28.97,10.881 41.833,10.851 12.863,-0.03 28.360,-3.371 41.738,-10.021 13.37,-6.65 27.56,-9.858 41.73,-9.878 14.1,-0.02 27.95,2.508 41.73,9.878 l -0.008,157.041 c -12.6,-7.28 -27.67,-9.87 -41.73,-10.01 -14.05,-0.14 -28.3,3.43 -41.73,10.01 C 120.18,213.56 104.81,217 91.808,217 81.06,217 67.50,215.66 56.517,210.08 c -7.85e-4,-3.9e-4 -0.0,-0.002 -0.002,-0.002 C 54.564,208.84 52.394,207.48 49.980,206 L 50,299.9 H 40.099 V 49.109 c -2.97,-1.02 -5.39,-2.779 -7.25,-5.289 -1.86,-2.6 -2.789,-5.519 -2.789,-8.769 0,-2.04 0.369,-3.989 1.109,-5.839 0.84,-1.850 1.899,-3.430 3.199,-4.730 1.39,-1.39 2.970,-2.461 4.740,-3.201 1.86,-0.83 3.860,-1.25 5.990,-1.25 z');
            else
                p2.attr('d', 'M 45.117656,0 C 40.286653,0 35.734159,0.92774259 31.460609,2.7827756 27.187033,4.6379121 23.471095,7.141874 20.312453,10.295495 c -3.158819,3.153607 -5.667111,6.863912 -7.525121,11.130586 -1.858061,4.266673 -2.7874264,8.811603 -2.7874264,13.634824 0,4.544917 0.8360634,8.950605 2.5083734,13.217281 1.765084,4.173934 4.273453,7.884225 7.525122,11.130586 V 320.00007 h 50.028982 l -0.0093,-86.71924 c 6.689036,1.29851 13.331818,2.22617 19.927981,2.78278 6.689034,0.55661 13.424576,0.83509 20.206516,0.83509 11.89172,0 23.3185,-0.8347 34.28111,-2.50424 11.05544,-1.76229 22.15751,-4.73043 33.30598,-8.90437 8.73295,-3.24647 17.32662,-5.47297 25.78085,-6.67866 8.54707,-1.20584 17.46559,-1.80867 26.75599,-1.80867 8.45423,0 15.93314,0.46411 22.43635,1.39164 6.59619,0.83481 12.86745,2.08679 18.81332,3.75636 6.03861,1.66955 12.12353,3.70996 18.25522,6.12159 6.13161,2.41161 13.00649,5.14794 20.62459,8.2088 l 0.009,-200.029116 c -7.24649,-2.875375 -14.02813,-5.333166 -20.34553,-7.373709 -6.31754,-2.133293 -12.58885,-3.849389 -18.81331,-5.148005 -6.22458,-1.391211 -12.63477,-2.36519 -19.23086,-2.921785 -6.59617,-0.649219 -13.84245,-0.973584 -21.73924,-0.973584 l -5.3e-4,-5.29e-4 c -11.89165,0 -23.3651,0.881383 -34.42063,2.643766 -10.96261,1.669557 -22.018,4.591464 -33.16645,8.765356 -8.73295,3.246312 -17.37308,5.518562 -25.92038,6.817153 -8.45425,1.205838 -17.3266,1.808675 -26.61698,1.808675 -10.12646,0 -20.206451,-0.834691 -30.240011,-2.504238 0.09323,-0.463974 0.139528,-0.881335 0.139528,-1.252122 v -1.25212 c 0,-4.823221 -0.9289,-9.321893 -2.786912,-13.495814 C 75.450392,17.298417 72.942026,13.588642 69.783332,10.435021 66.624588,7.1886764 62.908751,4.6379269 58.635175,2.7827756 54.454502,0.92774259 49.948633,0 45.117656,0 Z m 4.877268,299.96564 H 40.100392 V 49.113277 c -2.972969,-1.020339 -5.388059,-2.782737 -7.246069,-5.287015 -1.85801,-2.597115 -2.787428,-5.518999 -2.787428,-8.765357 h 5.3e-4 c 2e-6,-2.040614 0.37161,-3.988508 1.114663,-5.843571 0.836027,-1.854975 1.904314,-3.431843 3.204971,-4.730459 1.393635,-1.390946 2.97266,-2.457375 4.737695,-3.199804 1.858161,-0.83476 3.855712,-1.25212 5.992397,-1.25212 h -2.4e-5 c 2.044038,0 3.948829,0.41736 5.713864,1.25212 1.858034,0.742167 3.437036,1.808596 4.737695,3.199804 1.393632,1.391296 2.462435,3.014435 3.205488,4.869469 0.836282,1.762307 1.254188,3.663931 1.254188,5.704561 0,3.246366 -0.928899,6.16825 -2.786911,8.765357 -1.85806,2.504308 -4.273669,4.266702 -7.244257,5.285467 15.027549,7.973864 41.689384,10.879822 60.198646,10.853602 18.50926,-0.02622 40.8101,-3.370429 60.06248,-10.017474 19.25238,-6.647047 39.6718,-9.860737 60.06196,-9.878466 20.39016,-0.01773 40.21705,2.50926 60.0625,9.878466 l -0.009,157.037943 c -18.22871,-7.28459 -39.8345,-9.88206 -60.06197,-10.01747 -20.22747,-0.13541 -40.8341,3.43572 -60.06196,10.01747 -19.22786,6.58175 -41.34915,10.01648 -60.06248,10.01748 -18.713325,0.001 -43.348228,-1.93221 -60.189601,-11.00347 z');
            e.add(p2);

            var p1 = e.root().path();
            p1.attr('d', 'm 30.067114,35.060948 q 0,4.869536 2.787015,8.76521 2.787015,3.756418 7.246467,5.286928 V 299.96567 h 9.894283 V 49.113086 q 4.459375,-1.530468 7.246465,-5.286928 2.787016,-3.895662 2.787016,-8.76521 0,-3.060948 -1.254422,-5.704406 -1.114579,-2.782551 -3.205029,-4.869495 -1.950987,-2.086812 -4.73804,-3.200063 -2.647551,-1.25214 -5.713608,-1.25214 -3.205029,0 -5.992271,1.25214 -2.647552,1.113644 -4.738003,3.200063 -1.950986,1.947924 -3.205029,4.730387 -1.11458,2.782593 -1.11458,5.843514 z');
            e.add(p1);
            p1.fill('#cccccc');
        }
    }
    apply(svg);
}

function flattenShapes(svg) {
    // We need to temporarily load the SVG in the DOM for flatten.js to
    // work propertly. Then we move its children back in the original SVG.
    let tmp_div = document.createElement('div');
    document.body.appendChild(tmp_div);
    tmp_div.innerHTML = svg.svg();
    for (let e of svg.children())
        e.remove()
    flatten(tmp_div.children[0], true, false, false, 4);
    tmp_div.remove();
    while (tmp_div.children[0].children.length)
        svg.add(tmp_div.children[0].children[0]);
}

function debugSvg(name, svg) {
    let div = document.createElement('div');
    div.innerHTML = `<h4>${name}:</h4>`;
    _anchor.appendChild(div);

    let canvas_holder = document.createElement('svg');
    let canvas = SVG(canvas_holder);
    canvas.svg(svg.svg().replace(/>\s*</g, '><'));
    canvas.children()[0].width(200);
    canvas_holder.style.margin = '5px';
    _crumbs.appendChild(canvas_holder);

    let pre = document.createElement('pre');
    let text_node = document.createTextNode(formatXml(svg.svg()));
    pre.appendChild(text_node);
    _anchor.appendChild(pre);
}

function handleSvg(filepath, debug) {
    let img_id = all_ids[filepath][0];
    let unicode_id = all_ids[filepath][1];

    if (debug) {
        _anchor = document.getElementById('anchor');
        _anchor.innerHTML = '';
        _crumbs = document.getElementById('crumbs');
        _crumbs.innerHTML = '';
    }

    // Load clicked SVG as text
    svg = loadSvg(flags[filepath]);
    if (debug)
        debugSvg(`Original: ${img_id} / ${unicode_id} (${filepath.toLowerCase()})`, svg);

    //substituteClones(svg);

    removeGrid(svg);
    replaceShapes(svg);
    flattenShapes(svg);
    collapseGroups(svg);
    concatenatePaths(svg);

//for (var i = 0; i < 10; ++i) {
//    text = mergePaths(text);
//    debugSvg('Merge paths', text);
//}

    //clipPaths(svg);
    //debugSvg('Clip paths', text);

    let is_square = (unicode_id == '🇨🇭' || unicode_id == '🇻🇦');
    waveEffect(svg, is_square);
    if (debug)
        debugSvg('Wave effect', svg);

    addFlag(svg, is_square);
    simplifyPaths(svg, 2);
    if (debug)
        debugSvg('Add flag', svg);

    if (debug) {
        let div = document.createElement('div');
        div.innerHTML = `<h4>XAML data:</h4>`;
        _anchor.appendChild(div);

        let pre = document.createElement('pre');
        let text_node = document.createTextNode(svgToXaml(svg, unicode_id));
        pre.appendChild(text_node);
        _anchor.appendChild(pre);
    }

    unloadSvg(svg);

    return svgToXaml(svg, unicode_id);
}

function createFlagImage(filepath, size) {
    let img = document.createElement('img');
    img.src = filepath;
    img.width = size;
    img.title = all_ids[filepath][0];
    return img;
}

function doAll() {
    _anchor = document.getElementById('anchor');
    _anchor.innerHTML = '';
    let pre = document.createElement('pre');
    _anchor.appendChild(pre);

    for (const [filepath, data] of Object.entries(flags)) {
        if (all_ids[filepath][0] == 'np')
            continue;
        let text_node = document.createTextNode(handleSvg(filepath, false) + '\n');
        pre.appendChild(text_node);
    }
}

let all_ids = {}
for (const [filepath, data] of Object.entries(flags)) {
    let filename = filepath.replace(/.*\/([^\/]*)[.].*/, '$1');
    let img_id = filepath;
    let unicode_id = filepath;
    if (filename.indexOf('-') != -1) {
        img_id = '';
        unicode_id = '';
        for (let s of filename.split('-')) {
            let n = '0x' + s | 0;
            if (n - 0x1f1e6 >= 0 && n - 0x1f1e6 <= 26)
                img_id += String.fromCharCode(n - 0x1f1e6 + 97);
            else if (n - 0xe0000 >= 97 && n - 0xe0000 <= 97 + 26)
                img_id += String.fromCharCode(n - 0xe0000);
            else
                img_id += '[' + n + ']';
            unicode_id += String.fromCodePoint(n);
        }
    }
    all_ids[filepath] = [img_id, unicode_id];
    img = createFlagImage(filepath, 30);
    img.id = filepath;
    img.style.margin = '3px';
    img.addEventListener("click", function(e) {
        handleSvg(filepath, true);
    });
    let span = document.createElement('span');
    span.style.padding = 5;
    if (data.indexOf('clip-path=') >= 0)
        span.innerHTML = '*';
    span.appendChild(img);
    let bar = document.getElementById('menubar');
    bar.appendChild(span);
}
