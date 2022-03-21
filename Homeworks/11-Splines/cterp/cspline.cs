using static System.Math;
using System;
using static System.Console;

public class cspline{
	public readonly double[] x,y,b,c,d;

	public cspline(double[] xs, double[] ys){
		this.x = xs;
		this.y = ys;
		int n=x.Length;
		this.b = new double[n];
		this.c = new double[n-1];
		this.d = new double[n-1];	

		double[] p = new double[n-1];
		double[] h = new double[n-1];

		for(int i=0;i<n-1;i++){
			h[i] = x[i+1]-x[i];
			p[i] = (y[i+1]-y[i])/h[i];
		}
		
		double[] D = new double[n];
		double[] Q = new double[n-1];
		double[] B = new double[n];

		D[0] = 2;
		for(int i=0;i<n-2;i++){
			D[i+1] = 2*h[i]/h[i+1] + 2;
			D[n-1] = 2;
		}

		Q[0] = 1;
		for(int i=0;i<n-2;i++){
			Q[i+1] = h[i]/h[i+1];
		}

		for(int i=0;i<n-2;i++){
			B[i+1] = 3*(p[i]+p[i+1]*h[i]/h[i+1]);
		}

		B[0] = 3*p[0];
		B[n-1] = 3*p[n-2];

		for(int i=1;i<n;i++){
			D[i] -= Q[i-1]/D[i-1];
			B[i] -= B[i-1]/D[i-1];
		}

		b[n-1] = B[n-1]/D[n-1];
		for(int i=n-2;i>=0;i--){
			b[i] = (B[i]-Q[i]*b[i+1])/D[i];
		}


		for(int i=0;i<n-1;i++){
			c[i]=(-2*b[i]-b[i+1]+3*p[i])/h[i];
			d[i]=(b[i]+b[i+1]-2*p[i])/h[i]/h[i];
		}	
	}

	public static int binsearch(double[] x, double z){
	/* locates the interval for z by bisection */ 
	if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
	int i=0, j=x.Length-1;
	while(j-i>1){
		int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
	return i;
	}

	public double eval(double z){
		int i = binsearch(x,z);
		double h = z-x[i];
		return y[i] + b[i]*h + c[i]*h*h + d[i]*h*h*h;
	
	}


	public double deriv(double z){
		int i = binsearch(x,z);
		double h = z-x[i];
		return b[i] + 2.0*c[i]*h + 3.0*d[i]*h*h;
	
	}

	public double integ(double z){
		int idx = binsearch(x,z);
		double h = 0;
		double sum = 0;
		for(int i=0;i<idx;i++){
			h = x[i+1]-x[i];
			sum+=y[i]*h + b[i]*h*h/2 + c[i]*h*h*h/3 + d[i]*h*h*h*h/4;
		}
		h=z-x[idx];
		sum+=y[idx]*h + b[idx]*h*h/2 + c[idx]*h*h*h/3 + d[idx]*h*h*h*h/4;
		return sum;
	}


}
















