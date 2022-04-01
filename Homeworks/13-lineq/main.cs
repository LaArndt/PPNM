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
	WriteLine("///////////// A1. THERE DO BE MATRICES //////////// ");	
	WriteLine("\n Randomly constructed matrix");
	A.print();
	WriteLine("\n a single column(vector)");
	A[1].print();
	
	WriteLine("\n////////////////// QR decompositon ///////////");
	
	QRregs QR = new QRregs(A);
	WriteLine("Q:--------------------------------------------");
	QR.Q.print();
	WriteLine("R:--------------------------------------------");
	QR.R.print();
	WriteLine("\n upper Triangular bby, look at this beaut");
	WriteLine("\n---------------------------------------------");	
	
	WriteLine("\n///////////// TESTs /////////////////////7777");

	WriteLine("\n////////////// QtQ = 1 //////////////////////");
	matrix idM = QR.Q.transpose()*QR.Q;
	idM.print();

	WriteLine("\n///////////// QR = A ////////////////////////");
	matrix newA = QR.Q*QR.R;
	newA.print("\nQR--------------------------------------------");
	A.print(   "A--------------------------------------------");
	
	
	matrix sq = new matrix(4,4);
	for(int i=0;i<=3;i++){
		for(int j=0;j<=3;j++){
			Random x = new Random();
			sq[i,j]=x.Next(10);
			}
		}
	WriteLine("\n\n\n\n");
	WriteLine("////////////////// A.2 ///////////////////////////");
	sq.print("sqare matrix A :\n");
	var b = new vector(4);
	for(int i=0;i<=3;i++){
		Random x = new Random();
		b[i]=x.Next(10);
		}

	b.print("\nvector b:\n");
	
	WriteLine("\nsolving Ax = b, A=QR");
	QRregs Solv = new QRregs(sq);
	vector X = Solv.solve(b);
	X.print("\nsolution X:\n");
	
	vector veccie = sq*X;
	veccie.print("A*x:\n");


	WriteLine("\n\n\n\n//////////////// B /////////////////////");
	sq.print("reusing same square matrix A:\n");
	
	matrix inverse = Solv.inverse();
	inverse.print("\ninverse matrix A⁻1\n");

	WriteLine("\nChecking the relation A*A⁻1 = 1");
	matrix unit = sq*inverse;
	unit.print("\n");
	WriteLine("\nWhich is indeed the unit matrix");
	}}
