linterp.pdf:fig.linterp.gpi spline.txt points.txt
	pyxplot $<

spline.txt:linterp.exe
	mono linterp.exe > spline.txt

linterp.exe:linterp.cs 
	mcs linterp.cs

points.txt:points.exe
	mono $< > $@

points.exe:points.cs
	mcs $<

clean:
	rm *.exe *.txt *.pdf
