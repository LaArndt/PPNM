all: out.txt 
	cat out.txt

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
