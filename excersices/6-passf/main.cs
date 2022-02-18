using System;
using static System.Math;
using static System.Console;

class main{
	public static void Main(){
	//Construct list manually from a to b with step dx
	
	System.Func<double,double> square = delegate(double x){return x*x;};
	int a = 0;
	int b = 20;
	int dx = 2;
	double[] list = new double[b];
	for(int i=a;i<b;i+=dx){list[i]=i;}
       
	for(int i=a;i<b;i+=dx){
		WriteLine($"value={i}, square={square(i)}");
		};	

	WriteLine("NEW STUFF");
	//Try it using the make_table funktion
	
	static void make_table(System.Func<double,double> f){
		for(double x=0;x<=10;x+=1)WriteLine($"{x}");
		};
	make_table(square);
	}

}
