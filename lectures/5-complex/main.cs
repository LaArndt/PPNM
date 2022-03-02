using System;
using static System.Console;
using static System.Math;
using static cmath;

class main{
	public static void Main(){
	WriteLine("\nMaking some calculations using complex math (cmath.)\n");
	// determine sqrt(-1)
	complex minusOne = new complex(-1,0);
	complex sqrtMinOne = sqrt(minusOne);
	WriteLine($"Sqrt(-1)={sqrtMinOne}");

	//determine sqrt(i)
	complex minI = new complex(0,-1);
	complex sqrtMinI = sqrt(minI);
	WriteLine($"sqrt(-i)={sqrtMinI}");

	//determine e^i
	complex I = new complex(0,1);
	var ei = exp(I); 
	WriteLine($"e^i = {ei}");

	//determine e^pi
	complex iPI = I * PI;
	var eIpi = exp(iPI);
	WriteLine($"e^(i*pi)={eIpi}");

	//determine i^i
	complex ii = cmath.pow(cmath.I, cmath.I);
	WriteLine($"i^i = {ii}");

	//determine ln(i)
	var lni = cmath.log(cmath.I);
	WriteLine($"ln(i) = {lni}");
	
	//determine sin(i pi)
	var sinIpi  = cmath.sin(iPI);
	WriteLine($"sin(i pi) = {sinIpi}");
	}
}
