
all:out.txt data.txt interp.pdf
	cat out.txt


interp.pdf:fig.berrut.gpi 
	pyxplot $<

out.txt:main.exe
	mono $< 2> $@

data.txt:main.exe
	mono $< 1> $@

main.exe:main.cs berrut.dll
	mcs $< -r:berrut.dll

berrut.dll:berrut.cs
	mcs $< -t:library

clean:
	rm *.txt *.dll *.pdf *.exe
