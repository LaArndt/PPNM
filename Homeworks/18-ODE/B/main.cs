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

	WriteLine("\n\n");

	// ------------- Part B ------------------- //
	genlist<double> genx = new genlist<double>();    //object exits but contains nothing
	genlist<vector> geny = new genlist<vector>();
	
	//making ODE of Damped Oscilator once, then extracting x,y lits
	vector y_init = new vector(PI-0.1,0);
	double acc = 1e-8, eps = 1e-8; 
	vector a_sol = rk.driver(scif, 0, y_init, 10, genx, geny,0.01,acc,eps);
	for(int i=0;i<=genx.size-1;i++){
		WriteLine();
		Write($"{genx.data[i]} ");
		Write($"{geny.data[i][0]} {geny.data[i][1]}");	
	};
	Error.WriteLine("succesfully extracted x,y");
}//method Main

}//class main 
