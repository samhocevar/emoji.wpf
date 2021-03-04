
// More robust version, see https://github.com/poilu/raphael-boolean/issues/3
// and https://github.com/DmitryBaranovskiy/raphael/issues/1130
Raphael.isPointInsidePath = function (path, x, y) {
    var bbox = Raphael.pathBBox(path);
    return Raphael.isPointInsideBBox(bbox, x, y) &&
        Raphael.pathIntersectionNumber(path, [["M", x, y], ["l", bbox.width + 10, Math.random()]]) % 2 == 1;
};

function svgToText(svg) {
    var s = new XMLSerializer();
    return formatXml(s.serializeToString(svg));
}

var match_num = /(?<=d="[^"]*)([0-9]+[.]?[0-9]*|[.][0-9]+)(e[-+]?[0-9]+)?/g;

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
        return Number.parseFloat(match).toFixed(precision);
    });
}

// Close three-point paths
function closePath(d) {
    let start = d.replace(/M([^,C]*,[^,C]*).*/, '$1');
    let end = d.replace(/.*C.*,([^C,]*,[^C,*])/, '$1');
    if (start != end)
        d += 'Z';//'L' + start;
    //d = wigglePath(d);
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
    // List obtained by picking from the output of this script:
    //   for x in ../Emoji.Wpf/CountryFlags/svg/*svg; do sed 's/<[^g][^>]*>//g' $x | tr ' "' '\n' \
    //    | grep = | sort | uniq; done | sort | uniq -c | sort -n
    attrs = ['stroke-linejoin', 'stroke-linecap', 'clip-path', 'stroke-width', 'stroke', 'fill'];
    for (let name of attrs) {
        if (p1.attr(name) != p2.attr(name))
            return false;
    }
    return true;
}

// Replace all <use> tags with their targets.
function substituteClones(svg_text) {
    let ids = {}
    let f = function(e) {
        if (e.type == 'use') {
            let tid = e.attr('xlink:href').replace('#','');
            let clone = ids[tid].clone();
            clone.attr('id', null);
            let g = e.root().group();
            g.add(clone);
            let x = 0, y = 0, transform = null;
            for (let attr in e.attr()) {
                let val = e.attr(attr);
                // See kr.svg: <use ... y="44"/>
                if (attr == 'x')
                    x = val;
                else if (attr == 'y')
                    y = val;
                // Best demonstrated in cw.svg
                else if (attr == 'transform')
                    transform = e.transform();
                else if (attr != 'xlink:href')
                    g.attr(attr, val);
            }
            if (x != 0 || y != 0)
                g.transform({translateX: x, translateY: y})
            if (transform !== null)
                g.transform(transform, true);
            e.replace(g);
            if (e.node.id) {
                // See sb.svg for a <use> node that itself has an id attr
                g.node.id = e.node.id;
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
        } else if (e.node.id && e.type != 'svg' && e.type != 'clipPath') {
            ids[e.node.id] = e;
            e.attr('id', null);
        }
        for (let e2 of e.children())
            f(e2, ids);
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
//d1 = roundPath(d1, 1);
            let d2 = closePath(e.attr('d'));
//d2 = roundPath(d2, 1);

//d1 = "M0,0 L-2,6 L2,2 z";
//d2 = "M0,0 L2,6 L-2,2 z";

//d1 = "M0,-6C0,-6,-1.8541,-0.2937,-1.8541,-0.2937C-1.8541,-0.2937,-1.8401694472472656,-0.28917354075557145,-1.623894420610723,-0.21889922278453153C-1.8955335264731583,0.7481421230640761,-1.9501,0.9424,-1.9501,0.9424C-1.9501,0.9424,-0.9504443536091689,0.6175815507849991,0,0.30875334367278273C0.9504443536091689,0.6175815507849991,1.9501,0.9424,1.9501,0.9424C1.9501,0.9424,1.8955335264731583,0.7481421230640761,1.623894420610723,-0.21889922278453153C1.8401694472472656,-0.28917354075557145,1.8541,-0.2937,1.8541,-0.2937C1.8541,-0.2937,0,-6,0,-6";
//d2 = "M5.7063,-1.8541C5.7063,-1.8541,-0.2937,-1.8541,-0.2937,-1.8541C-0.2937,-1.8541,-0.2937,2.1459,-0.2937,2.1459z";

            let path1 = paper.path(d1);
            let path2 = paper.path(d2);

            console.info(`path1: ${d1}`);
            console.info(`path2: ${d2}`);
//            try {
                let merged = paper.union(path1, path2);
                console.info(`→ merged: ${merged}`);
console.info(`<svg width="100" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="-15 -10 30 20" version="1.1" xmlns:svgjs="http://svgjs.com/svgjs" xmlns:svgjs="http://svgjs.com/svgjs"><path fill="#ffeeaa" d="M-20,-15C-20,-15,20,-15,20,-15C20,-15,20,15,20,15C20,15,-20,15,-20,15C-20,15,-20,-15,-20,-15"></path><path fill="#0F0" d="${d1}"/><path fill="#00F" d="${d2}"/><path fill="#0FF" d="${merged}"/></svg>`);
                if (merged) {
                    e.attr('d', merged);
//e.attr('fill', '#0f0');
e.attr('stroke-width', '0.1');
e.attr('stroke', '#000');
                    e.prev().remove();
                    early_exit = true;
                }
//            } catch (ex) {
//                console.info('unable to merge: ' + ex);
//            }
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
    _anchor.appendChild(canvas_holder);

    let pre = document.createElement('pre');
    let text_node = document.createTextNode(formatXml(svg_text));
    pre.appendChild(text_node);
    _anchor.appendChild(pre);
}

function handleSvg(svg) {
    _anchor = document.getElementById('anchor');
    _anchor.innerHTML = '';

    // Load clicked SVG as text
    let text = svgToText(svg);
    debugSvg('Original', text);

    text = substituteClones(text);
    debugSvg('Substitute clones', text);

    text = flattenShapes(text);
    debugSvg('Flatten shapes', text);

    text = collapseGroups(text);
    debugSvg('Collapse groups', text);

    for (let i = 0; i < 10; ++i) {
    text = mergePaths(text);
    debugSvg('Merge paths', text);
    }

    //text = flattenShapes(text);
    //_pre3.replaceData(0, -1, formatXml(text));
}

svgs = document.getElementsByTagName('svg');
for (var i = 0; i < svgs.length; ++i) {
    svgs[i].addEventListener("click", function(e) {
        var svg = e.target;
        while (svg.tagName != 'svg')
            svg = svg.parentElement;
        handleSvg(svg);
    });
}
