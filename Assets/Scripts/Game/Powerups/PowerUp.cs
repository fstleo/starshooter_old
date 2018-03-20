using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : PoolItem
{    

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.transform.CompareTag("Player"))
        {
            FireEvent();
            Destroy();
        }
    }

    protected abstract void FireEvent();
}
