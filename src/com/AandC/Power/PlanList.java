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
	ArrayList<String> planNameList;
	public void onCreate(Bundle b) {
		super.onCreate(b);
		setContentView(R.layout.list);
		MsgBox.planListContext = this;
		try
		{
			for (String h:BibPlanParser.getInstalledPlans())
			{
				try {
					System.out.println(h);
				} catch (Exception e) {
					
				}
			}
		} catch (IOException e) {
			
		} catch (InvalidBibPlanException e) {
			
		}
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
		// Get the reference of listPlans
		ListView planList = (ListView) findViewById(R.id.listPlans);
		planNameList = new ArrayList<String>();
		getPlanNames();
		// Create The Adapter with passing ArrayList as 3rd parameter
		ArrayAdapter<String> arrayAdapter = new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1, planNameList);
		// Set The Adapter
		planList.setAdapter(arrayAdapter); 
		// register onClickListener to handle click events on each item
		planList.setOnItemClickListener(new OnItemClickListener() {
		// argument position gives the index of item which is clicked
				public void onItemClick(AdapterView<?> arg0, View v,int position, long arg3) {
					String selectedAnimal= planNameList.get(position);
					Toast.makeText(getApplicationContext(), "Plan Selected : " + selectedAnimal, Toast.LENGTH_LONG).show();
				}
		 });
	}
	void getPlanNames() throws IOException, InvalidBibPlanException {
		for (String availablePlans:BibPlanParser.getInstalledPlans()) {
			try {
				planNameList.add(availablePlans);
			} catch (NullPointerException e) {
				
			}
		}
		planNameList.add("Get More");
	}
}
