using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class EventManager : MonoBehaviour {

    public delegate void EventDelegate<T>(T e) where T : EventBaseData;
    private delegate void EventDelegate(EventBaseData e);

    private static EventManager _instance;
    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EventManager>();
            }
            return _instance;
        }
    }

    private Dictionary<Type, EventDelegate> delegates = new Dictionary<Type, EventDelegate>();
    private Dictionary<Delegate, EventDelegate> registeredDeligates = new Dictionary<Delegate, EventDelegate>();
    private Dictionary<Delegate, Delegate> onceLookups = new Dictionary<Delegate, Delegate>();
    private Queue<EventBaseData> eventQueue = new Queue<EventBaseData>();

    private EventDelegate AddDelegate<T>( EventDelegate<T> del) where T :EventBaseData
    {
        if (registeredDeligates.ContainsKey(del))
            return null;
        EventDelegate internalDelegate = (e) => del((T)e);
        registeredDeligates[del] = internalDelegate;

        EventDelegate tempDel;
        if (delegates.TryGetValue(typeof(T), out tempDel))
        {
            delegates[typeof(T)] = tempDel += internalDelegate;
        }
        else
        {
            delegates[typeof(T)] = internalDelegate;
        }
        return internalDelegate;
    }
    
    public void AddListener<T>(EventDelegate<T> del) where T : EventBaseData
    {
        AddDelegate<T>(del);
    }
    
    public void AddListenerOnce<T>(EventDelegate<T> del) where T : EventBaseData
    {
        EventDelegate result = AddDelegate<T>(del);

        if (result != null)
        {            
            onceLookups[result] = del;
        }
    }

    public void RemoveListener<T>(EventDelegate<T> del) where T : EventBaseData
    {
        EventDelegate internalDelegate;
        if (registeredDeligates.TryGetValue(del, out internalDelegate))
        {
            EventDelegate tempDel;
            if (delegates.TryGetValue(typeof(T), out tempDel))
            {
                tempDel -= internalDelegate;
                if (tempDel == null)
                {
                    delegates.Remove(typeof(T));
                }
                else
                {
                    delegates[typeof(T)] = tempDel;
                }
            }

            registeredDeligates.Remove(del);
        }
    }

    public void RemoveAll()
    {
        delegates.Clear();
        registeredDeligates.Clear();
        onceLookups.Clear();
    }

    public bool HasListener<T>(EventDelegate<T> del) where T : EventBaseData
    {
        return registeredDeligates.ContainsKey(del);
    }

    public void TriggerEvent(EventBaseData e)
    {
        EventDelegate del;        
        if (delegates.TryGetValue(e.GetType(), out del))
        {            
            del.Invoke(e);            
            foreach (EventDelegate k in delegates[e.GetType()].GetInvocationList())
            {
                if (onceLookups.ContainsKey(k))
                {
                    delegates[e.GetType()] -= k;

                    if (delegates[e.GetType()] == null)
                    {
                        delegates.Remove(e.GetType());
                    }

                    registeredDeligates.Remove(onceLookups[k]);
                    onceLookups.Remove(k);
                }
            }
        }
        if (delegates.TryGetValue(typeof(EventBaseData), out del))
        {
            del.Invoke(e);
        }
    }

    public void QueueEvent(EventBaseData evt)
    {
        eventQueue.Enqueue(evt);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {        
        while (eventQueue.Count > 0)
        {
            EventBaseData evt = eventQueue.Dequeue();
            TriggerEvent(evt);
        }
    }
}
