function svgToText(svg) {
    var s = new XMLSerializer();
    return formatXml(s.serializeToString(svg));
}

function formatXml(xml) {
    var ret = '', indent = '';
    var tab = '  ';
    xml.split(/>\s*</).forEach(function(node) {
        if (node.match( /^\/\w/ )) indent = indent.substring(tab.length); // decrease indent by one 'tab'
        ret += indent + '<' + node + '>\r\n';
        if (node.match( /^<?\w([^>/]*|[^>]*[^/])$/ )) indent += tab;              // increase indent
    });
    ret = ret.replace( /(<[^\/>][^>]*[^\/>]>)\s*(<\/)/g, '$1$2');
    return ret.substring(1, ret.length - 3);
}

function applyToSvg(func, text) {
    let canvas_holder = document.createElement('svg');
    let canvas = SVG(canvas_holder);
    canvas.svg(text);
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

// Add implicit C node for three-point paths
function fixPath(d) {
    if (d.match(/C/g).length == 2) {
        let begin = d.replace(/M([^,MC]*,[^,MC]*)[,MC].*/, '$1');
        let end = d.replace(/.*,(.*,.*)/, '$1');
        return d + 'C' + end + ',' + begin + ',' + begin;
    }
    return d;
}

function mergePaths(svg_text) {
    let raph_tmp = document.createElement('div');
    raph_tmp.id = 'raphael_canvas';
    document.body.appendChild(raph_tmp);
    let paper = Raphael('raphael_canvas', 250, 250);

    let done = false;
    let f = function(e) {
        let prev = null;
        let todelete = [];
        for (let ch of e.children()) {
            if (done)
                break;
            if (prev && sameAttributes(prev, ch)) {
                let d1 = fixPath(prev.attr('d'));
                let path1 = paper.path(d1);
                let d2 = fixPath(ch.attr('d'));
                let path2 = paper.path(d2);
                console.info('merge!');
                console.info(d1);
                console.info(d2);
                try {
                    let merged = paper.union(path1, path2);
                    console.info(merged);
                    if (merged) {
                        ch.attr('d', merged);
                        todelete.push(prev);
                        done = true;
                    }
                } catch (ex) {
                    console.info('unable to merge: ' + ex);
                }
            } else {
                f(ch);
            }
            prev = ch;
        }
        for (let ch of todelete)
            ch.remove();
    }

    let ret = applyToSvg(f, svg_text);
    raph_tmp.remove();
    return ret;
}

function flattenShapes(svg_text) {
    let tmp = document.createElement('div');
    document.body.appendChild(tmp);
    tmp.innerHTML = svg_text;
    flatten(tmp.children[0], true, false, false, 4);
    let ret = svgToText(tmp.children[0]);
    tmp.remove();
    // Round all numbers to 4 digits
    ret = ret.replace(/[0-9]*[.]?[0-9]{4,}(e[-+]?[0-9]+)?/g, function(match, capture) {
        return (Math.round(match * 10000) / 10000).toString();
    });
    return ret;
}

function debugSvg(name, svg_text) {
    let div = document.createElement('div');
    div.innerHTML = `<h4>${name}:</h4>`;
    _anchor.appendChild(div);

    let canvas_holder = document.createElement('svg');
    let canvas = SVG(canvas_holder);
    canvas.svg(svg_text);
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

    text = mergePaths(text);
    debugSvg('Merge paths', text);

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
