using System;
using static System.Math;
using static System.Console;

class main{
	
	public static void Main(){
	//setup a matrix//
	int n=3;
       	matrix A = new matrix(n,n);
	for(int i=0;i<=n-1;i++){
		for(int j=0;j<=i;j++){
		Random x = new Random();
		A[i,j]=x.Next(10);
		A[j,i]=A[i,j];
		}
	}
	WriteLine("/////// Part A ////////");
	A.print("a random matrix A");
	matrix V  = jacobi.cyclic(A).Item2;
	matrix D = jacobi.cyclic(A).Item1;
	V.print("\neigen-vector matrix V");	
	D.print("\neigen-value matrix  D");

	WriteLine("\n///// making checks ////");
	
	matrix newD = V.transpose()*A*V;
	newD.print("\nVtAV=D:");
	
	matrix newA = V*D*V.transpose();
	newA.print("\nVDVt = A");
	
	
	matrix VtV = V.transpose()*V;
	VtV.print("\nVtV=1");
	
	matrix VVt = V*V.transpose();
	VVt.print("\n VVt = 1");

		
	}//Main

}//class container
