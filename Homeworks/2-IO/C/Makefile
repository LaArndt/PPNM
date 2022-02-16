all:Out.txt
	cat Out.txt

Out.txt:read.exe
	mono read.exe -input:input.txt -output:Out.txt

read.exe:read.cs
	mcs -target:exe -out:$@ $<

clean:
	$(RM) [Oo]ut* *.exe [Ll]og*
