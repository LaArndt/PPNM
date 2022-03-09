all: test.txt
	cat test.txt

test.txt:main.exe
	mono main.exe > test.txt

main.exe:main.cs 
	mcs main.cs

clean:
	rm *.exe *.dll test.txt
