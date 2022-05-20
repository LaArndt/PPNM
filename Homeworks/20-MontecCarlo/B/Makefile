CSC = mcs
RUN = mono

all: out.txt data.txt 
	cat out.txt


out.txt data.txt:main.exe
	$(RUN) $< 2> out.txt 1> data.txt 

main.exe:main.cs matrix.dll integrate.dll mc.dll
	$(CSC) -target:exe -reference:matrix.dll -reference:integrate.dll -reference:mc.dll $<

mc.dll:mc.cs integrate.dll matrix.dll
	mcs -target:library -reference:matrix.dll -reference:integrate.dll $<

integrate.dll:../../19-quadratures/quadrature.cs
	mcs -target:library -out:./$@ $^

LIBDIR= ../../../matlib
matrix.dll:\
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs 
	$(CSC) -target:library -out:./$@ $^


clean:
	rm *.dll *.exe *.pdf *.txt

