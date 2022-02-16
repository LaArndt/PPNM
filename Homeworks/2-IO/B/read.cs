using System;
using System.IO;
using static System.Math;
using static System.Console;

class main{	
	public static void Main(string[] args){
		WriteLine("Iteration B");
		foreach(var arg in args){
		double x = double.Parse(arg);
		WriteLine($"{x} {Sin(x)} {Cos(x)}");
		}
	}
}
