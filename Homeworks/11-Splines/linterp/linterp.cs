using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public class linspline{
	
	public static double linterp(double[] x, double[] y, double z){
			int i=binsearch(x,z);
			double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
			double dy=y[i+1]-y[i];
			return y[i]+dy/dx*(z-x[i]);
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


public static void Main(){
	//read data from txt.file, fill arrays
	/* var xs = new List<string>();
	var ys = new List<string>();	

	var lines = System.IO.File.ReadAllLines("erf.data.txt");
	foreach(var line in lines){
		var values = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
	xs.Add(values[0]);
	ys.Add(values[1]);
	}
	for(double z=xs[0];z<=xs[xs.Count-1];z+=1/8){
		double terp = linterp(xs, ys, z);
		WriteLine($"{z} {terp}");
			
	}*/
	double[] x = new double[]{1,3,8,9,11,13,15};
	double[] y = new double[]{8,6,11,15,9,5,3};
	for(double z=x[0];z<=x[x.Length-1];z+=1){
		double terp = linterp(x,y,z);
		WriteLine($"{z} {terp}");
		}
	

	}
}
