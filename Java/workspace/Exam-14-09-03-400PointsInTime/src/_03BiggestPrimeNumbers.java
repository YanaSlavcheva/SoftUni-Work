import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;


public class _03BiggestPrimeNumbers {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		
		String input = scanner.nextLine();
		
		String[] numbers = input.split("[ ()]+");
		int[] nums = new int[numbers.length-1];
		for (int i = 0; i < nums.length; i++) {
			nums[i] = Integer.parseInt(numbers[i+1]);
		}		
	    
	    //make treeset to get unique numbers
		Set<Integer> allPrimes = new TreeSet<>();
		
		for (int i = 0; i < nums.length; i++) {
			int currNumber = nums[i];
			Boolean checkIfprime = checkIfPrime(currNumber);
			if (checkIfprime) {
				allPrimes.add(currNumber);
			}
		}
		
		//we convert the treeset to arraylist in order to sort
		ArrayList<Integer> primesList = new ArrayList<Integer>(allPrimes);
		Collections.reverse(primesList);			
		
		if (primesList.size() < 3) {
			System.out.println("No");
		} else {
			int maxSum = primesList.get(0) + primesList.get(1) + primesList.get(2);
			System.out.println(maxSum);
		}		
	}

	private static Boolean checkIfPrime(int i) {
		
		if ((i <= 1))  {
			return false;
		} 
		
		for (int j = 2; j < i; j++) {
			if (i%j == 0) {
				return false;
			}
		}
		return true;
	}
}
