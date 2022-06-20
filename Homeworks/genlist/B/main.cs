using System;
using static System.Console;
using static System.Math;

public class main{

public static void Main(){
	
	genlist<double[]> list = new genlist<double[]>();
	char[] delimiters = {' ','\t'};
	var options = StringSplitOptions.RemoveEmptyEntries;
	for(string line = ReadLine(); line!=null; line=ReadLine()){
		var words = line.Split(delimiters,options);
		int n = words.Length;
		var numbers = new double[n];
		for(int i=0;i<n;i++) numbers[i] = double.Parse(words[i]);
		list.push(numbers);
	}
	for(int i=0;i<list.size;i++){
		var numbers = list.data[i];
		foreach(var number in numbers)Write($"{number:e} ");
		WriteLine();
	}

	genlist<double> rlist = new genlist<double>();
	for(int i=0;i<10;i+=2) rlist.push(i);
	WriteLine();
	WriteLine($"Removing element at i=4,8 in list {rlist} gives new list:");
	rlist.remove(4);
	rlist.remove(8);
	WriteLine($"{rlist}");
}//Main





}//main class
