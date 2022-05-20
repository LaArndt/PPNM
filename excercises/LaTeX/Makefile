CSC = mcs
RUN = mono

all:ms.pdf

ms.pdf:ms.tex ex_pyx.pdf
	pdflatex $<
	pdflatex $<
#	bibtex $<
#	pdflatex $<

ex_pyx.pdf:fig.pyxplot.gpi out.ex.txt tab.ex.txt
	pyxplot $<

out.ex.txt:main.exe
	$(RUN) $< > $@

main.exe: main.cs sfuns.dll

%.exe: %.cs
	$(CSC) -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	$(CSC) -t:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)
clean:
	rm *.pdf *.exe *.dll ms.aux ms.log
