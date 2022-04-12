using System;
using static System.Console;
using static System.Math;

public class list<T>{
	public node<T> first=null, current=null;
	public void push(T item){
		if(first==null){
			first=new node<T>(item);
			current=first;
		}
		else{
			current.next = new node<T>(item);
			current=current.next;
		}
	}
	public void start(){current=first;}
	public void next(){ current=current.next;}

}//list class

public class node<T>{
	public T item;
	public node<T> next;
	public node(T item){this.item=item;}

}//node class

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





