package com.AandC.Power.User;
import android.app.*;
import android.os.*;
import java.security.*;
import com.AandC.Power.*;
import android.view.*;
import android.widget.*;
import MsgBox;
import org.json.*;
import java.io.*;
import android.content.*;
public class UserInfoActivity extends Activity
{
	@Override
	EditText txtName;
	EditText txtAge;
	EditText txtDen;
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.main);
		txtName = (EditText) findViewById(R.id.txtName);
		txtAge = (EditText) findViewById(R.id.txtAge);
		txtDen = (EditText) findViewById(R.id.txtDen);
	}
	
	String errorMessage = "You need to fix the following errors: \n\n";
	final String finalMessage = "You need to fix the following errors: \n\n";
	public void finishClick(View v) {
		if (txtName.getText().toString().equals("")) {
			errorMessage += "Name cannot be empty\n";
		}
		if (txtAge.getText().toString().equals("")) {
			errorMessage += "Age cannot be empty\n";
		} else {
			try {
				int x = Integer.parseInt(txtAge.getText().toString());
				if (x < 13) {
					errorMessage += "You must be at least 13 to use thisbapp!\n";
				} else if (x > 200) {
					errorMessage += "There's no way you are that old!\n";
				}
			} catch (Exception ex) {
				errorMessage += "Age can only be numbers.\n";
			}
		}
		if (txtDen.getText().toString().equals("")) {
			errorMessage += "Denomination cannot be empty. (Put nondenomination if you don't know)\n";
		}
		if (errorMessage.equals(finalMessage)) Save();
		else (new MsgBox("Sorry",errorMessage, this)).Show();
		errorMessage = finalMessage;
	}
	
	void Save() {
		UserInfo.setName(txtName.getText().toString());
		UserInfo.setAge(Integer.parseInt(txtAge.getText().toString()));
		UserInfo.setDen(txtDen.getText().toString());
		try {
			UserInfo.Update();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			Files.IsNew = true;
			startActivity(new Intent(this, MainMenu.class));
			this.finish();
		}
	}
}
