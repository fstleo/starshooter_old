using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour 
{

    [SerializeField]
    private PoolItem prototype;

    [SerializeField]
    private int size;

    private List<PoolItem> objects = new List<PoolItem>();
	
	private void Awake ()
    {        
		for (int i = 0; i < size; i++)
        {
            CreateObject();
        }
	}

    public PoolItem GetObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].IsActive)
            {
                return objects[i];
            }
        }
        return CreateObject();
    }

    private PoolItem CreateObject()
    {
        PoolItem tmp = prototype.Clone();        
        objects.Add(tmp);
        return tmp;
    }

}
