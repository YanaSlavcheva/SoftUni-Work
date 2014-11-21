import java.util.Arrays;
import java.util.Scanner;


public class _04SmallestOf3Numbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		double[] numbers = new double[3];
		for (int i = 0; i < 3; i++){
			numbers[i] = input.nextDouble();
		}
		//we sort the array - the smallest member has index 0
		Arrays.sort(numbers);
		
		//here we make sure that if the smallest number is int (5)
		//we won't print it as a double (5.0)
		if(numbers[0] == (int) numbers[0]){
			System.out.println((int)numbers[0]);
		}  
	    else{
	    	System.out.println(numbers[0]);
	    }
	}
}
