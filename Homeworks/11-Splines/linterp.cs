using System;
using static System.Console;
using static System.Math;

class linterp{

	public double linterp(double[] x, double[] y, double z){
	
		int n = x.Length;
		int i=0, j=n-1;
		while (j-i>1){int m=(i+j)/2; if (z>x[m]) i=m; else j=m;};
		double dy = y[i+1]-y[i], dx=x[i+1]-x[i]; 
		return y[i]+dy/dx*(z-x[i]);
	
	}

	public double integrate(double[] x, double[] y, double z){
		
		int n = x.Length;
		double integral = 0;
		for(int i;i<=n;i++)
			pi = (y[i+1]-y[i])/(x[i+1]-x[i]);
			splint = y[i]*(x[i+1]-x[i]) + pi*(x[i+1]-x[i])*(x[i+1]-x[i])/2;	
			integral + splint;
	
	
	}

}
