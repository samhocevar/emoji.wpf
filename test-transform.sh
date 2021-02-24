#!/bin/bash

# Required for this tool:
# - inkscape
# - bc (packman -S bc)

calc() {
  echo "scale=10; $*" | bc
}

mkdir -p flags/tmp

SRCDIR="Emoji.Wpf/CountryFlags/svg"
PATH="/c/Program Files/Inkscape/bin:$PATH"

#for x in us $(cd "$SRCDIR" && ls *.svg | sed 's/[.]svg//'); do
for x in ba sk fr gb de be us; do
    SRC="$SRCDIR/${x}.svg"
    TMP="flags/tmp/${x}.svg"
    DST="flags/${x}.svg"

    echo "Processing: $SRC"

    # Ensure all shapes have a fill and stroke defined, or we will get artifacts
    # when bending the final path.
    sed -e 's,<svg[^>]*>,&<g fill="none" stroke="none">,; s,</svg>,</g>&,' < "$SRC" > "$TMP"

    # Query viewbox using sed, it’s a lot faster than inkscape
    read -r x y w h <<< $(cat "$TMP" | sed -ne 's/.*viewBox="\([^"]*\)".*/\1/p')
    echo "  original box $x $y $w $h"
    wscale="$(calc "230.68 / $w")"

    "/c/Program Files/Inkscape/bin/inkscape.exe" "$TMP" \
          --batch-process --actions="select-clear;
                     EditSelectAll; EditUnlinkCloneRecursive;
                     transform-translate: -${x},-${y};
                     transform-scale: $(calc "$wscale * $w - $w");
                     FitCanvasToSelection;
                     SelectionGroup;
" \
          --export-filename="$DST" 2>/dev/null

    read -r x y w h <<< $(cat "$DST" | sed -ne 's/.*viewBox="\([^"]*\)".*/\1/p')
    echo "  new box $x $y $w $h"
done

cat >/dev/null << EOF
                     EditSelectAll; ObjectToPath;
EditCopy;
file-open: flag-simple2.svg;
NextWindow;
EditPaste;
EOF
