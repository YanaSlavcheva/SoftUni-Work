import java.util.Arrays;
import java.util.Scanner;


public class _08SortArrayOfStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = Integer.parseInt(input.nextLine());
		String[] stringsArray = new String[n];
		//input.nextLine();
		for (int i = 0; i < n; i++){
			stringsArray[i] = input.nextLine();
		}
		Arrays.sort(stringsArray);
		for (int i = 0; i < n; i++){
			System.out.println(stringsArray[i]);
		}
	}

}
