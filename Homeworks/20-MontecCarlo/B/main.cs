using System;
using static System.Math;
using static System.Console;

public class main{
public static void Main(){
	Error.WriteLine("------------Part B--------------");
	Error.WriteLine(" comparing pseudo-random MC integrator (A) with low-discrepeancy quasi-random MC integrator");
	Func<vector,double>fun1 = delegate(vector v){
		double x = (double)v[0];
		double y = (double)v[1];
		double z = (double)v[2];
		return 1/(PI*PI*PI)/(1-Cos(x)*Cos(y)*Cos(z));};
	

	Error.WriteLine("PR calculation of singular integral 1/(PI^3)* [1-cos(x)cos(y)cos(z)]^-1");
	var st = new double[]{0,0,0};
	var en = new double[]{PI,PI,PI};
	var res = MC.plainMC(fun1,st,en,1000000);
	Error.WriteLine($"integral = {res.Item1}, error={res.Item2}");
	Error.WriteLine($"should return 1.393");
	
	Error.WriteLine("QR calculation of singular integral 1/(PI^3)* [1-cos(x)cos(y)cos(z)]^-1");
	var res2 = MC.QRMC(fun1,st,en,1000000);
	Error.WriteLine($"integral = {res2.Item1}, error={res2.Item2}");
}//Main




}//main

