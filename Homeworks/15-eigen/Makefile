CSC = mcs
RUN = mono

all: Out.txt
	cat Out.txt

Out.txt:main.exe
	$(RUN) $< > $@
	
main.exe:main.cs matrix.dll QRregs.dll jacobi.dll
	$(CSC) -target:exe -reference:matrix.dll -reference:QRregs.dll -reference:jacobi.dll $<

QRregs.dll:../13-lineq/QRregs.cs
	mcs -target:library -reference:matrix.dll -out:./$@ $^

jacobi.dll:jacobi.cs
	mcs -target:library -reference:matrix.dll -out:./$@ $^

LIBDIR= ../../matlib
matrix.dll:\
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs 
	$(CSC) -target:library -out:./$@ $^


clean:
	rm *.dll *.exe *.pdf
