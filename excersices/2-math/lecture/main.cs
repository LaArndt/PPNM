using System;
using static System.Console;


public static class test{
	public static int n=7;
	public static double pi=3.1415927;
	public static double e=2.71828;
}

public static class main{
	static string s="main\n";
	static void hello(){
		string s="hello\n";
		Write(s);
		{	string j="block\n";
			Write(j);
		}
	}
	static int Main(){
		double x,y;
		x = test.pi;
		y = test.e;
		Write("x={0}, y={1})\n",x,y);
		Write($"x={x}, y={y}\n");
			math.test();
	return 0;
	}
}
