using System;
using static System.Console;
using static System.Math;
using static cmath;

class main{
	public static void Main(){
	WriteLine("\nMaking some calculations using complex math (cmath.)\n manual results depicted in parantheses \n");
	// determine sqrt(-1)
	complex minusOne = new complex(-1,0);
	complex sqrtMinOne = sqrt(minusOne);
	WriteLine($"Sqrt(-1)={sqrtMinOne}	:(i)");

	//determine sqrt(i)
	complex minI = new complex(0,1);
	complex sqrtMinI = sqrt(minI);
	WriteLine($"sqrt(i)={sqrtMinI}	:(0.707+0.707i)");

	//determine e^i
	complex I = new complex(0,1);
	var ei = exp(I); 
	WriteLine($"e^i = {ei}	:(0.54+0.84i)");

	//determine e^pi
	complex iPI = I * PI;
	var eIpi = exp(iPI);
	WriteLine($"e^(i*pi)={eIpi}	:(-1)");

	//determine i^i
	complex ii = cmath.pow(cmath.I, cmath.I);
	WriteLine($"i^i = {ii}		:(1)");

	//determine ln(i)
	var lni = cmath.log(cmath.I);
	WriteLine($"ln(i) = {lni}		:(1.57i)");
	
	//determine sin(i pi)
	var sinIpi  = cmath.sin(iPI);
	WriteLine($"sin(i pi) = {sinIpi}	:(11.54i)");
	}
}
