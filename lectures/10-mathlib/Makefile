CSC = mcs
RUN = mono

Out.exe:main.exe
	$(RUN) $< > $@

main.exe:main.cs matlib.dll

DIR = /../../../matlib
matlib.dll: $(DIR)/integrate.cs 
	$(CSC) -target:library -out:./$@ $^


%.exe: %.cs
	$(CSC) -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	$(CSC) -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)
clean:
	rm *.pdf
