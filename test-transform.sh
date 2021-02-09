#!/bin/bash

set -x

# Required for this tool:
# - inkscape
# - rsvg-convert (pacman -S mingw-w64-x86_64-librsvg)

PATH="$PATH:/c/Program Files/Inkscape/bin"

for x in us gb fr sk sv; do
    SRC="Emoji.Wpf/CountryFlags/svg/${x}.svg"
    DST="${x}_mod.svg"
    #read -r x y w h <<< $(cat "$SRC" | sed -ne 's/.*viewBox="\([^"]*\)".*/\1/p')
    "/c/Program Files/Inkscape/bin/inkscape.exe" --query-all "$SRC" 
    #echo "$x $y $w $h"
    #w2=23.068
    #w2=23068
    #h2="$(echo 23.5284 '*' $h / $w '*' 1000 | bc | sed 's/[.].*//')"
    "/c/Program Files/Inkscape/bin/inkscape.exe" "$SRC" \
          --batch-process --export-filename="$DST" --actions='select-all;
                     SelectionUnGroup;SelectionUnGroup;SelectionUnGroup;SelectionUnGroup;SelectionUnGroup;
                     ObjectToPath;StrokeToPath;
                     SelectionGroup'
done

