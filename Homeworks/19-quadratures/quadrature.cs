using System;
using static System.Console;
using static System.Double;
using static System.Math;

public class qt{

public static double integrate(
		Func<double,double>f, double a, double b,
		double delta=0.001, double eps=0.001, double f2=NaN, double f3=NaN)
	{
	double h=b-a;
	if(IsNaN(f2)){f2=f(a+2*h/6);f3=f(a+4*h/6);}
	double f1=f(a+h/6), f4=f(a+5*h/6);
	double Q = (2*f1+f2+f3+2*f4)/6*(b-a);
	double q = (f1+f2+f3+f4)/4*(b-a);
	double err = Abs(Q-q);
	if(err <= delta+eps*Abs(Q)) return Q;
	else return integrate(f,a,(a+b)/2,delta/Sqrt(2),eps,f1,f2)+integrate(f,(a+b)/2,b,delta/Sqrt(2),eps,f3,f4);
	}//integrate method


public static double CCintegrate(
		Func<double,double>f, double a, double b,
		double delta=0.001, double eps=0.001, double f2=NaN, double f3=NaN)
	{
	double Int = 0;
	// transform f(x) into f(cos(theta))sin(theta)
	if(a==-1 && b==1){
		Func<double,double>funky = delegate(double theta){
		return f(Cos(theta))*Sin(theta);};
		Int+= integrate(funky,0,PI);
	}
	else{
		Func<double,double>funky = delegate(double theta){
		return f((a+b)/2+(b-a)/2*Cos(theta))*Sin(theta)*(b-a)/2;};
		Int+= integrate(funky,0,PI);
	}
	return Int;
	}//CCintegrate

}//(q)uadra(t)ure class



