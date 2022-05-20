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
	
	var rand = new Random();
	var x=new vector(dim);
	for(int i=0;i<N;i++){
		for(int k=0;k<dim;k++)x[k]=a[k]+rand.NextDouble()*(b[k]-a[k]);
		double fx=f(x); sum+=fx; sum2+=fx*fx;
	}
	double mean=sum/N, sigma=Sqrt(sum2/N-mean*mean);
	
	double integral = mean*V;
	double error    = sigma*V/Sqrt(N);
	var result = (integral, error);
	return result;
}//plainMC
}//MonteCarlo

