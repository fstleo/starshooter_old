using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerGun : MonoBehaviour, IPlayerGun
{

    public float ReloadTime = 0;
    private float currentTimeout;

    private Pool bulletPool;

    Transform cachedTransform;

    private void Awake()
    {
        cachedTransform = transform;
    }


    public void SetPool(Pool pool)
    {
        bulletPool = pool;
    }

    public void Shoot()
    {
        if (currentTimeout <= 0)
        {            
            currentTimeout = ReloadTime;
            EventManager.Instance.QueueEvent(new ShotEvent());
            bulletPool
                .GetObject()
                .Use(transform.position + new Vector3(0, Random.Range(-0.1f, 0.1f), 0));
        }   
    }

    private void Update()
    {
        currentTimeout -= Time.deltaTime;
    }

}
