
SVGDIR = ../Emoji.Wpf/CountryFlags/svg/
SVGFILES = $(shell grep '<use' $(SVGDIR)/* | cut -f1 -d: | uniq | xargs du -sb | sort -n | head -n 60 | sed 's,.*/,,' | awk '{print $2}')
#SVGFILES = $(shell du -sb $(SVGDIR)/* | sort -n | head -n 120 | tail -n 40 | sed 's,.*/,,' | awk '{print $2}')

all: index.html

index.html: header.inc .allflags.inc footer.inc
	cat $^ > $@

.allflags.inc:
	echo '' > $@
	for x in $(SVGFILES); do \
		if [ "$$x" = "np.svg" ]; then continue; fi; \
		echo '<span margin="4">' >> $@; \
		cat "$(SVGDIR)/$$x" | sed "s/\(id=.\|url(#\|href=.#\)/&$$x./g" | \
			sed "s/xmlns=/id='$$x' margin='4' width='150' &/" >> $@; \
		echo '</span>' >> $@; \
	done

clean:
	rm -f index.html .allflags.inc
