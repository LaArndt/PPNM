
using System;
using System.Threading;
using static System.Console;

class main{
	
	public class data{public int a,b; public double sum;} 

	public static void harm(object obj){
		data d = (data)obj;
		WriteLine($"\nharm summing from {d.a} to {d.b}");
		d.sum = 0; 
		for(int i=d.a;i<d.b;i++)d.sum += 1.0/i;
		WriteLine($"harm summing from {d.a} to {d.b} gives {d.sum}");
		}	
	
	public static void Main(string[] args){
		
		int N = (int)1e8;
		if(args.Length>0)N = (int)double.Parse(args[0]);
		WriteLine($"N={(float)N}");
		
		
		data y = new data();
		y.a=N/2; y.b=N+1;

		Thread t2 = new Thread(harm);
		t2.Start(y);
		t2.Join();
		WriteLine($"harm sum from {N/2} to {N} = {y.sum}");
	}
}



