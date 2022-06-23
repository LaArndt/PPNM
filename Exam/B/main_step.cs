using System;
using static System.Console;
using static System.Math;

public class main{
	public static double step_func(double x){ if(x<0)return 0; else return 1;}
	public static void Main(){
	Error.WriteLine("Class implementation of the berrut spline \nObject stores original function aswell as spline allowing for easy differentaion and integration \nhigher order differentials are achieved by constructing a new object spline based on the derivatives. Runge effects do not remain supressed when taking higher order differentials");	
	// Class based implementation of the Berrut spline //
	
	// making x,y data //
	double a = -6, b = 6;
	int nsteps = 15;
	double stepsize = (b-a)/(nsteps-1);

	double[] xs = new double[nsteps];
	double[] ys = new double[nsteps];
	
	WriteLine("#function data: x, y");
	for(int i=0;i<nsteps;i++){
		xs[i] = a+i*stepsize;
		ys[i] = step_func(xs[i]);
		
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
		WriteLine($"{B1.deriv().Item1[i]} {B1.deriv().Item2[i]} {B2.deriv().Item2[i]}");
	}

	// Integral // 
	WriteLine("\n\n#Integral Data: x,y");
	
	(double[] X, double[] F) = B1.integ();
	
	for(int i=1;i<n_ratio*nsteps-1;i++){
		WriteLine($"{X[i]} {F[i]}");
	}






/*	
	// second derivatives //
	WriteLine("\n\n#2derivatives: x, y");

	(double[] dx, double[] dy) =  B1.deriv();
	berrut dB1 = new berrut(dx,dy,zs,"B1");
	(double[] d2x, double[] d2y) = dB1.deriv();
	for(int i=1;i<n_ratio*nsteps;i++){
		WriteLine($"{d2x[i]} {d2y[i]}");
	}

	// Third derivative //
	WriteLine("\n\n#3rd derivatives");
	berrut ddB1 =  new berrut(d2x,d2y,zs);
	(double[] d3x, double[] d3y) = ddB1.deriv();
	for(int i=1;i<n_ratio*nsteps;i++){
		WriteLine($"{d3x[i]} {d3y[i]}");
	}
*/
	 




	
		
	}//Main method
}//main class



