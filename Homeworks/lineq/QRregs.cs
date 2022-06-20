using System;
using static System.Math;
using static System.Console;

public class QRregs{

	public matrix Q,R;
	
	public QRregs(matrix A){
	//making Q shape, identical to A's//
	Q = A.copy();
	int m = A.size2;
	
	//making quadratic matrix R//
	
	R = new matrix(m,m);

	for(int i=0;i<m;i++){
		R[i,i] = Q[i].norm();
		Q[i]  /= R[i,i];
		for(int j=i+1;j<m;j++){
			R[i,j]=Q[i].dot(Q[j]);
			Q[j]-=Q[i]*R[i,j];
			}
		}	
	}

	public vector solve(vector b){
		matrix Qt = Q.transpose();
		vector x  = Qt*b;
		backsub(R,x);
		return x;
	}

	public void backsub(matrix U, vector c){
		for(int i=c.size-1;i>=0;i--){
			double sum=0;
			for(int k=i+1;k<c.size;k++){
				sum += U[i,k]*c[k];
			}
			c[i]=(c[i]-sum)/U[i,i];
		}
	}
	public matrix inverse(){	
		int n = Q.size1;
		matrix inv = new matrix(n,n);
		for(int i=0;i<=n-1;i++){
			vector ivec = new vector(n);
			ivec[i] = 1;
			inv[i] = solve(ivec);
		
		}	
		return inv;
		
	
		}
}

