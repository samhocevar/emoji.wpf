
SVGDIR = openmoji/src/flags/country-flag
SVGFILES = $(shell grep '<use' $(SVGDIR)/* | cut -f1 -d: | uniq | xargs du -sb | sort -n | head -n 60 | sed 's,.*/,,' | awk '{print $2}')
#SVGFILES = $(shell du -sb $(SVGDIR)/* | sort -n | head -n 120 | tail -n 40 | sed 's,.*/,,' | awk '{print $2}')

all: .allflags.js

.allflags.js: Makefile
	echo 'flags = {' > $@
	for x in $(SVGDIR)/*; do echo "'"`basename $$x`"': '"`sed "s/'/\\\\\\\\'/g" $$x`"',"; done >> $@
	echo '}' >> $@

clean:
	rm -f .allflags.inc .allflags.js
