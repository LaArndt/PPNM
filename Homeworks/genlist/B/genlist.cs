using System;
using static System.Console;
using static System.Math;

public class genlist<T>{
	public T[] data;
	public int size=0, capacity = 8;
	public genlist(){data= new T[capacity];}
	
	public void push(T item){
		if(size == capacity){	
			T[] newdata = new T[capacity*=2];
			for(int i=0;i<size;i++) newdata[i] = data[i];
			data = newdata;
		}
		data[size]=item;
		size++;
	}//push	
	
	public void remove(int i){
		T[] newdata = new T[capacity];
		for(int j=0;j<size;j++){
			if(j<i) {newdata[j] = data[j];}
			if(j>i) {newdata[j-1] = data[j];}
		}
		data = newdata;
		size--;
	}//remove

	public void print(){
		Write("[");
		for(int i=0;i<size;i++){
			Write($"{data[i]}");
		}
		Write("]");
	}//print


	public override string ToString(){
		string[] elements = new string[size];
		for(int i=0;i<size;i++) elements[i]=data[i].ToString();
		return "["+string.Join(",",elements)+"]";
	}//ToString

}//genlist class

