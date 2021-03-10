
ALL_FLAGS = \
    openmoji/src/flags/country-flag/* \
    openmoji/src/flags/subdivision-flag/* \
    openmoji/src/flags/flag/1F3F3-FE0F-200D-26A7-FE0F.svg \
    openmoji/src/flags/flag/1F3F4-FE0F-200D-1F170-FE0F.svg

all: .allflags.js

.allflags.js: Makefile
	echo 'flags = {' > $@
	for x in $(ALL_FLAGS); do echo "'"`basename $$x | sed 's/[.]svg//'`"': '"`sed "s/'/\\\\\\\\'/g" $$x`"',"; done >> $@
	echo '}' >> $@

clean:
	rm -f .allflags.inc .allflags.js
