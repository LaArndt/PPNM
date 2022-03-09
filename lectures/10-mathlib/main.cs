using System;
using static System.Console;
class main{

public static void Main(){
	Func<double,double> f = delegate(double x){return x;};
	double result = integarte.quad(f,a:0,b:1,acc:1e-6,eps:1e-6);
	WriteLine($"result = {result}");



}


}
