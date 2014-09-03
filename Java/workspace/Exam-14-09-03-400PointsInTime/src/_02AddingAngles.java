import java.util.Scanner;


public class _02AddingAngles {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		input.nextLine();
		
		String allAnglesString = input.nextLine();
		String[] allAngles = allAnglesString.split(" "); 	
		
		int[] allAnglesNums = new int[allAngles.length];
		
		for (int i = 0; i < allAngles.length; i++) {
			allAnglesNums[i] = Integer.parseInt(allAngles[i]); 
		}
		
		int counter = 0;
		for (int i = 0; i < allAnglesNums.length - 2; i++) {
			for (int j = i + 1; j < allAnglesNums.length - 1; j++) {
				for (int j2 = j + 1; j2 < allAnglesNums.length; j2++) {
					int anglesSum = allAnglesNums[i] + allAnglesNums[j] + allAnglesNums[j2];
					Boolean cond01 = (anglesSum%360 == 0); 
					if (cond01) {		
						String outputString = allAnglesNums[i] + " + " + allAnglesNums[j] + " + " + allAnglesNums[j2] + " = " + anglesSum + " degrees";
						System.out.println(outputString);
						counter++;
					}
				}
			}			
		}
		
		if (counter == 0) {
			System.out.println("No");
		}

	}

}
