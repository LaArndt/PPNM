CSC = mcs
RUN = mono

all:ms.pdf

ms.pdf:ms.tex gamma_pyx.pdf
	pdflatex $<
	pdflatex $<
	#bibtex $<
	#pdflatex $<

gamma_pyx.pdf:fig.pyxplot.gpi out.gamma.txt tab.gamma.txt
	pyxplot $<

out.gamma.txt:main.exe
	$(RUN) $< > $@

main.exe:main.cs sfuns.dll

%.exe: %.cs
	$(CSC) -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	$(CSC) -t:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)
clean:
	rm *.pdf
