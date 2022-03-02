using System;
using static System.Math;
using static System.Console;

class main{
	//Maketable method
	static void make_table10(System.Func<double,double> f){
		for(double x=0;x<=10;x+=1)WriteLine($"{x}, {f(x)} ");
		}
		
	//Method for constructing table with given a,b,dx
	static void make_table(System.Func<double,double> f, double a, double b, double dx){
		WriteLine($"for a={a}, b={b}, dx={dx}");
		for(double x=a;x<=b;x+=dx)WriteLine($"{x}, {f(x)}");
		}
	
	

	//Main execution
	public static void Main(){
	
	//delegate functions	
	System.Func<double,double> square = delegate(double x){return x*x;};
	System.Func<double,double> sin = delegate(double x){return Sin(x);};
	System.Func<double,double> sin2 = delegate(double x){return Sin(2*x);};
	System.Func<double,double> sin3 = delegate(double x){return Sin(3*x);};
	
	WriteLine("\nsin(x) function");
	make_table(sin, 0, 10, 1);

	WriteLine("\nsin(2x) function");
	make_table(sin2, 0, 10, 1);

	WriteLine("\nsin(3x) function");
	make_table(sin3, 0, 10, 1);
	}
}

