import java.util.Scanner;


public class _01RectangleArea {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int a = input.nextInt();
		int b = input.nextInt();
		input.nextLine();
		int area = a * b;
		
//		String aAndb = input.nextLine();
//		String[] absplit = aAndb.split("[ ]+");
//		int[] parts = new int[absplit.length];
//		for (int i = 0; i < 2; i++){
//			parts[i] = Integer.parseInt(absplit[i]);
//		}
//		int area = parts[0] * parts[1];
		System.out.println(area);
		
	}

}
