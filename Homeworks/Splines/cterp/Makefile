qterp.pdf:fig.cterp.gpi data.txt
	gnuplot $<

data.txt: main.exe
	mono $< > $@

main.exe:main.cs cspline.dll
	mcs -target:exe -out:$@ -reference:cspline.dll $<

cspline.dll:cspline.cs
	mcs -target:library -out:./$@ $^
clean:
	rm *.exe *.dll *.pdf *.txt

