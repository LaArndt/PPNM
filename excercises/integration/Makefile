CSC = mcs
RUN = mono

all: Out.integ.txt Fig.erf.png 
	cat Out.txt

Fig.erf.png: fig.erf.gpi erf.data.txt
	pyxplot $<


Out.integ.txt  erf.data.txt:main-integ.exe 
	$(RUN) $< 1> Out.txt 2>erf.data.txt

main-integ.exe:main-integ.cs matlib.dll

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

