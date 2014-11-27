package com.AandC.Power.User;
import android.app.*;
import android.os.*;
import java.security.*;
import com.AandC.Power.*;
import android.view.*;
import android.widget.*;
import MsgBox;
public class UserInfoActivity extends Activity
{
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.main);
	}
	String errorMessage = "You need to fix the following errors: \n\n";
	final String finalMessage = "You need to fix the following errors: \n\n";
	public void finishClick(View v) {
		EditText txtName = (EditText) findViewById(R.id.txtName);
		EditText txtAge = (EditText) findViewById(R.id.txtAge);
		EditText txtDen = (EditText) findViewById(R.id.txtDen);
		try {
			String x = txtName.getText().toString();
		} catch (NullPointerException ex) {
			(new MsgBox("Test","t",this)).Show();
		}
	}
	
	void Save() {
		
	}
}
