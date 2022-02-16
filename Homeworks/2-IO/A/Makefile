all:Out.txt
	cat Out.txt

Out.txt:read.exe 
	echo 1 2 3 4 5| mono read.exe > $@

cmdOut.txt:cmdread.exe
	mono cmdread.exe 1 2 3 4 5 > $@

read.exe:read.cs
	$(CSC) -target:exe -out:$@ $<






