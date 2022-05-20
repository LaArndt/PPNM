CSC = mcs
RUN = mono

all: Fig.oscillator.png oscillator.data.txt


Fig.oscillator.png: fig.oscillator.gpi oscillator.data.txt
	pyxplot $<

oscillator.data.txt: main-ode.exe
	$(RUN) $< 1> $@ 2>log

main-ode.exe: main-ode.cs matlib.dll

LIBDIR = ../../matlib
matlib.dll: \
	$(LIBDIR)/integrate/integrate.cs \
	$(LIBDIR)/odeint/ode.cs \
	$(LIBDIR)/matrix/vector.cs
	$(CSC) -target:library -out:./$@ $^
	
%.exe: %.cs
	$(CSC) -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	$(CSC) -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt log*
 
