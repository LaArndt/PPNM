
all:out.txt data.txt interp.pdf step.pdf data_step.txt
	cat out.txt


interp.pdf:fig.berrut.gpi data.txt
	pyxplot $<

step.pdf:fig.step.gpi data_step.txt
	pyxplot $<

out.txt:main.exe
	mono $< 2> $@

data.txt:main.exe
	mono $< 1> $@

data_step.txt:main_step.exe
	mono $< 1> $@

main_step.exe:main_step.cs
	mcs $< -r:berrut.dll

main.exe:main.cs berrut.dll
	mcs $< -r:berrut.dll

berrut.dll:berrut.cs
	mcs $< -t:library

clean:
	rm *.txt *.dll *.pdf *.exe
