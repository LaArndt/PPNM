using System;
using static System.Console;
using static System.Math;

public class main{


public static vector NewtonRoots(Func<vector,vector>f // input function vectors contain (f_i,f_i(x))?
		, vector x0 // starting point
		, double eps=1e-2 // accuracy goal
		)
		{
		
			
	vector x = x0.copy();
	int n = x.size;
			
	// calculate Jacobian matrix J //
	matrix J = new matrix(n,n);
	vector fx = new vector(x0);
	
	double delta = 1.0;

	while(true){
		fx=f(x);
		for(int i=0;i<n;i++){
			delta = Abs(x[i])*Pow(2,-26);
			for(int k=0;k<n;k++){
				vector xdx = x.copy();
				xdx[k]+=delta;
				J[i,k]=(f(xdx)[i]-fx[i])/delta;
			}
		}
		// solve system J delta x = -f(x) for delta x
		QRregs QR = new QRregs(J);
	       	var dx  = QR.solve(-fx);	
		
		double lambda = 2.0;
		vector fdx = f(x+lambda*dx);
		vector y = new vector(n);
		vector fy = new vector(n);
		while(true){
			lambda /=2;
			y = x+lambda*dx;
			fy = f(y);
			if(fy.norm()<(1-lambda/2.0)*fx.norm() || lambda<1.0/64){break;};
			}
		x = y;
		fx = fy;
		if(dx.norm()<delta || fx.norm()<eps){break;}
		}
	return x;

	}//newton roots

		

public static void Main(){


	// 1D function test //
	Func<vector,vector> f1d = delegate(vector vec){
		vector f = new vector(1);
		double x = (double)vec[0];
		f[0] = x*x-3*x;
		return f;
	};
	vector x0 =  new double[]{0.1};
	vector x02 =  new double[]{2.9};
	vector res1d = NewtonRoots(f1d,x0, 1e-16);
	vector res1d2 = NewtonRoots(f1d,x02, 1e-16);
	Error.WriteLine($"roots of 1d function x^2-3x are ({res1d[0]} and {res1d2[0]}): (0,3) expected" );


	// 2D function test //
	Func<vector,vector>f2D = delegate(vector vec){
			vector f = new vector(2);
			double x = vec[0];
			double y = vec[1];

			// x^2+ 2y + 8xy;
			f[0] = 2*x + 8*y;
			f[1] = 2+8*x;
			return f;
			
			};
	vector root2D = new double[]{0.1,4.1};
	vector sol2D = NewtonRoots(f2D,root2D,1e-16);
	Error.WriteLine($"roots of function x^2+2y+8xy are {sol2D[0]} & {sol2D[1]} \n inserted into the expression this returns (-0.25)^2+2*0.0625+8*(-0.25)*0.0625=0.0625");
		
	Error.WriteLine("Testing using Rosenbrocks valley function");
	Func<vector, vector> rosenbrock = delegate(vector vec){
		double x = (double)vec[0];
		double y = (double)vec[1];
		//function is (1-x)^2+100(y-x^2)²)
		//extremums can be found at dy/dx = 0

		vector f =  new vector(2);
		f[0] = 2*x-2+100*(4*x*x*x - 4*y*x);
		f[1] = 100*(1-2*x*x);
		return f;
	};
	
	vector rootRose = new double[]{1,1};
	vector solRose  = NewtonRoots(rosenbrock,rootRose,1e-16);
	Error.WriteLine($"rosenbrock extremums found at x={solRose[0]} and y={solRose[1]}");

}//Main method


}//main class
