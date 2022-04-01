using System;
using static System.Console;
using static System.Math;

public static class lstsquare{
	

	public static (vector,matrix,vector) lsfit(
			Func<double,double>[] fs, vector x, vector y, vector dy){
		//Preparing Matrix/vector for QR//
		int n = x.size, m=fs.Length;
		var A = new matrix(n,m);
		var b = new vector(n);
		
		//filling //
		for(int i=0;i<n;i++){
			b[i]=y[i]/dy[i];
			for(int k=0;k<m;k++)A[i,k]=fs[k](x[i])/dy[i];
			}
		
		QRregs qrfac = new QRregs(A);
		vector c = qrfac.solve(b);
		matrix AtA = A.transpose()*A;
		QRregs solveAtA = new QRregs(AtA);
		matrix covs = solveAtA.inverse();

		vector errs = new vector(m);
		for(int i=0;i<m;i++){
			errs[i] = Sqrt(covs[i][i]);
			}
		return (c,covs,errs);
	}
	
	
}
