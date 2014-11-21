import java.util.Scanner;


public class _01SymmetricNumbersInRange {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		//we read the input
		int startNum = input.nextInt();
		int endNum = input.nextInt();
		
		//we set a counter - because if we have no symmetric numbers we shall know 
		int counter = 0;
		for (int i = startNum; i <= endNum; i++){
			
			//we convert the each number in range to string
			//then we reverse it and check if the first string and the reversed strings are equal
			counter = printSymmetricNumbersChangeCounter(counter, i);
		}
		if (counter == 0){
			System.out.println("there is no symmetric numbers in range");
		}
	}

	private static int printSymmetricNumbersChangeCounter(int counter, int i) {
		if (Integer.toString(i).equals(new StringBuilder(Integer.toString(i)).reverse().toString())){
			System.out.printf("%d ",i);
			counter++;
		};
		return counter;
	}

}

