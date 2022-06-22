using System;
using static System.Console;
using static System.Math;

public class main{
	
	public static void Main(){
	
	// Class based implementation of the Berrut spline //
	
	// making x,y data //
	double a = -6, b = 6;
	int nsteps = 15;
	double stepsize = (b-a)/(nsteps-1);

	double[] xs = new double[nsteps];
	double[] ys = new double[nsteps];
	Error.WriteLine($"{nsteps} {xs.Length}");
	WriteLine("#function data: x, y");
	for(int i=0;i<nsteps;i++){
		xs[i] = a+i*stepsize;
		ys[i] = Sin(xs[i]);

		WriteLine($"{xs[i]} {ys[i]}");
	}
	
	// Making larger z-data for interpolate //
	int n_ratio = 5;
	double[] zs = new double[n_ratio*nsteps];
	double zstep = (b-a)/(n_ratio*nsteps-1);
	for(int i=0;i<n_ratio*nsteps;i++){
		zs[i]= a+i*zstep;
	}
	
	
	// making inerpolate //
	berrut B1 = new berrut(xs,ys,zs,"B1");
	berrut B2 = new berrut(xs,ys,zs,"B2");
	
	// extracting data for plots //
	WriteLine("\n\n#Spline data: zs, b1, b2");
	for(int i=0;i<n_ratio*nsteps;i++){
		WriteLine($"{zs[i]} {B1.eval(zs[i])} {B2.eval(zs[i])}");
	}

	
	// Derivatives //
	WriteLine("\n\n#Derivative data: z, db1, db2");
	for(int i=1;i<n_ratio*nsteps;i++){
		WriteLine($"{zs[i]} {B1.deriv(zs[i])} {B2.deriv(zs[i])}");
	}
	
	}//Main method
}//main class



