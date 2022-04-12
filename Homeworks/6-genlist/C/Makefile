all:Out.txt
	cat $<

Out.txt: main.exe
	mono main.exe > Out.txt
main.exe:main.cs list.dll
	mcs -target:exe -out:$@ -reference:list.dll $<

list.dll:list.cs node.cs
	mcs $^ -target:library -out:$@ $<

clean:
	rm *.dll *.exe [oO]ut* [Ll]og*
