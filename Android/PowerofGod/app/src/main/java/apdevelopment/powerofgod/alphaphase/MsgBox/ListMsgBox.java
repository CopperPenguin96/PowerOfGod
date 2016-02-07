package apdevelopment.powerofgod.alphaphase.MsgBox;

import android.content.Context;
import android.content.DialogInterface;
import android.widget.ArrayAdapter;

import java.util.ArrayList;

/**
 * Created by apotter96 on 1/18/2016.
 */
public class ListMsgBox extends MsgBox {
    private String _selectedItem;
    public ListMsgBox(String title, String message, Context c, ArrayList<String> items)
    {
        super(title, message, c);
        final ArrayAdapter<String> arrayAdapter = new ArrayAdapter<>(
                c, android.R.layout.select_dialog_singlechoice);
        for (String item:items)
        {
            arrayAdapter.add(item);
        }
        builder.setNegativeButton("Cancel",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                    }
                }
        );
        builder.setAdapter(
                arrayAdapter,
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        _selectedItem = arrayAdapter.getItem(which);
                    }
                }
        );
    }
    @Override
    public boolean Show()
    {
        builder.show();
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
