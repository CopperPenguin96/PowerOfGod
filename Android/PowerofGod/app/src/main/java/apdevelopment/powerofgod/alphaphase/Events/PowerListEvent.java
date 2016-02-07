package apdevelopment.powerofgod.alphaphase.Events;

import java.util.EventObject;

import apdevelopment.powerofgod.alphaphase.BibPlans.PowerList;

/**
 * Created by apotter96 on 1/30/2016.
 */
public class PowerListEvent extends EventObject {
    private PowerList<String> _powerList;
    public PowerListEvent(Object source, PowerList<String> list)
    {
        super(source);
        _powerList = list;
    }

    public PowerList<String> list()
    {
        return _powerList;
    }
}
