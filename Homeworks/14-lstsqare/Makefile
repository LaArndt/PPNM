CSC = mcs
RUN = mono

all: Out.txt lstsquare.pdf
	cat Out.txt

lstsquare.pdf:fig.lstsquare.gpi Out.txt Makefile
	pyxplot $<

Out.txt:main.exe
	$(RUN) $< > $@
	
main.exe:main.cs matrix.dll QRregs.dll lstsquare.dll
	$(CSC) -target:exe -reference:matrix.dll -reference:QRregs.dll -reference:lstsquare.dll $<

QRregs.dll:../13-lineq/QRregs.cs
	mcs -target:library -reference:matrix.dll -out:./$@ $^

lstsquare.dll:lstsquare.cs
	mcs -target:library -reference:matrix.dll -reference:QRregs.dll $<

LIBDIR= ../../matlib
matrix.dll:\
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs 
	$(CSC) -target:library -out:./$@ $^


clean:
	rm *.dll *.exe *.pdf
