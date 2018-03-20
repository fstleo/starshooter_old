using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AnimatedPoolItem {

    [SerializeField]
    int Scores = 5;

    [SerializeField]
    int Lifes = 5;

    int currentLifes = 5;
    
    protected override void Awake()
    {
        base.Awake();
        currentLifes = Lifes;        
    }

	public override void Destroy()
    {
        currentLifes = Lifes;
        base.Destroy();
	}
	
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            currentLifes--;
            if (currentLifes <= 0)
            {
                EventManager.Instance.QueueEvent(new EnemyDie(Scores, transform.position));
                Destroy();
            }
        }
        if (collision.transform.CompareTag("Player"))
        {
            Destroy();            
        }
    }

}
