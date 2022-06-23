using System;
using static System.Console;
class main{

public static void Main(){
	list<int> a = new list<int>();
	a.push(0);
	a.push(3);
	a.push(9);
	a.push(15);
	WriteLine("testing list nodes");
	double nd = 0;
	for(a.start();a.current!=null;a.next()){
		WriteLine($"node = {nd} item = {a.current.item}");
		nd++;

	}


}//Main method
}//main class
