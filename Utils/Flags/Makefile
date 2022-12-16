# Standard Unicode flags
ALL_FLAGS := $(wildcard openmoji/src/flags/country-flag/*.svg)
ALL_FLAGS += $(wildcard openmoji/src/flags/subdivision-flag/*.svg)
ALL_FLAGS += $(wildcard openmoji/src/extras-unicode/subdivision-flag/*.svg)

# Add transgender and anarchist flags
ALL_FLAGS += openmoji/src/flags/flag/1F3F3-FE0F-200D-26A7-FE0F.svg
ALL_FLAGS += openmoji/src/extras-openmoji/flags/1F3F4-FE0F-200D-1F170-FE0F.svg

# Remove flags we do not want (German cities and American states)
REMOVE_FLAGS = \
    openmoji/src/extras-unicode/subdivision-flag/1F3F4-E0064-E0065-E0062-E0065-E007F.svg \
    openmoji/src/extras-unicode/subdivision-flag/1F3F4-E0064-E0065-E0062-E0079-E007F.svg \
    openmoji/src/extras-unicode/subdivision-flag/1F3F4-E0075-E0073-E0063-E0061-E007F.svg \
    openmoji/src/extras-unicode/subdivision-flag/1F3F4-E0075-E0073-E0074-E0078-E007F.svg

all: .allflags.js

.allflags.js: Makefile
	echo 'flags = {' > $@
	for x in $(filter-out $(REMOVE_FLAGS), $(ALL_FLAGS)); do \
	    echo "'$$x': '"`sed "s/'/\\\\\\\\'/g" $$x`"',"; \
	done >> $@
	echo '};' >> $@
	echo 'openmoji = ' >> $@
	sed 's/^  *//' openmoji/data/openmoji.json | tr -d '\r\n' >> $@
	echo ';' >> $@

clean:
	rm -f .allflags.js
