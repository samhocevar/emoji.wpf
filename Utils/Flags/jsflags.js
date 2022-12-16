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

function compressColor(c) {
    return c.replace(/(.)\1(.)\2(.)\3/, '$1$2$3');
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
    let ret = `    <!-- ${all_flags[unicode_id].annotation} -->\n`;
    ret += `    <DrawingGroup x:Key="${unicode_id}">\n`;
    for (let p of g.children()) {
        ret += `        <GeometryDrawing`;
        if (p.attr()['fill'] && p.attr('fill') != 'none')
            ret += ` Brush="${compressColor(p.attr('fill'))}"`;
        ret += ` Geometry="`;
        if (!p.attr()['fill-rule'] || p.attr('fill-rule') != 'evenodd')
            ret += 'F1';
        ret += `${compressPath(p.attr('d'))}"`;
        if (p.attr()['stroke']) {
            ret += '>\n';
            ret += '            <GeometryDrawing.Pen>\n';
            ret += '                <Pen';
            if (p.attr()['stroke'])
                ret += ` Brush="${compressColor(p.attr('stroke'))}"`;
            if (p.attr()['stroke-width'])
                ret += ` Thickness="${p.attr('stroke-width')}"`;
            if (p.attr()['stroke-linecap'])
                ret += ` StartLineCap="Round" EndLineCap="Round"`;
            if (p.attr()['stroke-linejoin'])
                ret += ` LineJoin="Round"`;
            if (p.attr()['stroke-miterlimit'])
                ret += ` MiterLimit="${p.attr('stroke-miterlimit')}"`;
            ret += '/>\n';
            ret += '            </GeometryDrawing.Pen>\n';
            ret += '        </GeometryDrawing>\n';
        } else {
            ret += '/>\n';
        }
    }
    //ret += '        <DrawingGroup.ClipGeometry>\n';
    //ret += '            <RectangleGeometry Rect="0 0 160 160"/>\n';
    //ret += '        </DrawingGroup.ClipGeometry>\n';
    ret += '    </DrawingGroup>\n';
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

function simplifyColors(svg) {
    const match_color = /(.)\1(.)\2(.)\3/;
    const apply = function(e) {
        if (e.type == 'path') {
            // Replace #aabbcc colors with #abc when possible
            for (let a of ['fill', 'stroke']) {
                if (e.attr()[a]) {
                    e.attr(a, compressColor(e.attr(a)));
                }
            }
        } else {
            for (let c of e.children())
                apply(c);
        }
    }
    apply(svg);
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
                for (let e2 of e.children())
                    e2.attr('stroke', '#fff');
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
function warp(x, y, style) {
    let subx = 6;
    let divx = 60;
    let shrink = 60;
    switch (style) {
        case FLAG_SQUARE: subx = 18; divx = 36; shrink = 52; break;
        case FLAG_NEPAL: subx = 21; divx = 36; shrink = 52; break;
    }
    x -= subx;
    let dx = x / divx;
    let dy = y / 60;
    let x2 = 50 + 241 * x / shrink;
    let y2 = 264 * y / 60 - 30;
    //let x2 = lerp(1.0 - Math.pow(1 - dx, 1.1), Math.pow(dx, 1.1), dy);
    //return [x2 * 60 + 4, y - 4 * Math.sin(x2 * 6.28319)];
    return [x2, y2 + 11 * Math.sin(dx * 6.28319)];
}

function waveEffect(svg, style) {
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
                    new_segments.push(['M', ...warp(s[1], s[2], style)]);
                } else {
                    let warped_points = [];
                    for (let i = 0; i <= 50; ++i) {
                        let p = Raphael.findDotsAtSegment(prev_point[0], prev_point[1], s[1], s[2], s[3], s[4], s[5], s[6], i / 50);
                        warped_points.push(warp(p.x, p.y, style));
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

function addFlag(svg, style) {
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
            if (style == FLAG_RECTANGULAR)
                p2.attr('d', 'M 45.117,0 C 40.286,0 35.734,0.92 31.460,2.7 27.187,4.6 23.471,7.141 20.312,10.295 c -3.158,3.153 -5.667,6.863 -7.525,11.130 -1.858,4.266 -2.7,8.811 -2.7,13.634 0,4.544 0.8,8.950 2.5,13.217 1.765,4.173 4.273,7.884 7.525,11.130 V 320.00 h 50.028 l -0.0,-86.71 c 6.689,1.29 13.331,2.22 19.927,2.78 6.689,0.55 13.424,0.83 20.206,0.83 11.89,0 23.3,-0.8 34.28,-2.50 11.05,-1.76 22.15,-4.73 33.30,-8.90 8.73,-3.24 17.32,-5.47 25.78,-6.67 8.54,-1.20 17.46,-1.80 26.75,-1.80 8.45,0 15.93,0.46 22.43,1.39 6.59,0.83 12.86,2.08 18.81,3.75 6.03,1.66 12.12,3.70 18.25,6.12 6.13,2.41 13.00,5.14 20.62,8.2 l 0.009,-200.029 c -7.24,-2.875 -14.02,-5.333 -20.34,-7.373 -6.31,-2.133 -12.58,-3.849 -18.81,-5.148 -6.22,-1.391 -12.63,-2.36 -19.23,-2.921 -6.59,-0.649 -13.84,-0.973 -21.73,-0.973 l -5.3e-4,-5.29e-4 c -11.89,0 -23.3,0.881 -34.42,2.643 -10.96,1.669 -22.018,4.591 -33.16,8.765 -8.73,3.246 -17.37,5.518 -25.92,6.817 -8.45,1.205 -17.3,1.808 -26.61,1.808 -10.12,0 -20.206,-0.834 -30.240,-2.504 0.09,-0.463 0.139,-0.881 0.139,-1.252 v -1.25 c 0,-4.823 -0.9,-9.321 -2.786,-13.495 C 75.450,17.298 72.942,13.588 69.783,10.435 66.624,7.1 62.908,4.6 58.635,2.7 54.454,0.92 49.948,0 45.117,0 Z m 4.877,299.96 H 40.100 V 49.113 c -2.972,-1.020 -5.388,-2.782 -7.246,-5.287 -1.85,-2.597 -2.787,-5.518 -2.787,-8.765 h 5.3e-4 c 2e-6,-2.040 0.37,-3.988 1.114,-5.843 0.836,-1.854 1.904,-3.431 3.204,-4.730 1.393,-1.390 2.97,-2.457 4.737,-3.199 1.858,-0.83 3.855,-1.25 5.992,-1.25 h -2.4e-5 c 2.044,0 3.948,0.41 5.713,1.25 1.858,0.742 3.437,1.808 4.737,3.199 1.393,1.391 2.462,3.014 3.205,4.869 0.836,1.762 1.254,3.663 1.254,5.704 0,3.246 -0.928,6.16 -2.786,8.765 -1.85,2.504 -4.273,4.266 -7.244,5.285 15.027,7.973 41.689,10.879 60.198,10.853 18.50,-0.02 40.8,-3.370 60.06,-10.017 19.25,-6.647 39.6,-9.860 60.06,-9.878 20.39,-0.01 40.21,2.50 60.0,9.878 l -0.009,157.037 c -18.22,-7.28 -39.8,-9.88 -60.06,-10.01 -20.22,-0.13 -40.8,3.43 -60.06,10.01 -19.22,6.58 -41.34,10.01 -60.06,10.01 -18.713,0.001 -43.348,-1.93 -60.189,-11.00 z');
            else if (style == FLAG_NEPAL)
                p2.attr('d', 'm 45.119,0 c -4.83,0 -9.388,0.91 -13.658,2.6 -4.27,1.8 -7.990,4.2 -11.150,7.5 -3.16,3.15 -5.67,6.860 -7.53,11.130 -1.86,4.27 -2.699,8.81 -2.699,13.63 0,4.539 0.8,8.938 2.5,13.208 1.77,4.17 4.269,7.880 7.529,11.130 V 320 h 50.03 v -77.36 c 0.0,-0.0 0.01,-0.0 0.02,-0.11 9.784,1.80 18.476,2.43 26.275,2.23 0.930,-0.0 1.848,-0.0 2.753,-0.10 18.108,-0.94 31.332,-6.31 42.615,-11.21 18.05,-7.82 30.7,-14.3 63.94,-4.73 7.72,2.24 14.80,-5.09 12.28,-12.73 -9.27,-28.18 -29.97,-48.30 -57.94,-66.89 14.74,-4.59 27.8,-6.205 46.53,-2.55 7.69,1.50 14.04,-6.04 11.26,-13.37 C 211.20,115.59 201.0,103.60 189.35,95.638 177.63,87.672 164.76,83.550 152.0,79.666 126.92,72.009 102.34,65.745 79.984,38.320 c 0.177,-0.941 0.205,-2.13 0.205,-3.269 0,-4.82 -0.929,-9.32 -2.789,-13.5 -1.86,-4.29 -4.37,-8.00 -7.53,-11.15 C 66.619,7.1 62.910,4.5 58.640,2.6 54.450,0.91 49.949,0 45.119,0 Z m -0.01,20.029 h 0.0 c 2.04,0 3.95,0.42 5.710,1.25 1.86,0.74 3.440,1.811 4.740,3.201 1.39,1.39 2.458,2.999 3.208,4.859 0.84,1.76 1.25,3.659 1.25,5.699 0,3.25 -0.929,6.171 -2.789,8.771 -0.88,1.18 -1.889,2.179 -3.019,3.029 l -4.220,2.259 h 12.958 l 0.0,-0.01 c 0.107,0.152 0.219,0.30 0.335,0.449 l 0.01,0.01 c 26.317,33.125 57.945,41.652 82.865,49.251 12.45,3.799 23.3,7.337 31.80,13.523 3.83,2.80 9.27,5.8 10.69,9.26 0.31,0.76 -0.76,4.87 -2.50,4.67 -23.18,-2.73 -40.04,6.21 -52.41,11.00 l -19.21,7.4 17.69,10.47 c 0.0,0.007 0.0,0.0 0.0,0.0 26.27,15.53 46.9,32.86 56.02,44.49 1.51,1.94 -1.01,6.9 -4.2,6.35 -16.4,-2.82 -35.66,4.37 -49.53,10.3 -18.01,7.81 -36.560,14.49 -69.099,4.62 C 60.302,219.4 55.230,218.28 49.980,215 L 50,299.90 H 40.099 V 49.109 c -2.97,-1.02 -5.39,-2.779 -7.25,-5.289 -1.86,-2.6 -2.789,-5.519 -2.789,-8.769 0,-2.04 0.369,-3.989 1.109,-5.839 0.84,-1.850 1.899,-3.430 3.199,-4.730 1.39,-1.39 2.970,-2.461 4.740,-3.201 1.86,-0.83 3.860,-1.25 5.990,-1.25 z');
            else
                p2.attr('d', 'm 45.119,0 c -4.83,0 -9.388,0.92 -13.658,2.7 -4.27,1.86 -7.990,4.3 -11.150,7.5 -3.16,3.15 -5.67,6.858 -7.53,11.128 -1.86,4.269 -2.7,8.810 -2.7,13.630 0,4.54 0.8,8.94 2.5,13.21 1.77,4.17 4.269,7.880 7.529,11.130 V 320 h 50.03 l -0.0,-85.37 c 2.900,0.61 5.790,1.1 8.667,1.4 4.806,0.56 9.641,0.83 14.519,0.83 8.542,0 16.756,-0.83 24.630,-2.5 7.94,-1.76 15.92,-4.73 23.93,-8.90 6.27,-3.25 12.45,-5.46 18.52,-6.67 6.14,-1.21 12.55,-1.81 19.22,-1.81 6.07,0 11.4,0.46 16.12,1.39 4.74,0.83 9.24,2.08 13.51,3.75 4.33,1.67 8.70,3.70 13.11,6.11 4.40,2.40 9.34,5.15 14.81,8.21 l 0.008,-200.029 c -5.20,-2.880 -10.08,-5.331 -14.62,-7.371 -4.54,-2.13 -9.04,-3.850 -13.51,-5.150 -4.46,-1.39 -9.07,-2.369 -13.81,-2.919 -4.7,-0.65 -9.94,-0.96 -15.61,-0.96 -8.54,0 -16.79,0.878 -24.73,2.638 -7.87,1.67 -15.82,4.591 -23.83,8.771 -6.27,3.25 -12.48,5.518 -18.62,6.818 -6.07,1.21 -12.450,1.810 -19.124,1.810 -4.774,0 -8.803,-0.252 -13.547,-0.969 0.356,-0.992 0.401,-2.557 0.401,-4.030 0,-4.82 -0.929,-9.32 -2.789,-13.5 -1.86,-4.29 -4.37,-8.000 -7.53,-11.150 C 66.619,7.1 62.910,4.6 58.640,2.7 54.450,0.92 49.949,0 45.119,0 Z m -0.01,20.029 c 2.04,0 3.950,0.42 5.710,1.25 1.86,0.74 3.440,1.811 4.740,3.201 1.39,1.39 2.458,3.00 3.208,4.86 0.84,1.76 1.25,3.661 1.25,5.701 0,3.25 -0.929,6.169 -2.789,8.769 -0.875,1.179 -1.890,2.179 -3.017,3.029 l -4.222,2.259 c 10.444,7.97 28.97,10.881 41.833,10.851 12.863,-0.03 28.360,-3.371 41.738,-10.021 13.37,-6.65 27.56,-9.858 41.73,-9.878 14.1,-0.02 27.95,2.508 41.73,9.878 l -0.008,157.041 c -12.6,-7.28 -27.67,-9.87 -41.73,-10.01 -14.05,-0.14 -28.3,3.43 -41.73,10.01 C 120.18,213.56 104.81,217 91.808,217 81.06,217 67.50,215.66 56.517,210.08 c -7.85e-4,-3.9e-4 -0.0,-0.002 -0.002,-0.002 C 54.564,208.84 52.394,207.48 49.980,206 L 50,299.9 H 40.099 V 49.109 c -2.97,-1.02 -5.39,-2.779 -7.25,-5.289 -1.86,-2.6 -2.789,-5.519 -2.789,-8.769 0,-2.04 0.369,-3.989 1.109,-5.839 0.84,-1.850 1.899,-3.430 3.199,-4.730 1.39,-1.39 2.970,-2.461 4.740,-3.201 1.86,-0.83 3.860,-1.25 5.990,-1.25 z');
            e.add(p2);

            var p1 = e.root().path();
            p1.attr('d', 'm 30.067,35.060 q 0,4.869 2.787,8.76 2.787,3.756 7.246,5.286 V 299.96 h 9.894 V 49.113 q 4.459,-1.530 7.246,-5.286 2.787,-3.895 2.787,-8.76 0,-3.060 -1.254,-5.704 -1.114,-2.782 -3.205,-4.869 -1.950,-2.086 -4.73,-3.200 -2.647,-1.25 -5.713,-1.25 -3.205,0 -5.992,1.25 -2.647,1.113 -4.738,3.200 -1.950,1.947 -3.205,4.730 -1.11,2.782 -1.11,5.843 z');
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
    let name = all_flags[unicode_id].annotation;

    if (debug) {
        _desc = document.getElementById('desc');
        _desc.innerHTML = '';
        _anchor = document.getElementById('anchor');
        _anchor.innerHTML = '';
        _crumbs = document.getElementById('crumbs');
        _crumbs.innerHTML = '';
    }

    // Load clicked SVG as text
    svg = loadSvg(flags[filepath]);
    if (debug)
    {
        _desc.innerHTML = `<h3>Processing ${name}</h3><h4>${img_id} / ${unicode_id} (${filepath.toLowerCase()})</h4>`;
        debugSvg('Original', svg);
    }

    //substituteClones(svg);

    removeGrid(svg);
    replaceShapes(svg);
    flattenShapes(svg);
    collapseGroups(svg);
    simplifyColors(svg);
    concatenatePaths(svg);

//for (var i = 0; i < 10; ++i) {
//    text = mergePaths(text);
//    debugSvg('Merge paths', text);
//}

    //clipPaths(svg);
    //debugSvg('Clip paths', text);

    if (!document.getElementById('win11').checked) {
        let style = (unicode_id == '🇨🇭' || unicode_id == '🇻🇦') ? FLAG_SQUARE
                   : unicode_id == '🇳🇵' ? FLAG_NEPAL : FLAG_RECTANGULAR;
        waveEffect(svg, style);
        if (debug)
            debugSvg('Wave effect', svg);

        addFlag(svg, style);
    }

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
        let text_node = document.createTextNode(handleSvg(filepath, false) + '\n');
        pre.appendChild(text_node);
    }
}

const FLAG_RECTANGULAR = 1;
const FLAG_SQUARE = 2;
const FLAG_NEPAL = 3;

let all_flags = {}
for (const [_, emoji] of Object.entries(openmoji)) {
    all_flags[emoji.emoji] = emoji;
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
    img.style.margin = '0px 3px';
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
