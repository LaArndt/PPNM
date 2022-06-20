CSC = mcs
RUN = mono

all: Out.txt 
	cat Out.txt

Out.txt:main.exe
	$(RUN) $< 1> $@

Data.txt:main.exe
	$(RUN) $< 2> $@

main.exe:main.cs matrix.dll jacobi.dll
	$(CSC) -target:exe -reference:matrix.dll -reference:jacobi.dll $<

jacobi.dll:jacobi.cs
	mcs -target:library -reference:matrix.dll -out:./$@ $^

LIBDIR= ../../../matlib
matrix.dll:\
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs 
	$(CSC) -target:library -out:./$@ $^


clean:
	rm *.dll *.exe *.pdf *.txt
