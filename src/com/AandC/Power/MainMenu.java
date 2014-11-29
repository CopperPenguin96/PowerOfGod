package com.AandC.Power;
import android.app.*;
import android.os.*;
import com.AandC.Power.User.*;
import MsgBox;
import com.AandC.Power.Bible.*;
public class MainMenu extends Activity
{
	@Override
	public void onCreate(Bundle sv) {
		super.onCreate(sv);
		setContentView(R.layout.mainmenu);
		MsgBox s = new MsgBox(Header()[0], Header()[1], this);
		s.Show();
	}
	
	String[] Header() {
		String name = UserInfo.getName();
		if (Files.IsNew) {
			return new String[] {
				"Welcome, " + name,
				"It appears as if it is your first time here! \n" +
					"There are new lessons every Sunday and Thursday and occasional quizzes!\n" +
					"The main goals of this app are to help you grow and Christ (through study) " +
					"and rightly dividing. (2 Timothy 2:15) " +
					"\n\nAll scripture in this app is from the King James Version. For more info " + 
					"you may contact thre developer at alex364981@gmail.com"
			};
		} else {
			return new String[] {
				"Welcome back, " + name,
				"I missed you!" + Genesis.verse(1,1)
			};
		}
	}
}
