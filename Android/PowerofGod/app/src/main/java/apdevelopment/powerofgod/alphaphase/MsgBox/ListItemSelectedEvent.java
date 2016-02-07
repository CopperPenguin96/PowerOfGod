package apdevelopment.powerofgod.alphaphase.MsgBox;

import java.util.*;

/**
 * Created by apotter96 on 1/24/2016.
 */
public class ListItemSelectedEvent extends EventObject  {
    private ListMsgBox _listMsgBox;

    public ListItemSelectedEvent(Object source, ListMsgBox listMsgBox)
    {
        super(source);
        _listMsgBox = listMsgBox;
    }

    public ListMsgBox MsgBoxObj()
    {
        return _listMsgBox;
    }
}
