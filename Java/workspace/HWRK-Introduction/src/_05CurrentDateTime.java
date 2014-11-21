import java.util.Date;


public class _05CurrentDateTime {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Date timeNow = new Date();
		System.out.printf("The current date is %1$tY/%1$tB/%1$td. The current time is %1$tH:%1$tM:%1$tSh", timeNow);
	}

}
