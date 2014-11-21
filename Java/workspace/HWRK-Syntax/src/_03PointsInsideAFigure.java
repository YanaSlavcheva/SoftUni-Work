import java.util.Scanner;

public class _03PointsInsideAFigure {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		double coordX = input.nextDouble();
		double coordY = input.nextDouble();
		
		//we make three condition - for each rectangle
		Boolean cond01 = (coordX >= 12.5) && (coordX <= 17.5) && (coordY >= 8.5) && (coordY <= 13.5);
		Boolean cond02 = (coordX >=20) && (coordX <= 22.5) && (coordY >= 8.5) && (coordY <= 13.5);
		Boolean cond03 = (coordX >= 12.5) && (coordX <= 22.5) && (coordY >= 6) && (coordY <= 8.5);
		if(cond01 || cond02 || cond03){
			System.out.println("Inside");
		} else {
			System.out.println("Outside");
		}
	}
}
