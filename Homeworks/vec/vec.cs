using static System.Console;
using static System.Math;
public class vec{
	public double x,y,z;
	

	//constructors:
	public vec(double a, double b, double c){
		x=a;y=b;z=c;
		}
	public vec(){x=0;y=0;x=0;}

	//print method:
	public void print(string s){
		Write(s);WriteLine($"{x} {y} {z}");
		}
	public void print(){this.print("");}
	
	public static void print(vec v){v.print("static method:");}

	//Operators:
	// + & - operators
	public static vec operator+(vec u, vec v){
		return new vec(u.x+v.x, u.y+v.y, u.z+v.z);
		}
	public static vec operator-(vec u, vec v){
		return new vec(u.x-v.x, u.y-v.y, u.z-v.z);
		}	
	public static vec operator+(vec u){return u;}
	public static vec operator-(vec u){return -1*u;}

	
	// multiplication
	public static vec operator*(vec u,double c){
		return new vec(c*u.x,c*u.y,c*u.z);
		}
	public static vec operator*(double c,vec u){
		return u*c;
		}
	public static vec operator*(vec u, vec v){
		return new vec(u.x*v.x, u.y*v.y,u.z*v.z);
		}
	// To string method
	
	public override string ToString(){
		return $"{x} {y} {z}";
		}

	// vector products
	public double dot(vec other){	
		return this.x*other.x + this.y*other.y + this.z*other.z;
		}
	public double dot(vec u, vec v){return u.dot(v);}


	public vec cross(vec other){
		double s1= this.y*other.z - this.z*other.y;
		double s2= this.z*other.y - this.x*other.z;
		double s3= this.x*other.y - this.y*other.x;	
		return new vec(s1, s2,s3);
		}	

	public vec cross(vec u, vec v){return u.cross(v);}

	public double norm(){
		return Sqrt(this.x*this.x + this.y*this.y + this.z*this.z);
		}
	
	static bool approx(double a, double b, double tau=10-9,double eps=1e-9){
		if(Abs(a-b)<tau)return true;
		if(Abs(a-b)/(Abs(a)+Abs(b))<eps)return true;
		return false;
		}

	public bool approx(vec other){
		if(!approx(this.x,other.x))return false;
		if(!approx(this.y,other.y))return false;
		if(!approx(this.z,other.z))return false;
		return true;
		}
	
	public static bool approx(vec u, vec v){return u.approx(v);}


}
