using System;
using static System.Console;
using static System.Double;
using static System.Math;

class main{


static void Main(){
	
	int ncalls1 = 0;
	int ncalls2 = 0;
        
	//integrating some functions! // 
        Func<double,double> Sq = delegate(double x){return Sqrt(x);};

        Func<double,double> InvSq = delegate(double x){ncalls1++; return 1.0/Sqrt(x);};

        Func<double,double> Func1 = delegate(double x){return 4.0*Sqrt(1-x*x);};

        Func<double,double> Func2 = delegate(double x){ncalls2++; return Log(x)/Sqrt(x);};

        //Implementing error-function // 
        Func<double,double>erf = delegate(double x){return 2/Sqrt(PI)*Exp(-x*x);};
        for(double z=0;z<=10;z+=1.0/8){
                double Int = qt.integrate(erf,0,z);
                WriteLine($"{z} {Int}");
	}	
	Error.WriteLine("//////// Part B ////////////");
	
	

	
	Error.WriteLine("testing Clenshaw-Curtis integration and comparing with python scipy integrators");
	Func<double,double> test = delegate(double x){return x*x;};
	double TestInt = qt.CCintegrate(test,-1,1);	
	Error.WriteLine($"int(-1,1) x^2={TestInt}=2/3");	
	
	Error.WriteLine("perfoming integrals containing end-point divergencies");
	double CCinvSq = qt.CCintegrate(InvSq,0,1);
	Error.WriteLine($"int(0,-1) 1/Sqrt(x)={CCinvSq}=2, calls: {ncalls1}, python average 231");

	double CcInt = qt.CCintegrate(Func2,0,1);
	Error.WriteLine($"int(0,-1) ln(x)/sqrt(x)={CcInt}=-4, calls: {ncalls2}, python average 315");
}//Main
}//main
