CSC = mcs
RUN = mono

all: gamma.pdf

gamma.pdf: gamma.data.txt Makefile
	echo '\
	set terminal pdf\n\
	set output "$@" \n\
	set xlabel "Re$$(z)$$" \n\
	set ylabel "Im$$(z)$$" \n\
	set zlabel "$$|\\Gamma (z)|$$"\n\
	set title "Complex gamma function" \n\
	plot 3d [-5: 5] [-5: 5] [0: 10] "gamma.data.txt" with lines title "$$|\\Gamma(z)|$$" \n\
	'| tee log.gpi | pyxplot

gamma.data.txt: main.exe
	mono $< > $@

main.exe: main.cs cmath.dll
	mcs -target:exe -reference:cmath.dll -out:$@ $<


cmath.dll:cmath.cs complex.cs
	mcs -target:library -out:./cmath.dll $^

clean:
	rm *.gpi *.pdf *.exe *.dll
