using System;
using static System.Math;
using static System.Console;

public class MC{


public static (double,double) plainMC(
		Func<vector,double>f, //integrant function
	       	vector a, vector b, // start(a) and end(b) points of coordinates (x,y)
		int N // Nr of steps in sampler
		)
	{	
	int dim=a.size; double V=1;
	for(int i=0;i<dim;i++)V*=b[i]-a[i];
	double sum=0, sum2=0;
	
	var x=new vector(dim);
	for(int i=0;i<N;i++){
		Random RAND10 = new Random();
		for(int k=0;k<dim;k++)x[k]=a[k]+RAND10.Next(1)*(b[k]-a[k]);
		double fx=f(x); sum+=fx; sum2+=fx*fx;
	}
	double mean=sum/N, sigma=Sqrt(sum2/N-mean*mean);
	
	double integral = mean*V;
	double error    = sigma*V/Sqrt(N);
	var result = (integral, error);
	return result;
}//plainMC
}//MonteCarlo

public class main{
public static void Main(){
	Error.WriteLine("------------Part A--------------");
	Error.WriteLine("Wikipieda example");
	Func<vector, double> f = delegate(vector v){
		double x = (double)v[0];
		double y = (double)v[1];
		return x*x + 4*y;};
	var start = new double[]{11,7};
	var end   = new double[]{14,10};
	int N_steps = 1000000;
	var result = MC.plainMC(f,start,end,N_steps);
	
	Error.WriteLine($"int(x[11,14],y[7,10]) x^2+4y={result.Item1}, error={result.Item2}");

	Func<vector,double>func = delegate(vector v){
		double x = (double)v[0];
		double y = (double)v[1];
		return x*4 + Sqrt(x)*y*y;};
	var res2 = MC.plainMC(func,start,end,1000000);
	Error.WriteLine($"{res2.Item1} {res2.Item2}");


	Func<vector,double>fun1 = delegate(vector v){
		double x = (double)v[0];
		double y = (double)v[1];
		double z = (double)v[2];
		return 1/(1-Cos(x)*Cos(y)*Cos(z));};
	
	Error.WriteLine("Calculating singular integral [1-cos(x)cos(y)cos(z)]^-1");
	var st = new double[]{0,0,0};
	var en = new double[]{PI,PI,PI};
	var res = MC.plainMC(fun1,st,en,1000000);
	Error.WriteLine($"integral = {res}");
}//Main




}//main

