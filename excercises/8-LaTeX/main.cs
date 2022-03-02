using System;
using static System.Math;
using static System.Console;

public class main{
	public static void Main(){
		double dx=1.0/8;
		for(double x=-5; x<=5; x+=dx)
			WriteLine($"{x} {sfuns.ex(x)}");


	}

}

