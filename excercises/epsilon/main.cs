using static System.Console;
using static System.Math;

public static class main {
	static void  MaxInt(){
		int i=1; while(i+1>i) {i++;}
		WriteLine($"max_int = {i}");
	}

	static void MinInt(){
		int i=1; while(i-1<i) {i--;}
		WriteLine($"min_int = {i}");
	}

	static void MachEpsilon(){
		float y=1F; while((float)(1F+y) != 1F) {y/=2F;} y*=2F;
		double x=1; while(1+x != 1) {x /= 2;} x*=2;
		WriteLine($"Machine epsilon for float: {y}");
		WriteLine($"Must be about {Pow(2,-23)}");;
		WriteLine($"Machine epsilon for double: {x}");
		WriteLine($"Must be about {Pow(2,-52)}");
	}
	
	static void Tiny(){
		int n = (int)1e6;
		double epsilon = Pow(2,-52);
		double tiny = epsilon/2;
		double sumA = 0, sumB = 0;

		sumA+=1; for(int i=0; i<n; i++) {sumA+=tiny;}
		WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");	

		for(int i=0;i<n;i++){sumB+=tiny;} sumB+=1;
		WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");

	}

	static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
		WriteLine($"Abs(a-b): {Abs(a-b)}");
		WriteLine($"(Abs(a-b)/(Abs(a)+Abs(b))): {(Abs(a-b)/(Abs(a)+Abs(b)))}");
		return (Abs(a-b)<tau) || (Abs(a-b)/(Abs(a)+Abs(b))<epsilon); 
	}

	static void testapprox(){
		double a = 1;
		double b = a - 1e-9;
		WriteLine($"approx(1, 1+1e-9) = {approx(a,b)} should be True");

		b = 2;
		WriteLine($"approx(1, 2) = {approx(a, b)} should be False");

	}

	public static void Main(){
		MaxInt();
		
		WriteLine();
		MinInt();
		
		WriteLine();
		MachEpsilon();
		
		WriteLine();
		Tiny();
		
		WriteLine();
		testapprox();
	}
}

