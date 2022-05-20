using System;
using static System.Math;
using static System.Console;

class main{
	//Main execution
	public static void Main(){
	WriteLine("checking the passing of functions using delegates of sin(kx)");	
	//delegate functions	
	System.Func<double,double> square = delegate(double x){return x*x;};
	
	for(int k=1;k<=3;k++){
	System.Func<double,double> sink = delegate(double x){return Sin(k*x);};

	WriteLine($"\nsin({k}x) function");
	table.make_table(sink, 0, 10, 1);

		}
	}
}

