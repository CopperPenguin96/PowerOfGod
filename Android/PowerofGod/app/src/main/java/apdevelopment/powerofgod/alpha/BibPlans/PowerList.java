package apdevelopment.powerofgod.alpha.BibPlans;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import apdevelopment.powerofgod.alpha.Events.PowerListEvent;
import apdevelopment.powerofgod.alpha.Events.PowerListListener;

/**
 * Created by apotter96 on 1/30/2016.
 */
public class PowerList<E> extends ArrayList<E> {
    public static final PowerList<String> STRINGLIST = new PowerList<>(new ArrayList<String>());
    public static final PowerList<Integer> INTLIST = new PowerList<>(new ArrayList<Integer>());
    public static final PowerList<Boolean> BOOLLIST = new PowerList<>(new ArrayList<Boolean>());

    private ArrayList<E> _arrayList;
    public PowerList(ArrayList<E> aList)
    {
        _arrayList = aList;
    }
    public PowerList()
    {
        super();
    }

    private PowerList<String> _list = PowerList.STRINGLIST;
    private PowerList<Integer> _listInt = PowerList.INTLIST;
    private PowerList<Boolean> _listBool = PowerList.BOOLLIST;
    private List _listeners = new ArrayList();
    public boolean addString(String o)
    {
        _list.add(o);
        receiveUpdate();
        return true;
    }
    public boolean addInt(int i)
    {
        _listInt.add(i);
        receiveUpdate();
        return true;
    }
    public boolean addBool(boolean b)
    {
        _listBool.add(b);
        receiveUpdate();
        return true;
    }
    public synchronized void receiveUpdate(PowerList<String> f, PowerType pt)
    {
        switch (pt)
        {
            case String:
                if (!_list.equals(f))
                {
                    _fireListEvent();
                }
                break;
            case Integer:
                if (!_listInt.equals(f))
                {
                    _fireListEvent();
                }
                break;
            case Boolean:
                if (_listBool.equals(f))
                {
                    _fireListEvent();
                }
                break;
        }
    }

    public synchronized void receiveUpdate()
    {
        if (!_list.equals(this))
        {
            _fireListEvent();
        }
    }

    public synchronized void receiveUpdate(PowerType pt)
    {
        switch (pt)
        {
            case String:
                if (!_list.equals(this))
                {
                    _fireListEvent();
                }
                break;
            case Integer:
                if (!_listInt.equals(this))
                {
                    _fireListEvent();
                }
                break;
            case Boolean:
                if (_listBool.equals(this))
                {
                    _fireListEvent();
                }
                break;
        }
    }

    public synchronized void addListListener(PowerListListener l)
    {
        _listeners.add(l);
    }

    public synchronized void removeListListener(PowerListListener l)
    {
        _listeners.remove(l);
    }

    public synchronized void _fireListEvent()
    {
        PowerListEvent list = new PowerListEvent(this, _list);
        Iterator listeners = _listeners.iterator();
        while (listeners.hasNext())
        {
            ((PowerListListener) listeners.next()).listReceived(list);
        }
    }

}
