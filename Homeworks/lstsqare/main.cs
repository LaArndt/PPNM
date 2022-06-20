using System;
using static System.Console;
using static System.Math;

class main{

	public static void Main(){
		double[] Time = new double[]{1, 2, 3, 4, 6, 9, 10, 13, 15};
		double[] Act  = new double[]{117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1};
		double[] err  = new double[]{5,5,5,5,5,1,1,1,1};
		WriteLine("\n\nMaking least squares fit based on the decay of ThX\nPart A: Fit using logarithmic fit ln(y) = ln(a)-bt");	
		var fs = new Func<double, double>[] {z=> 1.0, z=>z};
		
		int n = Time.Length;
		
		double[] lnAct = new double[n]; 
		double[] lnerr = new double[n];
		
		for(int i=0;i<n;i++){
			lnAct[i]=Log(Act[i]);
			lnerr[i]=err[i]/Act[i];
			};
			
		var fit = lstsquare.lsfit(fs,Time, lnAct, lnerr);
	
	/*	for(int i=0;i<Time.Length;i++){
			WriteLine($"{Time[i]} {Act[i]} {err[i]}");};

		WriteLine("\n");

	*/		
		vector coeffs = fit.Item1;
		matrix cov    = fit.Item2;
		vector errs   = fit.Item3;

		for(int i=0;i<Time.Length;i++){
			Error.WriteLine($"{Time[i]} {lnAct[i]} {lnerr[i]}");
			};

		Error.WriteLine("\n\n");
		for(double i=1;i<16;i+=1.0/4){
			Error.WriteLine($"{i} {coeffs[0] + coeffs[1]*i}");
			};	
		WriteLine($"\n\nfit results");
		WriteLine($"\nc0={coeffs[0]} c1={coeffs[1]}");
		WriteLine($"t½={Abs(0.693/coeffs[1])} days, reference value: 3.36 days");
		
		WriteLine($"\nPart B: Implemented Uncertainties of fits and covariance matrix");
		WriteLine($"\nnuncertainty of fit:\n c0_err = {errs[0]}, c1_err = {errs[1]}");
		cov.print("\ncovariance matrix");
	
		WriteLine("\nPart C: \n modified fit as f=a+err+(b+err)*x and f=a-err+(b-err)*x \n see plot for results");
		//making badder fits//
		Error.WriteLine("\n\n");
		for(double i=1;i<16;i+=1.0/4){
			Error.WriteLine($"{i} {coeffs[0]-errs[0] + (coeffs[1]-errs[1])*i}");
			}	
		Error.WriteLine("\n\n");
		for(double i=1;i<16;i+=1.0/4){
			Error.WriteLine($"{i} {coeffs[0]+errs[0] + (coeffs[1]+errs[1])*i}");
			}
	
	
	}
	//Main
	






}//class shell
