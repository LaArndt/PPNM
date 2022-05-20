all:Out.txt
	cat Out.txt

Out.txt:main.exe
	mono main.exe > Out.txt

main.exe:main.cs table.dll
	mcs -target:exe -r:table.dll -out:$@ $<
table.dll:table.cs
	mcs -t:library -out:$@ $<
clean:
	$(RM) *.exe *.dll [Oo]ut*.exe


