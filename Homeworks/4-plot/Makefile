gamma.pyxplot.png: gamma.data.txt gamma.tab.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'f?' \n\
	set title 'gamma function' \n\
	plot '$<' index 0 using 1:2 with lines title 'gamma' ,\ \n\
	'gamma.tab.txt' using 1:2 with points title 'tab' \n\
	"|tee log.gpi | pyxplot

lngamma.pyxplot.png: gamma.data.txt gamma.tab.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'f?' \n\
	set title 'lngamma function' \n\
	plot '$<' index 0 using 1:3 with lines title 'gamma' ,\ \n\
	'gamma.tab.txt' using 1:3 with points title 'tab' \n\
	"|tee log.gpi | pyxplot

gamma.data.txt: main.exe
	mono $< > $@

lngamma.data.txt : lngamma.exe
	mono $< > $@
%.exe: %.cs
	mcs $<

clean:
	rm *.exe *.png
