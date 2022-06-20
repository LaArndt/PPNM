using System;
using static System.Console;
using static System.Math;

class main{
	static void Main(){
		WriteLine("\nI've made a 3d-vector class vec(x,y,b)");
		vec u=new vec(100,200,300);
		
		WriteLine("here are some");
		u.print("u=");
		vec v=new vec(1,2,3);
		v.print("v=");

		WriteLine("\nby operator overloading they may be added, multiplied etc.");
		(u+v).print("u+v =");
		var w=3*u-v;
		w.print("w=3u-v=");

		WriteLine("\nthe class contains a method to take the dot-product");
		vec A = new vec(2,4,6);
		A.print("A=");
		vec B = new vec(3,-6,9);
		B.print("B=");

		double q = A.dot(B);
		WriteLine($"A*B={q}");	
		
		WriteLine("\nlikewise the cross-product");
		vec k = A.cross(B);
		k.print("AxB=");


	}

}
