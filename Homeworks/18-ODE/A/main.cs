using System;
using static System.Console;
using static System.Math;

public static class main{

public static void Main(){
	Error.WriteLine("main compiling");
	
	double b=0.25, c=5.0;
	Func<double,vector,vector> scif = delegate(double t, vector y){
		double theta=y[0], omega=y[1];
		return new vector(omega, -b*omega-c*Sin(theta));
	};

	Func<double,vector,vector> osc = delegate(double t, vector y){
		double ys0=y[0], ys1=y[1];
		return new vector(ys1, -ys0);
	};

	double stop = 10, start = 0, step = 1.0/16;
	vector y0 = new vector(PI-0.1,0.0);
	for(double ti = start;ti<=stop;ti+=step){
		vector ysol = rk.driver(scif,ti-step,y0,ti);
		WriteLine($"{ti} {ysol[0]} {ysol[1]}");
		y0 = ysol;
	}
	WriteLine("\n\n");
	vector yin = new vector(0,1);
	for(double ti=start;ti<=stop;ti+=step){
		vector sol = rk.driver(osc, ti-step,yin,ti);
		WriteLine($"{ti} {sol[0]} {sol[1]}");
		yin = sol;
	}

	WriteLine("\n\n");
	vector yan = new vector(1,0);
	for(double ti=start;ti<=stop;ti+=step){
		vector sol = rk.driver(osc, ti-step,yan,ti);
		WriteLine($"{ti} {sol[0]} {sol[1]}");
		yan = sol;
	}



	Error.WriteLine("driver succesfully executed");	

}//method Main

}//class main 
