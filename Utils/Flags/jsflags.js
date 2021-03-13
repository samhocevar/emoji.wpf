
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
    let dx = x / (is_square ? 42 : 60);
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
                p2.attr('d', 'M 45.119141 0 C 40.289141 0 35.730936 0.92929686 31.460938 2.7792969 C 27.190938 4.6392969 23.470547 7.1407815 20.310547 10.300781 C 17.150547 13.450781 14.639297 17.159688 12.779297 21.429688 C 10.919297 25.699686 9.9902344 30.240547 9.9902344 35.060547 C 9.9902344 39.600547 10.83 44.009297 12.5 48.279297 C 14.27 52.449297 16.769297 56.160156 20.029297 59.410156 L 20.029297 320 L 70.060547 320 L 70.050781 233.9375 C 74.671598 234.89114 79.266957 235.61053 83.837891 236.06055 C 89.500557 236.62055 95.19605 236.90039 100.94336 236.90039 C 111.0075 236.90039 120.68203 236.07039 129.95898 234.40039 C 139.32058 232.64039 148.71653 229.67 158.1543 225.5 C 165.5437 222.25 172.82416 220.03031 179.97656 218.82031 C 187.2136 217.61031 194.76355 217.00977 202.62695 217.00977 C 209.77935 217.00977 216.11078 217.47039 221.62109 218.40039 C 227.05985 219.20844 232.22938 220.43045 237.13867 222.03516 L 237.13867 201.96875 C 237.13729 201.96834 237.13615 201.9672 237.13477 201.9668 L 237.13867 45.048828 C 237.14004 45.049238 237.14121 45.050371 237.14258 45.050781 L 237.14258 23.898438 C 231.93111 22.532193 226.56332 21.563596 221.03711 21.019531 C 215.45063 20.369531 209.32162 20.050781 202.63477 20.050781 C 192.57063 20.050781 182.85313 20.929453 173.5 22.689453 C 164.22305 24.359453 154.8616 27.280936 145.42383 31.460938 C 138.03443 34.710938 130.72141 36.979297 123.48438 38.279297 C 116.33195 39.489297 108.81655 40.089844 100.95312 40.089844 C 93.924358 40.089844 86.923404 39.521371 79.951172 38.400391 C 79.956085 38.133385 79.963439 37.869868 79.960938 37.589844 C 80.050938 37.129844 80.099609 36.709844 80.099609 36.339844 L 80.099609 35.089844 C 80.099609 30.269844 79.170547 25.769844 77.310547 21.589844 C 75.450547 17.299844 72.939297 13.589453 69.779297 10.439453 C 66.619297 7.1894532 62.910625 4.6392969 58.640625 2.7792969 C 54.450625 0.92929685 49.949141 -2.9605947e-16 45.119141 0 z M 45.099609 20.029297 C 47.139609 20.029297 49.050547 20.449297 50.810547 21.279297 C 52.670547 22.019297 54.250781 23.090469 55.550781 24.480469 C 56.940781 25.870469 58.009766 27.489609 58.759766 29.349609 C 59.599766 31.109609 60.009766 33.010781 60.009766 35.050781 C 60.009766 38.300781 59.080703 41.220314 57.220703 43.820312 C 55.948607 45.530119 54.412937 46.88994 52.623047 47.910156 L 49.980469 49.109375 C 62.509429 57.079375 84.732228 59.990937 100.16211 59.960938 C 115.59198 59.930937 134.18178 56.589453 150.22852 49.939453 C 166.27526 43.289453 183.29788 40.080547 200.29492 40.060547 C 205.92134 40.053926 211.49576 40.333467 217.03711 40.96875 L 217.03516 197.9668 C 211.42167 197.31897 205.79265 197.00666 200.28516 196.96094 C 183.4215 196.82094 166.25076 200.40047 150.2207 206.98047 C 134.19063 213.56047 115.7509 217 100.1543 217 C 84.557696 217 64.018239 215.07 49.980469 206 L 50 299.9707 L 40.099609 299.9707 L 40.099609 49.109375 C 37.129609 48.089375 34.709609 46.330312 32.849609 43.820312 C 30.989609 41.220312 30.060547 38.300781 30.060547 35.050781 C 30.060547 33.010781 30.429922 31.060937 31.169922 29.210938 C 32.009922 27.360937 33.069141 25.780469 34.369141 24.480469 C 35.759141 23.090469 37.339375 22.019297 39.109375 21.279297 C 40.969375 20.449297 42.969609 20.029297 45.099609 20.029297 z');
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
