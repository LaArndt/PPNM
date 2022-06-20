all: out.txt data.txt erf.pdf
	cat out.txt

erf.pdf:fig.erf.gpi
	pyxplot $<

out.txt:main.exe
	mono $< 2> out.txt

data.txt:main.exe
	mono $< 1> data.txt

main.exe:main.cs quadrature.dll
	mcs -target:exe -reference:quadrature.dll $<

quadrature.dll:quadrature.cs
	mcs -target:library $<

clean:
	rm *.exe *.dll *.txt
