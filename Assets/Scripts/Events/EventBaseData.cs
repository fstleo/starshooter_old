using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEvent
{
    string GetName();
}

public abstract class EventBaseData
{
    public virtual string GetName()
    {
        return this.GetType().Name;
    }
}
