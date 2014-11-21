import java.util.Scanner;


public class _09PointsInsideTheHouse {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		double coordX = input.nextDouble();
		double coordY = input.nextDouble();
		
		//we make two condition - for each rectangle
		Boolean cond01 = (coordX >= 12.5) && (coordX <= 17.5) && (coordY >= 8.5) && (coordY <= 13.5);
		Boolean cond02 = (coordX >=20) && (coordX <= 22.5) && (coordY >= 8.5) && (coordY <= 13.5);
		
		//we make third condition for the triangle
		//we use the algorithm described by the best answer
		//in this post http://stackoverflow.com/questions/13300904/determine-whether-point-lies-inside-triangle
		//for readability of the code we don't fill in the formula directly
		//first we set the coordinates of the three point, describing the triangle
		
		double p1x = 12.5;
		double p1y = 8.5;
		double p2x = 22.5;
		double p2y = 8.5;
		double p3x = 17.5;
		double p3y = 3.5;
		
		//The barycentric coordinates, alpha, beta, and gamma, are calculated as follows:
		double alpha = ((p2y - p3y)*(coordX - p3x) + (p3x - p2x)*(coordY - p3y)) /
		        ((p2y - p3y)*(p1x - p3x) + (p3x - p2x)*(p1y - p3y));
		double beta = ((p3y - p1y)*(coordX - p3x) + (p1x - p3x)*(coordY - p3y)) /
		       ((p2y - p3y)*(p1x - p3x) + (p3x - p2x)*(p1y - p3y));
		double gamma = 1.0f - alpha - beta;
		
		//we make third condition - for the triangle
		Boolean cond03 = (alpha >= 0) && (beta >= 0) && (gamma >= 0);
		
		//final cases
		if(cond01 || cond02 || cond03){
			System.out.println("Inside");
		}else{
			System.out.println("Outside");
		}
		
		
	}

}
