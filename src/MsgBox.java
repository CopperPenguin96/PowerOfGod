
import android.content.*;
import android.app.*;
import com.AandC.Power.*;
public class MsgBox
{
	private AlertDialog aDialog;
	public MsgBox(String title, String msg, Context c) {
		aDialog = new AlertDialog.Builder(c).create();
		aDialog.setTitle(title);
		aDialog.setMessage(msg);
		aDialog.setIcon(R.drawable.ic_launcher);
	}
	public void Show() {
		aDialog.show();
	}
}
