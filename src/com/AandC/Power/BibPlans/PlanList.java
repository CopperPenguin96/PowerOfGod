package com.AandC.Power.BibPlans;
import android.app.*;
import android.os.*;
import android.widget.*;
import java.util.*;
import java.io.*;
import com.AandC.Power.Exceptions.*;
import android.widget.AdapterView.*;
import android.view.*;
import com.AandC.Power.*;
import com.AandC.Power.StartUp.*;
/*
 Copyright 2014 apotter96

 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at

 http://www.apache.org/licenses/LICENSE-2.0

 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
 */
public class PlanList extends Activity
{
	@Override
	ArrayList<String> planNameList;
	public void onCreate(Bundle b) {
		super.onCreate(b);
		setContentView(R.layout.list);
		AppContext.planListContext = this;
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
					String selectedItem = planNameList.get(position);
					if (selectedItem.equals("Get More")) {
						MsgBox msg = new MsgBox("Feature Currently Unavailable", "This will feature a list of Power of God " +
							"Official Endorsed BibPlans that can be downloaded at the " +
							"click of a button! Coming soon!", AppContext.planListContext);
						msg.show();
					} else {
						BibPlan bx = null;
						try
						{
							bx = BibPlanParser.getBibPlan(selectedItem);
						} catch (Exception e) {
							e.printStackTrace();
							Toast.makeText(getApplicationContext(), "Unable to read BibPlan", Toast.LENGTH_LONG).show();
						} finally {
							try
							{
								MsgBox b = new MsgBox("Plan Information",
													  "Name: " + bx.name + "\n" +
													  "Day Count: " + bx.dayCount +
													  "Today's Reading " + bx.planDays[bx.getCurrentDay()]
													  , AppContext.planListContext);
								b.show();
							}
							catch (IOException e) {
								e.printStackTrace();
							}
						}
					}
					//Toast.makeText(getApplicationContext(), "Plan Selected : " + selectedItem, Toast.LENGTH_LONG).show();
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
