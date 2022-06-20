using System;
using static System.Console;
using static System.Math;

public class main{
	
	public static void Main(){

	double[] xs = new double[]{0,0.3,0.6,0.9,1.5,1.8,2.7,3.0,3.3,4.2,4.5,5.1,5.4,6.3,6.6,6.9};
	int n = xs.Length;
	double[] ys = new double[n];
	double[] y2s = new double[n];


	Func<double,double> fun = delegate(double x){return 1.0/16*x*x;};
	for(int i=0;i<=n-1;i++){
		ys[i]=Sin(xs[i]);
		y2s[i]=fun(xs[i]);
		WriteLine($"{xs[i]} {ys[i]} {y2s[i]}");



	}
	
	Error.WriteLine("#######################Output##############################");	
	Error.WriteLine("#Made berrut interpolant based both on the B1 and B2 methods described in the lectures"); 
	Error.WriteLine(" Current test based on the sine function in the range of roughly 2PI");
	
	
	double step = 1.0/8;
	
	
	WriteLine("\n\n#Berrut B1 spline data");
	double test = berrut.B1(xs,ys,5.2);
	Error.WriteLine($"#test of berrut B1 method for z=5.2, h={test}");	
	for(double z=0.01;z<=xs[n-1];z+=step){
		double h = berrut.B1(xs,ys,z);
		double h2  = berrut.B1(xs,y2s,z);
		WriteLine($"{z} {h} {h2}");
	
	}



	double test2 = berrut.B2(xs,ys,5.2);
	Error.WriteLine($"#test of berrut B2 method for z=5.2, h={test2}");
	WriteLine("\n\n#Berrut B2 data");
	for(double z=0.01;z<=xs[n-1];z+=step){
		double h = berrut.B2(xs,ys,z);
		double h2  = berrut.B2(xs,y2s,z);
		WriteLine($"{z} {h} {h2}");
	}


	double test3 = berrut.B_split(xs,ys,5.2);
	Error.WriteLine($"test of split berrut for z=5.2, h={test3}");
	 WriteLine("\n\n#Berrut Bsplit data");
        for(double z=0.01;z<=xs[n-1];z+=step){
                double h = berrut.B_split(xs,ys,z);
                double h2  = berrut.B_split(xs,y2s,z);
                WriteLine($"{z} {h} {h2}");
	}
	}//Main method
}//main class



