package com.AandC.Power;
import android.app.*;
import android.os.*;
import android.widget.*;
import java.util.*;
import java.io.*;
import com.AandC.Power.Exceptions.*;
import android.widget.AdapterView.*;
import android.view.*;

public class PlanList extends Activity
{
	@Override
	private ListView listView;
	public void onCreate(Bundle b) {
		super.onCreate(b);
		setContentView(R.layout.list);
		try
		{
			assignList();
		} catch (IOException e) {
			e.printStackTrace();
		} catch (InvalidBibPlanException e) {
			e.printStackTrace();
		} catch (NullPointerException e) {
			e.printStackTrace();
		}
	}
	void assignList() throws IOException, InvalidBibPlanException {
		listView = (ListView) findViewById(R.id.listPlans);
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1, 
			android.R.id.text1, 
			BibPlanParser.getInstalledPlans());
		// Assign adapter to ListView
		listView.setAdapter(adapter); 
		// ListView Item Click Listener
		listView.setOnItemClickListener(new OnItemClickListener() {
			@Override
			public void onItemClick(AdapterView<?> parent, View view,
							int position, long id) {
				// ListView Clicked item index
				int itemPosition = position;

				// ListView Clicked item value
				String  itemValue = (String) listView.getItemAtPosition(position);

				// Show Alert 
				Toast.makeText(getApplicationContext(),
								  "Position :"+itemPosition+"  ListItem : " +itemValue , Toast.LENGTH_LONG)
					.show();

			}

		}); 
	}
}
