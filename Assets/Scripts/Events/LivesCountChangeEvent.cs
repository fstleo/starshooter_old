using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCountChangeEvent : EventBaseData {

    public int LivesCount
    { get; private set; }

    public LivesCountChangeEvent(int count)
    {
        LivesCount = count;
    }

}
