using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public class qspline{
	
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


	public qspline(double[] x, double[]y, double z){
		
		//forward recursion
		double C = 1/(x[i+1]-x[i])
	
	
	}

public static void Main(){

	}
}
