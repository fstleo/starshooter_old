using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPoolItem : PoolItem
{
    [SerializeField]
    int particlesEmit = 1;

    protected ParticleSystem emitter;
    protected Collider2D cachedCollider;
    protected SpriteRenderer graphic;
    protected SimpleMove move;

    protected override void Awake()
    {
        base.Awake();
        cachedCollider = GetComponent<BoxCollider2D>();
        emitter = GetComponentInChildren<ParticleSystem>();
        graphic = GetComponentInChildren<SpriteRenderer>();        
        move = GetComponentInChildren<SimpleMove>();
    }

    public override void Destroy()
    {
        move.enabled = false;
        cachedCollider.enabled = false;
        graphic.enabled = false;
        emitter.Emit(particlesEmit);
        currentLifetime = 1;
    }

    public override void Use(Vector3 position)
    {
        move.enabled = true;
        cachedCollider.enabled = true;
        graphic.enabled = true;
        base.Use(position);
    }
    
}
