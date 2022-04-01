CSC = mcs
RUN = mono


all:Out.txt
	cat Out.txt

Out.txt:main.exe
	$(RUN) $< > $@

main.exe:main.cs matrix.dll QRregs.dll 
	$(CSC) -target:exe -reference:matrix.dll -reference:QRregs.dll $<

LIBDIR= ../../matlib
matrix.dll:\
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs 
	$(CSC) -target:library -out:./$@ $^

QRregs.dll:QRregs.cs
	mcs -target:library -reference:matrix.dll $<


clean:
	rm *.dll *.exe
