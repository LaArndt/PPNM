using System;
using static System.Console;
using static System.Math;

class main{

	public static void Main(){

	var lines = System.IO.File.ReadAllText("@/erf.data.txt");
	foreach(var line in lines)WriteLine("\t"+line);

	}	
}
