using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolItem : MonoBehaviour {

    public bool IsActive
    {
        get { return cachedGO.activeSelf; }
    }

    [SerializeField]
    float lifeTime = 5;

    protected float currentLifetime = 0;

    protected Transform cachedTransform;
    protected GameObject cachedGO;

    protected virtual void Awake()
    {
        currentLifetime = lifeTime;
        cachedTransform = transform;
        cachedGO = gameObject;
    }

    protected virtual void Update()
    {
        currentLifetime -= Time.deltaTime;
        if (currentLifetime <= 0)
        {
            LifetimeDestroy();
        }
    }

    public PoolItem Clone()
    {
        var obj = Instantiate(gameObject);
        obj.SetActive(false);
        return obj.GetComponent<PoolItem>();
    }

    public virtual void Use(Vector3 position)
    {
        currentLifetime = lifeTime;
        cachedGO.SetActive(true);
        cachedTransform.position = position;
        cachedTransform.rotation = Quaternion.identity;
    }

    public virtual void Use(Vector3 position, Quaternion rotation)
    {
        Use(position);
        cachedTransform.rotation = rotation;       
    }

    public virtual void LifetimeDestroy()
    {
        cachedGO.SetActive(false);
    }

    public virtual void Destroy()
    {        
        cachedGO.SetActive(false);
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        Destroy();
    }
}
