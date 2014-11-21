import java.util.Scanner;


public class _05DecimalToHexadecimal {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int decimal = input.nextInt();
		
		System.out.printf("%X", decimal);
	}

}
