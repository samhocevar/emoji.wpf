
SVGDIR = ../Emoji.Wpf/CountryFlags/svg/

all: index.html

index.html: header.inc .allflags.inc footer.inc
	cat $^ > $@

.allflags.inc:
	echo '' > $@
	for x in `cd $(SVGDIR) && ls | grep '^.r' | grep ..`; do \
		cat "$(SVGDIR)/$$x" | sed "s/^<svg /<svg id='$$x' width='30' /" >> $@; \
	done

clean:
	rm -f index.html .allflags.inc
