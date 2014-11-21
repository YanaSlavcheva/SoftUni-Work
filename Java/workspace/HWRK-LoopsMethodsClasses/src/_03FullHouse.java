
public class _03FullHouse {

	public static void main(String[] args) {
		String[] suits = {"♡", "♢", "♧", "♤", };
		String[] faces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", };
		
		//we need to find all the combinations between two cards,
		//because if we leave the suits out,
		//basically that is what a fullhouse is
		//for example - 2♡2♢2♧3♡3♢ is basically a combination of 2 and 3 plus suits
		
		
		//we need to count the fullhouses
		int counter = 0;
		
		//first we find all the combinations of card faces
		for (int f1 = 0; f1 < faces.length; f1++) {
			for (int f2 = 0; f2 < faces.length; f2++) {
				
				//if we have similar cards we are not happy
				//because five cards with face 2 are not a fullhouse :)
				if (f1 == f2) {
					continue;
				} else{
					//we make the combinations of the suits now
					//in order not to have repetitions amongst the first three cards
					//we use s2 = s1+1 etc
					for (int s1 = 0; s1 < suits.length; s1++) {
						for (int s2 = s1 + 1; s2 < suits.length; s2++) {
							for (int s3 = s2 + 1; s3 < suits.length; s3++) {
								//in order not to have repetitions amongst the 4th and 5th card
								//we use s5 = s4+1
								for (int s4 = 0; s4 < suits.length; s4++) {
									for (int s5 = s4 + 1; s5 < suits.length; s5++) {
										
										//we make a string with the result
										//we use a stringbuilder to create it
										StringBuilder currFullHouse = new StringBuilder();
										
										//we append face, suit, face, suit etc with two methods
										appendFaceToCurrFullHouse(faces, f1,
												currFullHouse);
										appendSuitToCurrFullHouse(suits, s1,
												currFullHouse);
										appendFaceToCurrFullHouse(faces, f1,
												currFullHouse);
										appendSuitToCurrFullHouse(suits, s2,
												currFullHouse);
										appendFaceToCurrFullHouse(faces, f1,
												currFullHouse);
										appendSuitToCurrFullHouse(suits, s3,
												currFullHouse);
										appendFaceToCurrFullHouse(faces, f2,
												currFullHouse);
										appendSuitToCurrFullHouse(suits, s4,
												currFullHouse);
										appendFaceToCurrFullHouse(faces, f2,
												currFullHouse);
										appendSuitToCurrFullHouse(suits, s5,
												currFullHouse);
										
										//now we print the current fullhouse
										System.out.println(currFullHouse);
										counter++;
								}
							}
						}
					}
				}
			}
		}
	}
	
	//finally we print the counter as well
	System.out.println(counter);
	}

	private static void appendSuitToCurrFullHouse(String[] suits, int s1,
			StringBuilder currFullHouse) {
		switch (s1) {
			case 0: currFullHouse.append(suits[0]); break;
			case 1: currFullHouse.append(suits[1]); break;
			case 2: currFullHouse.append(suits[2]); break;
			case 3: currFullHouse.append(suits[3]); break;
			default: break;
		}
	}

	private static void appendFaceToCurrFullHouse(String[] faces, int f1,
			StringBuilder currFullHouse) {
		switch (f1) {
			case 0: currFullHouse.append(faces[0]); break;
			case 1: currFullHouse.append(faces[1]); break;
			case 2: currFullHouse.append(faces[2]); break;
			case 3: currFullHouse.append(faces[3]); break;
			case 4: currFullHouse.append(faces[4]); break;
			case 5: currFullHouse.append(faces[5]); break;
			case 6: currFullHouse.append(faces[6]); break;
			case 7: currFullHouse.append(faces[7]); break;
			case 8: currFullHouse.append(faces[8]); break;
			case 9: currFullHouse.append(faces[9]); break;
			case 10: currFullHouse.append(faces[10]); break;
			case 11: currFullHouse.append(faces[11]); break;
			case 12: currFullHouse.append(faces[12]); break;
		default: break;
		}
	}

}
