using static System.Console;
using static System.Math;
public static class math{
	public static void test(){
		double e = System.Math.E, pi = System.Math.PI;
		double sqrt2 = Sqrt(2.0);
		WriteLine($"sqrt(2)={sqrt2}");
		WriteLine($"sqrt(2)^2 should be {sqrt2*sqrt2}=2");

		double epi = Pow(e,pi);
		WriteLine($"e^pi={epi}");

		double n = 7.0;
		double ne = Pow(n,e);
		WriteLine($"for n={n}, n^e = {ne}");
	}
}

