package apdevelopment.powerofgod.alpha.MsgBox;

import android.app.AlertDialog;
import android.content.Context;

/**
 * Created by apotter96 on 1/17/2016.
 */
public class MsgBox {
    AlertDialog.Builder builder;
    AlertDialog dialog;
    public MsgBox()
    {

    }
    public MsgBox(String title, String message, Context context)
    {
        builder = new AlertDialog.Builder(context);
        dialog = builder.create();
    }

    public boolean Show()
    {
        dialog.show();
        return true;
    }
}
