
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

function svgToText(svg) {
    var s = new XMLSerializer();
    return formatXml(s.serializeToString(svg));
}

var match_num = /(?<=d="[^"]*)([0-9]+[.]?[0-9]*|[.][0-9]+)(e[-+]?[0-9]+)?/g;

// List obtained by picking from the output of this script:
//   for x in ../Emoji.Wpf/CountryFlags/svg/*svg; do sed 's/<[^g][^>]*>//g' $x | tr ' "' '\n' \
//    | grep = | sort | uniq; done | sort | uniq -c | sort -n
var important_attrs = ['stroke-linejoin', 'stroke-linecap', 'clip-path', 'stroke-width', 'stroke', 'fill', 'style'];

// Add some randomness to path coordinates
function wigglePath(d) {
    // Wiggle all numbers
    return d.replace(match_num, function(match, capture) {
        return match * 1.0 + Math.random() / 10000;
        //return (Math.round(match * z * 10000) / 10000).toString();
    });
}

// Round path coordinates
function roundPath(d, precision) {
    return d.replace(match_num, function(match, capture) {
        return Number.parseFloat(match).toFixed(precision) * 1.0;
    });
}

// Close three-point paths
function closePath(d) {
    let start = d.replace(/M *([^,C ]*, *[^,C ]*).*/, '$1');
    let end = d.replace(/.*C.*,([^C, ]*, *[^C, ]*)/, '$1');
    if (start != end)
        d += 'Z';
    return d;
}

function formatXml(xml) {
    var ret = '', indent = '';
    var tab = '  ';
    xml.split(/>\s*</).forEach(function(node) {
        if (node.match( /^\/\w/ )) indent = indent.substring(tab.length); // decrease indent by one 'tab'
        ret += indent + '<' + node.replace(/(?<=d="[^"]*)([0-9])(C)/g, '$1 $2') + '>\r\n';
        if (node.match( /^<?\w([^>/]*|[^>]*[^/])$/ )) indent += tab;              // increase indent
    });
    ret = ret.replace( /(<[^\/>][^>]*[^\/>]>)\s*(<\/)/g, '$1$2');
    return ret.substring(1, ret.length - 3);
}

