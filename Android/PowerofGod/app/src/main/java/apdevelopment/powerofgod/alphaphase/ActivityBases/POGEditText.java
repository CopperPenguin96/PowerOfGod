package apdevelopment.powerofgod.alphaphase.ActivityBases;

import android.content.Context;
import android.util.AttributeSet;
import android.widget.EditText;

/**
 * Created by apotter96 on 4/8/2015.
 */
public class POGEditText extends EditText {

    public POGEditText(Context context) {
        super(context);
    }

    public POGEditText(Context context, AttributeSet attrs) {
        super(context, attrs);
    }

    public POGEditText(Context context, AttributeSet attrs, int defStyle) {
        super(context, attrs, defStyle);
    }

    public String toString()
    {
        return Text();
    }

    public String Text()
    {
        return getText().toString();
    }

}
