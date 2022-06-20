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
	WriteLine("\n////// Part B /////");		
	WriteLine("testing of dr and rmax convergence can be found in \n dr.pdf and rmax.pdf respectively");
	
	
	// Testing dr //
	Error.WriteLine("#testing dr");
	for(double dr=0.1;dr<6;dr+=0.1){
	double  rmax=35;
       	int npoints = (int)(rmax/dr-1);
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
	Error.WriteLine($"{dr} {HD[0,0]} {HD[1,1]} {HD[2,2]}");
	};
	WriteLine("dr test finished");

	
	Error.WriteLine("\n\n");
	//testing rmax //
	Error.WriteLine("#testing rmax")	;
	for(int rmax =2;rmax<=30;rmax++){	
	double dr = 0.5;
        int npoints = (int)(rmax/dr-1);
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
	for(int m=0;m<=npoints-1;m++)Error.WriteLine($"{rmax} {HD[0,0]} {HD[1,1]} {HD[2,2]}");
	};
	WriteLine("rmax test finished");	
	
	WriteLine("constructing/solving hamiltonian for hydrogen \n see eigen.pdf for result");
	Error.WriteLine("\n\n\n #Hamiltonian solution");
	
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
	WriteLine("eigenfunctions determined");
	Error.WriteLine("\n\n");	
	


	//theoretical radial wavefunctions //
	double a0 = 1;
	
	Error.WriteLine("#R : an1 : an2 : an3 : an4 ");
	Func<double,double> R10 = delegate(double r){
		return r*2*Pow(a0,(-3/2))*Exp(-r/a0);};

	Func<double,double> R20 = delegate(double r){
		return r*1/Sqrt(2)*Pow(a0,(-3/2))*(1-r/(2*a0))*Exp(-r/(2*a0));};

	Func<double,double> R30 = delegate(double r){
		return r*2/Sqrt(27)*Pow(a0,(-3/2))*(1-2*r/(3*a0)+2*r*r/(27*a0*a0))*Exp(-r/(3*a0));};
	
	for(int i=0;i<=Npoints-1;i+=1)Error.WriteLine($"{R[i]} {HaV[4,0]/R10(R[4])*R10(R[i])} {HaV[25,1]/R20(R[25])*R20(R[i])} {HaV[65,2]/R30(R[65])*R30(R[i])}");
	WriteLine("Comparing with analytical functions");
	}//Main
	
}//class container
