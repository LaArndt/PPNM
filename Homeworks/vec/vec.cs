using static System.Console;
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

	// vector products
	public double dot(vec other){	
		return this.x*other.x + this.y*other.y + this.z*other.z;
		}
		
	public vec cross(vec other){
		double s1= this.y*other.z - this.z*other.y;
		double s2= this.z*other.y - this.x*other.z;
		double s3= this.x*other.y - this.y*other.x;	
		return new vec(s1, s2,s3);
		}	
}
