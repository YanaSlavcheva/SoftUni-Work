import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class _04ActivityTracker {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		int n = input.nextInt();
		input.nextLine();
		String[] inputData = new String[n];
		
		for (int i = 0; i < n; i++) {
			inputData[i] = input.nextLine();
		}
		
		HashMap<Integer, TreeMap<String, Integer>> allData = new HashMap<>();

		for (int i = 0; i < inputData.length; i++) {
			String[] temp = inputData[i].split(" ");
			String date = temp[0];
			String person = temp[1];
			int steps = Integer.parseInt(temp[2]);
			
			String[] tempDate = date.split("/");
			int month =  Integer.parseInt(tempDate[1]);
						
			if (!allData.containsKey(month)) {
				allData.put(month, new TreeMap<String, Integer>());
			}
			
			TreeMap<String, Integer> personSteps = allData.get(month);			
			int oldSteps = 0;
			if (personSteps.containsKey(person)) {
				oldSteps = personSteps.get(person);
			}
			personSteps.put(person, oldSteps + steps);		
		}
			
		//output
		for (Integer month : allData.keySet()) {
			System.out.print(month + ": ");
			TreeMap<String, Integer> personSteps = allData.get(month);
			boolean first = true;
			for (Map.Entry<String, Integer> pair : personSteps.entrySet()) {
				if (!first) {
					System.out.print(", ");
				}
				first = false;
				String person = pair.getKey();
				int money = pair.getValue();
				System.out.print(person + "(" + money + ")");
			}
			System.out.println();
		}
	}
}
