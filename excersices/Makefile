all:Out.txt
	cat Out.txt


Out.txt:main.exe
	mono -target:exe -out: $@ $<

main.txt:main.cs
	mcs main.cs


