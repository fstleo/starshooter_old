using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Menu;

public class MenuChangeStateEventData : EventBaseData {

    public State state;

    public MenuChangeStateEventData(State state)
    {
        this.state = state;
    }

}