function applyToSvg(func, text) {
    let canvas_holder = document.createElement('svg');
    let canvas = SVG(canvas_holder);
    canvas.svg(text.replace(/>\s*</g, '><'));
    func(canvas);
    let ret = canvas.children()[0].svg();
    canvas_holder.remove();
    return ret;
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

// Replace all <use> tags with their targets.
function substituteClones(svg_text) {
    let ids = {};
    let uses = [];
    let f = function(e) {
        if (e.type == 'use') {
            // Keep for later (see gd.svg for a <use> node that appears before the id)
            uses.push(e);
        } else if (e.node.id && e.type != 'svg' && e.type != 'clipPath') {
            ids[e.node.id] = e;
            e.attr('id', null);
        }
        for (let e2 of e.children())
            f(e2, ids);

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
    return applyToSvg(f, svg_text);
}

function removeGrid(svg_text) {
    let viewbox = null;
    let f = function(e) {
        if (e.node.id == 'grid') {
            e.remove();
            return;
        } else if (e.node.id == 'line') {
            if (e.x() && e.width()) {
                //e.root().attr('viewBox', `${e.x()} ${e.y()} ${e.width()} ${e.height()}`);
            }
        }

        for (let e2 of e.children())
            f(e2);
    }
    return applyToSvg(f, svg_text);
}

function collapseGroups(svg_text) {
    let f = function(e) {
        for (let e2 of e.children())
            f(e2);
        if (e.type == 'g' && e.node.attributes.length == 0) {
            //e.ungroup();
            correctUngroup(e);
        }
    }
    return applyToSvg(f, svg_text);
}

function mergePaths(svg_text) {
    let raph_tmp = document.createElement('div');
    raph_tmp.id = 'raphael_canvas';
    document.body.appendChild(raph_tmp);
    let paper = Raphael('raphael_canvas', 250, 250);

    let early_exit = false;
    let f = function(e) {
        for (let ch of e.children()) {
            f(ch);
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

    let ret = applyToSvg(f, svg_text);
    raph_tmp.remove();
    return roundPath(ret, 4);
}

function clipPaths(svg_text) {
    let raph_tmp = document.createElement('div');
    raph_tmp.id = 'raphael_canvas';
    document.body.appendChild(raph_tmp);
    let paper = Raphael('raphael_canvas', 250, 250);

    let cids = {}
    let f = function(e, clips=[]) {
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
            f(ch, clips);
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

    let ret = applyToSvg(f, svg_text);
    raph_tmp.remove();
    return roundPath(ret, 4);
}

function warp(x, y) {
    return [x, y - 4 * Math.sin((x - 5) * 6.28319 / 60)];
}

function waveEffect(svg_text) {
    let raph_tmp = document.createElement('div');
    raph_tmp.id = 'raphael_canvas';
    document.body.appendChild(raph_tmp);
    let paper = Raphael('raphael_canvas', 250, 250);

    let cids = {}
    let f = function(e, clips=[]) {
        for (let ch of e.children()) {
            f(ch, clips);
        }
        if (e.type == 'path') {
            let path = paper.path(e.attr('d'));
            let segments = path.attr('path');
            let new_segments = [];
            let prev_point = null;
            for (let s of segments)  {
                if (s[0] == 'M') {
                    prev_point = [s[1], s[2]];
                    new_segments.push(['M', ...warp(s[1], s[2])]);
                } else {
                    let warped_points = [];
                    for (let i = 0; i <= 50; ++i) {
                        let p = Raphael.findDotsAtSegment(prev_point[0], prev_point[1], s[1], s[2], s[3], s[4], s[5], s[6], i / 50);
                        warped_points.push(warp(p.x, p.y));
                    }
                    prev_point = [s[5], s[6]];
                    warped_data = fitCurve(warped_points, 0.1);
                    for (let w of warped_data) {
                        new_segments.push(['C', w[1][0], w[1][1],
                                                w[2][0], w[2][1],
                                                w[3][0], w[3][1]]);
                    }
                }
            }
            let d2 = pathToString(new_segments);
            e.attr('d', d2);
            path.remove();
        }
    }

    let ret = applyToSvg(f, svg_text);
    raph_tmp.remove();
    return roundPath(ret, 4);
}

function flattenShapes(svg_text) {
    let tmp = document.createElement('div');
    document.body.appendChild(tmp);
    tmp.innerHTML = svg_text;
    flatten(tmp.children[0], true, false, false, 4);
    let ret = svgToText(tmp.children[0]);
    tmp.remove();
    // Round all numbers to 4 digits
    return roundPath(ret, 4);
}

function debugSvg(name, svg_text) {
    let div = document.createElement('div');
    div.innerHTML = `<h4>${name}:</h4>`;
    _anchor.appendChild(div);

    let canvas_holder = document.createElement('svg');
    let canvas = SVG(canvas_holder);
    canvas.svg(svg_text.replace(/>\s*</g, '><'));
    canvas.children()[0].width(200);
    canvas_holder.style.margin = '5px';
    _crumbs.appendChild(canvas_holder);

    let pre = document.createElement('pre');
    let text_node = document.createTextNode(formatXml(svg_text));
    pre.appendChild(text_node);
    _anchor.appendChild(pre);
}

function handleSvg(id) {
    _anchor = document.getElementById('anchor');
    _anchor.innerHTML = '';
    _crumbs = document.getElementById('crumbs');
    _crumbs.innerHTML = '';

    img = createFlagImage(id);
    img.width = 200;
    img.style.margin = '5px';
    _crumbs.appendChild(img);

    // Load clicked SVG as text
    text = flags[fids[id]];
    text = removeGrid(text);
    debugSvg(`Original: ${id} (${fids[id].toLowerCase()})`, text);

//    text = substituteClones(text);
//    debugSvg('Substitute clones', text);

    text = flattenShapes(text);
    debugSvg('Flatten shapes', text);

    text = collapseGroups(text);
    debugSvg('Collapse groups', text);

//for (var i = 0; i < 10; ++i) {
//    text = mergePaths(text);
//    debugSvg('Merge paths', text);
//}

//    text = clipPaths(text);
//    debugSvg('Clip paths', text);

    text = waveEffect(text);
    debugSvg('Wave effect', text);
}

function createFlagImage(id) {
    let img = document.createElement('img');
    img.src = `../Emoji.Wpf/CountryFlags/png100px/${id}.png`;
    img.title = id;
    return img;
}

let bar = document.getElementById('menubar');
let fids = {}
for (const [id, data] of Object.entries(flags)) {
    let newid = String.fromCharCode('0x' + id.substring(0,5) - 0x1f1e6 + 97)
              + String.fromCharCode('0x' + id.substring(6,11) - 0x1f1e6 + 97);
    fids[newid] = id;
    img = createFlagImage(newid);
    img.width = 30;
    img.id = newid;
    img.style.margin = '3px';
    img.addEventListener("click", function(e) {
        handleSvg(newid);
    });
    let span = document.createElement('span');
    span.style.padding = 5;
    if (data.indexOf('clip-path=') >= 0)
        span.innerHTML = '*';
    span.appendChild(img);
    bar.appendChild(span);
}
