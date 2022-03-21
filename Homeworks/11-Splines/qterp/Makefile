qterp.pdf:fig.qterp.gpi spline.txt points.txt
	pyxplot $<

spline.txt:qterp.exe
	mono $< > $@

points.txt:points.exe
	mono $< > $@



qterp.exe:qterp.cs
	mcs $<

points.exe:points.cs
	mcs $<

	
clean:
	rm *.exe *.txt *.pdf
