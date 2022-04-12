CSC = mcs
RUN = mono

all: out.txt data.txt ODE.pdf TolErr.pdf
	cat out.txt

ODE.pdf:fig.ODE.gpi data.txt 
	pyxplot $<

TolErr.pdf:fig.TolErr.gpi data.txt
	pyxplot $<

out.txt data.txt:main.exe
	$(RUN) $< 2> out.txt 1> data.txt 

main.exe:main.cs matrix.dll rk.dll list.dll
	$(CSC) -target:exe -reference:matrix.dll -reference:rk.dll -reference:list.dll $<


rk.dll:rk.cs list.dll
	mcs -target:library -reference:matrix.dll -reference:list.dll $<

list.dll:list.cs
	mcs -target:library $<

LIBDIR= ../../../matlib
matrix.dll:\
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs 
	$(CSC) -target:library -out:./$@ $^


clean:
	rm *.dll *.exe *.pdf *.txt
