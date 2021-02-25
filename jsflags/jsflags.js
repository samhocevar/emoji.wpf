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
function resolveClones(svg_text) {
    let ids = {}
    let f = function(e) {
        if (e.type == 'use') {
            let tid = e.attr('xlink:href').replace('#','');
            let clone = ids[tid].clone();
            for (let attr in e.attr())
                if (attr != 'xlink:href')
                    clone.attr(attr, e.attr(attr));
            clone.attr('id', null);
            e.replace(clone);
        } else if (e.node.id && e.type != 'svg') {
            ids[e.node.id] = e;
            e.attr('id', null);
        }
        for (let e2 of e.children())
            f(e2, ids);
    }
    let _draw = SVG('#canvas')
    _draw.clear();
    _draw.svg(svg_text);
    f(_draw);
    return _draw.children()[0].svg();
}

function flattenShapes(svg_text) {
    let tmp = document.getElementById('tmp');
    tmp.innerHTML = svg_text;
    flatten(tmp.children[0], true, false, false, 4);
    let ret = '' + tmp.InnerHTML;
    tmp.innerHTML = '';
    return ret;
}

var _pre1 = document.createTextNode('');
var _pre2 = document.createTextNode('');
var _pre3 = document.createTextNode('');

document.getElementById('pre1').appendChild(_pre1);
document.getElementById('pre2').appendChild(_pre2);
document.getElementById('pre3').appendChild(_pre3);

function handleSvg(svg) {
    let text = svgToText(svg);
    _pre1.replaceData(0, -1, text);

    text = flattenShapes(text);
    _pre2.replaceData(0, -1, formatXml(text));

    text = resolveClones(text);
    _pre3.replaceData(0, -1, formatXml(text));

    text = flattenShapes(text);
    _pre3.replaceData(0, -1, formatXml(text));
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
