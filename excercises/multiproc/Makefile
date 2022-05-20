CSC = mcs
RUN = mono

all:Out.txt
	cat $<

Out.txt: t2.exe t1.exe Makefile main.exe
	cat /dev/null > $@
	/bin/time -p $(RUN) t1.exe >> $@
	/bin/time -p $(RUN) t2.exe >> $@
	/bin/time -p $(RUN) main.exe >> $@

t2.exe: t2.cs
	$(CSC) -target:exe -out:$@ $<

t1.exe: t1.cs
	$(CSC) -target:exe -out:$@ $<

main.exe:main.cs
	$(CSC) -target:exe -out:$@ $<
clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*
