using System;
using static System.Console;
using static System.Math;

public class berrut{


	public static double B1(double[] x, double[] y, double z ){
		int n=x.Length;
		
		// computing the B1 function for location z //
		// Sums for B1 //
		double sum_t = 0;
		double sum_b = 0;
		
		for(int i=0;i<=n-1;i++){
		double top = Pow(-1,i)/(z-x[i])*y[i];
		double bot = Pow(-1,i)/(z-x[i]);
		sum_t += top;
		sum_b += bot;
		}
		double Bi = sum_t/sum_b;
		return Bi;

		
	}//B1 method

	public static double B2(double[] x, double[] y, double z){
		//array of n+1 elements//
		int n = x.Length;
		
		double sum_t=0;
		double sum_b=0;
		for(int i=0;i<=n-2;i++){
			double top = Pow(-1,i)/(z-x[i])*y[i];
			double bot = Pow(-1,i)/(z-x[i]);	
			sum_t+=top;
			sum_b+=bot;
		}
		double up = 1/(z-x[0])*y[0]+2*sum_t+Pow(-1,n-1)/(z-x[n-1])*y[n-1];
		double dw = 1/(z-x[0])+2*sum_b+Pow(-1,n-1)/(z-x[n-1]);

		var result = up/dw;
		return result;
	
	}//B2 method
	
	public static int binsearch(double[] x, double z){
        /* locates the interval for z by bisection */
        if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
        int i=0, j=x.Length-1;
        while(j-i>1){
                int mid=(i+j)/2;
                if(z>x[mid]) i=mid; else j=mid;
                }
        return i;
        }//binsearch
	
	public static double B_split(double[] x, double[] y, double z){
	
		int i = binsearch(x,z);
		int n = x.Length;
		double sum_t=0;
                double sum_b=0;
             
		for(int j=0;j<=n-2;j++){
                      	if(j>i){
			double top = -1/(z-x[i])*y[i];
                        double bot = -1/(z-x[i]);
                        sum_t+=top;
                        sum_b+=bot;
			}
			else{
                        double top = 1/(z-x[i])*y[i];
                        double bot = 1/(z-x[i]);
                        sum_t+=top;
                        sum_b+=bot;
			}
                }
                double up = 1/(z-x[0])*y[0]+2*sum_t+Pow(-1,n-1)/(z-x[n-1])*y[n-1];
                double dw = 1/(z-x[0])+2*sum_b+Pow(-1,n-1)/(z-x[n-1]);

                var result = up/dw;
                return result;

	
	
	
	
	}//B-split













}//Class Berrut
