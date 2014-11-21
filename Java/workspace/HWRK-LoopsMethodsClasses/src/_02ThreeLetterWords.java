import java.util.Scanner;


public class _02ThreeLetterWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String givenChars = input.nextLine();
			for (int i = 0; i < givenChars.length(); i++) {
				for (int j = 0; j < givenChars.length(); j++) {
					for (int k = 0; k < givenChars.length(); k++) {
						StringBuilder result = new StringBuilder();
						appendCharToString(givenChars, i, result);
						appendCharToString(givenChars, j, result);
						appendCharToString(givenChars, k, result);
						System.out.print(result + " ");
					}
				}
			}
			
	}

	private static void appendCharToString(String givenChars, int i,
			StringBuilder result) {
		result.append(Character.toString(givenChars.charAt(i)));
	}

}
