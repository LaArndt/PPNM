all: Out.txt
	cat $<

Out.txt : math.exe
	mono $< > $@


math.exe : math.cs
	mcs math.cs
clean:
	rm *.exe *.dll *.txt
