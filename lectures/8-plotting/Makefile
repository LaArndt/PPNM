erf.pyxplot.png: erf.data.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'error function' \n\
	plot '$<' index 0 using 1:2 with lines title 'error function' \n\
	"| tee log.gpi | pyxplot

erf.data.txt: main.exe
	mono $< > $@

%.exe: %.cs
	mcs $<

clean:
	rm *.exe *.png *.gpi
