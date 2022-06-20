using System;
using static System.Math;
using static System.Console;

class main{
	
	public static void Main(){
	//setup a matrix//
	int n=8;int m=3;
	matrix A = new matrix(n,m);
	for(int i=0;i<=n-1;i++){
		for(int j=0;j<=m-1;j++){
		Random x = new Random();
		A[i,j]=x.Next(10);
		}
	}
	
	matrix sq = new matrix(4,4);
	for(int i=0;i<=3;i++){
		for(int j=0;j<=3;j++){
			Random x = new Random();
			sq[i,j]=x.Next(10);
			}
		}
	var b = new vector(4);
	for(int i=0;i<=3;i++){
		Random x = new Random();
		b[i]=x.Next(10);
		}

	
	QRregs Solv = new QRregs(sq);
	
	WriteLine("\n//////////////// B /////////////////////\n testing GS-QR factorisation");
	sq.print("reusing same square matrix A:\n");
	
	matrix inverse = Solv.inverse();
	inverse.print("\ninverse matrix B=A⁻1\n");

	WriteLine("\nChecking the relation A*B = 1");
	matrix unit = sq*inverse;
	unit.print("\n");
	WriteLine("\nWhich is indeed the unit matrix");
	}}
