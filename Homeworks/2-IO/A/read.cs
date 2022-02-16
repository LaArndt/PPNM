using System;
using static System.Math; 
using static System.Console; 
using System.IO; 

class main{
	public static void Main(){
		WriteLine("Iteration A");
		char[] delimiters = {' ','\t','\n'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for( string line=ReadLine(); line !=null; line= ReadLine() ){
			var words = line.Split(delimiters, options);
			foreach(var word in words){
				double x = double.Parse(word);
				WriteLine($"{x} {Sin(x)} {Cos(x)}");
			}
		}
	}
}
