import java.util.Scanner;


public class _06FormattingNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int a = input.nextInt();
		double b = input.nextDouble();
		double c = input.nextDouble();
		String aBinary = Integer.toString(a, 2);
		System.out.printf("|%1$-10X|%2$010d|%3$10.2f|%4$-10.3f|",a, Integer.parseInt(aBinary), b, c);
	}

}
