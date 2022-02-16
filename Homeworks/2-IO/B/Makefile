all:Out.txt
	cat Out.txt

Out.txt:read.exe
	mono read.exe 1 2 3 4 5 >Out.txt

read.exe:read.cs
	mcs -target:exe -out:$@ $<
