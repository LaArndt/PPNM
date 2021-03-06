using System;
using static System.Console;
using static System.Double;
using static System.Math;

class main{


static void Main(){

	Error.WriteLine("/////////////////// Part A ///////////////");
	Error.WriteLine("making some integrals");
	//integrating some functions! // 
	Func<double,double> Sq = delegate(double x){return Sqrt(x);};

	double IntSq = qt.integrate(Sq,0,1);
	Error.WriteLine($"int(0,1) Sqrt(x)= {IntSq} =2/3");
	
	Func<double,double> InvSq = delegate(double x){return 1.0/Sqrt(x);};
	double IntInvSq = qt.integrate(InvSq,0,1);
	Error.WriteLine($"int(0,1) 1/Sqrt(x)= {IntInvSq} =2");

	Func<double,double> Func1 = delegate(double x){return 4.0*Sqrt(1-x*x);};
	double IntFunc1 = qt.integrate(Func1,0,1);
	Error.WriteLine($"int(0,1) 4sqrt(1-x²)= {IntFunc1} =pi");
	
	Func<double,double> Func2 = delegate(double x){return Log(x)/Sqrt(x);};
	double IntFunc2 = qt.integrate(Func2,0,1);
	Error.WriteLine($"int(0,1) ln(x)/sqrt(x)= {IntFunc2} =-4");

	//Implementing error-function // 
	Func<double,double>erf = delegate(double x){return 2/Sqrt(PI)*Exp(-x*x);};
	for(double z=0;z<=10;z+=1.0/8){
		double Int = qt.integrate(erf,0,z);
		WriteLine($"{z} {Int}");
	}
	
}//Main
}//main
