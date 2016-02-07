package apdevelopment.powerofgod.alphaphase.MsgBox;

import android.content.Context;
import android.content.DialogInterface;

/**
 * Created by apotter96 on 1/17/2016.
 */
public class YesNoMsgBox extends MsgBox {
    String titleStr;
    String messageStr;
    Context context;
    public boolean Response;
    public YesNoMsgBox(String title, String message, Context c)
    {
        super(title, message, c);
        DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                switch (which){
                    case DialogInterface.BUTTON_POSITIVE:
                        Response = true;
                        break;
                    case DialogInterface.BUTTON_NEGATIVE:
                        Response = false;
                        break;
                }
            }
        };
        builder.setTitle(title);
        builder.setMessage(message).setPositiveButton("Yes", dialogClickListener)
            .setNegativeButton("No", dialogClickListener);
        dialog = builder.create();
    }
    public boolean Show()
    {
        dialog.show();
        return Response;
    }

}
