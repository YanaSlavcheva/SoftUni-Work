import java.util.Scanner;


public class _06SumTwoNumbers {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner input = new Scanner(System.in);
		System.out.println("Enter two integers on seperate lines:");
		int a = input.nextInt();
		int b = input.nextInt();
		int sum = a + b;
		System.out.printf("The sum is %d%n", sum);
	}

}
