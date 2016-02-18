package apdevelopment.powerofgod.alphaphase.MsgBox;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.widget.ArrayAdapter;

import java.util.ArrayList;

/**
 * Created by apotter96 on 1/18/2016.
 */
public class ListMsgBox extends MsgBox {
    public String _selectedItem = "Items";
    public AlertDialog.Builder builderSimple;
    public ListMsgBox(String title, String message, Context c, ArrayList<String> items)
    {
        builderSimple = new AlertDialog.Builder(c);
        builderSimple.setTitle(title);
        final ArrayAdapter<String> arrayAdapter = new ArrayAdapter<>(
                c, android.R.layout.select_dialog_singlechoice);
        for (String item:items)
        {
            arrayAdapter.add(item);
            System.out.println("Adding " + item + " to the seen plan list!");
        }
        builderSimple.setNegativeButton("Cancel",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                    }
                }
        );
        builderSimple.setAdapter(
                arrayAdapter,
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        _selectedItem = arrayAdapter.getItem(which);
                        AnItemClicked = true;
                    }
                }
        );
    }
    public boolean AnItemClicked = false;
    @Override
    public boolean Show()
    {
        builderSimple.show();
        return true;
    }

    public String getSelectedValue()
    {
        if (_selectedItem == null)
        {
            return "Cancelled";
        }
        else
        {
            return _selectedItem;
        }
    }

}
