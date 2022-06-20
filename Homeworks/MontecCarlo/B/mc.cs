using System;
using static System.Math;
using static System.Console;

public class MC{

public static double corput(int n, int _base){
	
	double q=0, bk=(double)1.0/_base;
	while(n>0){q += (n % _base)*bk; n/=_base; bk/=_base;};
	return q;
}//corput

public static vector halton(int n, int d, int shift=0){

int[] _base= new int[]{2,3,5,7,11,13,17,19,23,29,31,37,31,43,47,53,59,61,67};
	var x = new vector(d);

	for(int i=0;i<d;i++) x[i]=corput(n+1,_base[i+shift]);
	return x;

}//halton


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


public static (double,double) QRMC(Func<vector,double>f, vector a, vector b, int N){
	
	int dim = a.size;
	double V = 1;

	for(int i=0;i<dim;i++) V*=b[i]-a[i];

	double sum=0,sum2=0;

	var x = new vector(dim);
	var x2 = new vector(dim);

	for(int i=0;i<N;i++){
		var h = halton(i,dim,3);
		var h2 = halton(i,dim,7);

		for(int k=0;k<dim;k++){
		x[k] = a[k] + h[k]*(b[k]-a[k]);
		x2[k]= a[k] + h2[k]*(b[k]-a[k]);
		}
	double fx = f(x), fx2=f(x2);
	sum+=fx;
	sum2+=fx2;

	}
	double mean = sum/N, mean2=sum2/N;
	var result = ((mean+mean2)/2*V, Abs(mean-mean2)*V);

	return result;
}//QRMC


}//MonteCarlo

