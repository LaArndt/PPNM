using System;
using static System.Math;
using static System.Console;

public class table{
	//Maketable method
	public static void make_table10(System.Func<double,double> f){
		for(double x=0;x<=10;x+=1)WriteLine($"{x}, {f(x)} ");
		}
		
	//Method for constructing table with given a,b,dx
	public static void make_table(System.Func<double,double> f, double a, double b, double dx){
		WriteLine($"for a={a}, b={b}, dx={dx}");
		for(double x=a;x<=b;x+=dx)WriteLine($"{x}, {f(x)}");
		}
	
	
}
