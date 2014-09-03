import java.util.Scanner;


public class _01DozensOfEggs {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		
		int sumEggs = 0;
		
		for (int i = 0; i < 7; i++) {					
			String currDay = scanner.nextLine();			
			if (currDay.equals("End")) {
				break;
			}	
			
			String[] splitBeers = currDay.split(" ");
			
			if (splitBeers[1].equals("dozens")) {
				sumEggs += Integer.parseInt(splitBeers[0]) * 12;						
			} else {
				sumEggs += Integer.parseInt(splitBeers[0]);	
			}
		}
		
		int sumStacks = sumEggs/12;
		sumEggs = sumEggs%12;
		String output = sumStacks + " dozens + " + sumEggs + " eggs";
		
		System.out.println(output);
	}
}
