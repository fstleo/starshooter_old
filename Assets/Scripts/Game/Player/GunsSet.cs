using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsSet : MonoBehaviour, IPlayerGun
{
    
    protected IPlayerGun[] guns;

    protected virtual void Awake()
    {
        InitGuns();
    }

    protected void InitGuns()
    {
        List<IPlayerGun> g = new List<IPlayerGun>();
        for(int i = 0; i < transform.childCount; i++)
        {
            var gun = transform.GetChild(i).GetComponent<IPlayerGun>();
            if (gun != null)
                g.Add(gun);
        }        
        guns = g.ToArray();
    }
    
    public virtual void Shoot()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].Shoot();
        }
    }

    public virtual void SetPool(Pool pool)
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetPool(pool);
        }
    }
}
