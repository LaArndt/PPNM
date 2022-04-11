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

	WriteLine("\n////// Part B /////");		
	
	// Testing dr //
	double[] drs = new double[]{0.5,1,2};
	
	for(int i=0;i<=2;i++){
	double dr = drs[i], rmax=10;
       	int npoints = (int)(rmax/dr)-1;
	vector r = new vector(npoints);
	for(int j=0;j<npoints;j++)r[j]=dr*(j+1);
	matrix H = new matrix(npoints,npoints);
	for(int k=0;k<npoints-1;k++){
		H[k,k]=-2;
		H[k,k+1]=1;
		H[k+1,k]=1;
	}
	H[npoints-1,npoints-1]=-2;
	H*=-0.5/dr/dr;
	for(int l=0;l<npoints;l++)H[l,l]+=-1/r[l];
	
	//hamiltonian made //
	(matrix HD, matrix HV) = jacobi.cyclic(H);
	for(int m=0;m<=npoints-1;m++)Error.WriteLine($"{r[m]} {HD[m,m]}");
	Error.WriteLine("\n");	
	};
	
	Error.WriteLine("\n\n\n");
	//testing rmax //
	
	int[] rmaxs = new int[]{10,15,20};
	
	for(int i=0;i<=2;i++){
	double dr = 0.5;
        int rmax=rmaxs[i] , npoints = (int)(rmax/dr)-1;
	vector r = new vector(npoints);
	for(int j=0;j<npoints;j++)r[j]=dr*(j+1);
	matrix H = new matrix(npoints,npoints);
	for(int k=0;k<npoints-1;k++){
		H[k,k]=-2;
		H[k,k+1]=1;
		H[k+1,k]=1;
	}
	H[npoints-1,npoints-1]=-2;
	H*=-0.5/dr/dr;
	for(int l=0;l<npoints;l++)H[l,l]+=-1/r[l];
	
	//hamiltonian made //
	(matrix HD, matrix HV) = jacobi.cyclic(H);
	for(int m=0;m<=npoints-1;m++)Error.WriteLine($"{r[m]} {HD[m,m]}");
	Error.WriteLine("\n");	
	};
	
	
	Error.WriteLine("\n\n\n");
	
	//Solving Hamiltonian//
	
	double Dr = 0.2;
        int Rmax= 32 , Npoints = (int)(Rmax/Dr)-1;
	vector R = new vector(Npoints);
	for(int j=0;j<Npoints;j++)R[j]=Dr*(j+1);
	matrix Ha = new matrix(Npoints,Npoints);
	for(int k=0;k<Npoints-1;k++){
		Ha[k,k]=-2;
		Ha[k,k+1]=1;
		Ha[k+1,k]=1;
	}
	Ha[Npoints-1,Npoints-1]=-2;
	Ha*=-0.5/Dr/Dr;
	for(int l=0;l<Npoints;l++)Ha[l,l]+=-1/R[l];
	
	//hamiltonian made //
	(matrix HaD, matrix HaV) = jacobi.cyclic(Ha);
	for(int m=0;m<=Npoints-1;m++){
		Error.WriteLine($"{R[m]} {HaV[m,0]} {HaV[m,1]} {HaV[m,2]} ");
	//	for(int k=0;k<=3;k++)Error.Write($"{HaV[m,k]} ");
	}

	Error.WriteLine("\n\n");	
	


	//theoretical radial wavefunctions //
	double a0 = 1;
	Func<double,double> R10 = delegate(double r){
		return r*2*Pow(a0,(-3/2))*Exp(-r/a0);};

	Func<double,double> R20 = delegate(double r){
		return r*1/Sqrt(2)*Pow(a0,(-3/2))*(1-r/(2*a0))*Exp(-r/(2*a0));};

	Func<double,double> R30 = delegate(double r){
		return r*2/Sqrt(27)*Pow(a0,(-3/2))*(1-2*r/(3*a0)+2*r*r/(27*a0*a0))*Exp(-r/(3*a0));};
	
	for(int i=0;i<=Npoints-1;i+=1)Error.WriteLine($"{R[i]} {HaV[4,0]/R10(R[4])*R10(R[i])} {HaV[25,1]/R20(R[25])*R20(R[i])} {HaV[65,2]/R30(R[65])*R30(R[i])}");
	
	}//Main
	
}//class container
