using System;
using static System.Console;
using static System.Math;
using static cmath;
class main{
	
	static complex gamma(complex x){
		///single precision gamma function (Gergo Nemes, from Wikipedia)
		if(abs(x)<0)return PI/sin(PI*x)/gamma(1-x);
		if(abs(x)<9)return gamma(x+1)/x;
		complex lngamma=x*log(x+1/(12*x-1/x/10))-x+log(2*PI/x)/2;
		return exp(lngamma);
	}
	
	public static void Main(){
	
		for(double x = -5; x <= 5; x += 1.0/4){
			for(double y = -5; y<=5; y += 1.0/4){
				if(Double.IsNaN(abs(gamma(new complex(x,y))))) 
					WriteLine("");
				else
					WriteLine($"{x} {y} {abs(gamma(new complex(x,y)))}");
			}
			WriteLine();
		}

	}
}

