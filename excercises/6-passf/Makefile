all:Out.txt
	cat Out.txt

Out.txt:main.exe
	mono main.exe > Out.txt

main.exe:main.cs
	mcs -target:exe -out:$@ $<

clean:
	$(RM) *.exe *.dll [Oo]ut*.exe


