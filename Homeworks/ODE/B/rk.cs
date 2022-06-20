using System;
using static System.Console;
using static System.Math;

public static class rk{

public static (vector,vector) rkstep45(
		Func<double,vector,vector> f,
		double x,
		vector y,
		double h
		){
	vector k1 = f(x,y);
	vector k2 = f(x+h/4.0, y+k1*h/4.0);
	vector k3 = f(x+3.0/8*h, y+3.0/32*h*k1+9.0/32*h*k2);
	vector k4 = f(x*12.0/13*h, y+1932.0/2197*h*k1 -7200.0/2197*h*k2 + 7296.0/2197*h*k3);
	vector k5 = f(x+h, y+439.0/216*h*k1 -8.0*h*k2 + 3680.0/513*h*k3 - 845.0/4104*h*k4);
	vector k6 = f(x+h/2.0, y -8.0/27*h*k1 +2.0*h*k2 -3544.0/2565*h*k3 + 1859.0/4104*h*k4 - 11.0/40*h*k5);
	vector yh = y+ h*(25.0/216*k1 + 1408.0/2565*k3 + 2197.0/4104*k4 -1.0/5*k5);
	vector er = h*((16.0/135-25.0/216)*k1 + (6656.0/12825-1408.0/2565)*k3 + (28561.0/56430-2197.0/4104)*k4 + (-9.0/50 + 1.0/5)*k5 + 2.0/55*k6);
	return (yh,er);
}//stepper 

public static vector driver(
		Func<double,vector,vector> f,
		double a,
		vector ya,
		double b,
		// ---------part B-------- //
		genlist<double> xlist=null, 
		genlist<vector> ylist=null,
		//-------------------------//
		double h=0.01,
		double acc=0.01,
		double eps=0.01
		){
		if(a>b) throw new Exception("driver: a>b");
		double x=a; vector y=ya;
		if(xlist !=null && ylist!=null){
			xlist.push(x);
			ylist.push(ya);
		}
		do{
		if(x>=b)return y;
		if(x+h>b)h=b-x;
		var (yh, erv)=rkstep45(f,x,y,h);
		//------------- B -----------------//
		vector tol =  new vector(erv.size);
		bool ok = true;
		for(int i=0;i<tol.size;i++){
			tol[i] =  Max(acc, Abs(yh[i]*eps))*Sqrt(h/(b-a));
			ok = ok && erv[i] < tol[i];
		}
		if(ok){
			x+=h;y=yh;
			if(xlist!=null && ylist!=null){
			xlist.push(x);
			ylist.push(y);
			}
		}
		double factor = tol[0]/Abs(erv[0]);
		for(int i= 1;i<tol.size;i++) factor=Min(factor,tol[i]/Abs(erv[i]));
		h*= Min(Pow(factor,0.25)*0.95,2);
		// --------------------------------- //
		}while(true);
}//Driver

}//Class rk
