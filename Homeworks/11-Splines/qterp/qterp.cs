using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public class qspline{
	
	public double[] x,y,p,c;

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


	public qspline(double[] x, double[] y){
		this.x=x;
		this.y=y;
		int n=x.Length;
		c = new double[n-1];
		p = new double[n-1];
		
		// making pi = dy/dx //
		for(int i=0;i<n-1;i++){
			double dy=y[i+1]-y[i];
			double dx=x[i+1]-x[i];
			p[i]=dy/dx;
		}
		//making ci //
		//Forward Recursion//
		c[0] = 0;
		for(int i=0;i<n-2;i++){
			double dxi=x[i+1]-x[i];
			double dxi1=x[i+2]-x[i+1];
			c[i+1]=(p[i+1]-p[i]-c[i]*dxi)/dxi1;
			}
		//Backwards Recursion//
		c[n-2]/=2;
		for(int i=n-3;i>=0;i--){
			double dxi=x[i+1]-x[i];
			double dxi1=x[i+2]-x[i+1];
			c[i]=(p[i+1]-p[i]-c[i+1]*dxi1)/dxi;
		}
	}
       public double eval(double z){
       		int i =  binsearch(x,z);
		double h = z-x[i];
		double bi = p[i]-c[i]*(x[i+1]-x[i]);
		double result = y[i]+bi*h+c[i]*h*h;
		return result;
       	
       }	

	public double deriv(double z){
		int i = binsearch(x,z);
		double h = z-x[i];
		
		double bi = p[i]-c[i]*(x[i+1]-x[i]);
		return bi+2.0*c[i]*h;	
	}

	public double integ(double z){ 
		
		int idx = binsearch(x,z);

		double bidx= p[idx]-c[idx]*(x[idx+1]-x[idx]);
		double sum = 0;
		double h=0;
		
		for(int i=0;i<idx;i++){
			h= x[i+1]-x[i];
			double bi = p[i]-c[i]*(x[i+1]-x[i]);
			sum += y[i]*h + bi*h*h/2 + c[i]*h*h*h/3;
		}

		h = z - x[idx];
		sum += y[idx]*h+bidx*h*h/2+c[idx]*h*h*h/3;
		return sum;
	}


}
class main{
	static void Main(){
		double[] x = new double[]{0,0.4,0.8,1.2,1.6,2.0,2.4,2.8,3.2,3.6,4.0,4.4,4.8,5.2,5.6,6.0,6.4};
		double[] y = new double[x.Length];
		for(int i=0;i<=x.Length-1;i++)y[i]=Sin(x[i]);
		qspline q = new qspline(x,y);

		for(double z=x[0];z<=x[x.Length-1];z+=1.0/128){
			WriteLine($"{z} {q.eval(z)} {q.deriv(z)} {q.integ(z)}");
			}	
		}



}
