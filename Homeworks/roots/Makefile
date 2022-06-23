CSC = mcs
RUN = mono

all: out.txt data.txt 
	cat out.txt


out.txt data.txt:main.exe
	$(RUN) $< 2> out.txt 1> data.txt 

main.exe:main.cs matrix.dll QR.dll
	$(CSC) -target:exe -reference:matrix.dll -reference:QR.dll $<

QR.dll:../lineq/QRregs.cs
	mcs -target:library -reference:matrix.dll -out:./$@ $^

LIBDIR= ../../matlib
matrix.dll:\
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs 
	$(CSC) -target:library -out:./$@ $^


clean:
	rm *.dll *.exe *.pdf *.txt

