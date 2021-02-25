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
        if (node.match( /^<?\w[^>]*[^\/]$/ )) indent += tab;              // increase indent
    });
    ret = ret.replace( /(<[^\/>][^>]*[^\/>]>)\s*(<\/)/g, '$1$2');
    return ret.substring(1, ret.length - 3);
}

// Replace all <use> tags with their targets. Source: SVG.js document.
function substituteClones(svg_text) {
    let ids = {}
    let f = function(e) {
        if (e.type == 'use') {
            let tid = e.attr('xlink:href').replace('#','');
            let clone = ids[tid].clone();
            clone.attr('id', null);
            let g = _draw.group();
            g.add(clone);
            for (let attr in e.attr()) {
                let val = e.attr(attr);
                // See kr.svg: <use ... y="44"/>
                if (attr == 'x')
                    g.translate(val, 0);
                else if (attr == 'y')
                    g.translate(0, val);
                else if (attr != 'xlink:href')
                    g.attr(attr, val);
            }
            e.replace(g);
        } else if (e.node.id && e.type != 'svg' && e.type != 'clipPath') {
            ids[e.node.id] = e;
            e.attr('id', null);
        }
        for (let e2 of e.children())
            f(e2, ids);
    }
    var _draw = SVG('#canvas')
    _draw.clear();
    _draw.svg(svg_text);
    f(_draw);
    return _draw.children()[0].svg();
}

function collapseGroups(svg_text) {
    let f = function(e) {
        for (let e2 of e.children())
            f(e2);
        if (e.type == 'g' && e.node.attributes.length == 0)
            e.ungroup();
    }
    var _draw = SVG('#canvas')
    _draw.clear();
    _draw.svg(svg_text);
    f(_draw);
    return _draw.children()[0].svg();
}

function flattenShapes(svg_text) {
    let tmp = document.getElementById('tmp');
    tmp.innerHTML = svg_text;
    flatten(tmp.children[0], true, false, false, 4);
    let ret = svgToText(tmp.children[0]);
    tmp.innerHTML = '';
    return ret;
}


function debugSvg(name, svg_text) {
    let anchor = document.getElementById('anchor');

    let div = document.createElement('div');
    div.innerHTML = `<h4>${name}:</h4>`;
    anchor.appendChild(div);

    let canvas_holder = document.createElement('svg');
    let canvas = SVG(canvas_holder);
    canvas.svg(svg_text);
    anchor.appendChild(canvas_holder);

    let pre = document.createElement('pre');
    let text_node = document.createTextNode(formatXml(svg_text));
    pre.appendChild(text_node);
    anchor.appendChild(pre);
}

function handleSvg(svg) {
    let anchor = document.getElementById('anchor');
    anchor.innerHTML = '';

    // Load clicked SVG as text
    let text = svgToText(svg);

    debugSvg('Original', text);

    text = substituteClones(text);
    debugSvg('Substitute clones', text);

    text = flattenShapes(text);
    debugSvg('Flatten shapes', text);

    text = collapseGroups(text);
    debugSvg('Collapse groups', text);

    //_pre2.replaceData(0, -1, formatXml(text));
    //let canvas3 = SVG('#canvas3');
    //canvas3.clear();
    //canvas3.svg(text);

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
