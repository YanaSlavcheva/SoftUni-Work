import java.util.Scanner;


public class _08CountEqualBitPairs {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		
		//in Java binary numbers always have 32 bits (no matter if zeroes or not)
		//so we find first the number of leading zeroes
		//then we find the index of the last 1 bit
		int leadingZeroes = Integer.numberOfLeadingZeros(n);
		int indexLastBit = 31 - leadingZeroes;
		
		//now we can start counting the equal bit pairs
		int countEqualBitPairs = 0;
		for (int i = 0; i < indexLastBit; i++){
			int mask01 = 1 << i;
			int mask02 = 1 << (i + 1);
			
			//cond01 checks if the current bit is 0 or 1
			//cond02 checks if the next bit is 0 or 1
			Boolean cond01 = (n & mask01) == mask01;
			Boolean cond02 = (n & mask02) == mask02;
			
			//we need both bits to be the same
			//so we need to ^ cond01 and cond02 and have false as a result
			Boolean cond03 = cond01 ^ cond02;
			if (!cond03){
				countEqualBitPairs++;
			}
		}
		System.out.println(countEqualBitPairs);
	}

}
