using System;
using static System.Console;
using static System.Math;

class main{
	static void Main(){
		int n=9;
		double[] a=new double[n];
		a[0]=7;
		WriteLine($"a[0]={a[0]}");
		for(int i=0;i<n;i++){a[i]=i;}

		for(int i=0;i<n;i++)WriteLine($"a[{i}]={a[i]}");
		int m=n;
		m=0;
		WriteLine($"m={m},n=...{n}");
		
		double[] b=a;
		b[0]=999;
		WriteLine($"b[0]={b[0]}, a[0]=...{a[0]}");

		foreach(double ai in a)WriteLine($"ai={ai}");

		vec u=new vec(100,200,300);
		u.print("u=");
		vec v=new vec(1,2,3);
		v.print("v=");
		(u+v).print("u+v =");
		var w=3*u-v;
		w.print("w=");
		vec.print(w);

		vec A = new vec(2,4,6);
		A.print("A=");
		vec B = new vec(3,-6,9);
		B.print("B=");

		double q = A.dot(B);
		WriteLine($"A dot B={q}");	

	}

}
