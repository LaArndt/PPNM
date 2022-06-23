erf.pyxplot.png: erf.data.txt erf.tab.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ x $$' \n\
	set ylabel '$$ y $$' \n\
	set title 'error function' \n\
	set key left top \n\
	plot [-2:2] [-1:1] '$<' index 0 using 1:2 with lines title 'error function',\ \n\
	'erf.tab.txt' with points pointtype 3 title 'tab' \n\
	" | tee log.gpi | pyxplot

erf.data.txt: main.exe
	mono $< > $@

%.exe: %.cs
	mcs $<

clean:
	rm *.exe *.png *.gpi
