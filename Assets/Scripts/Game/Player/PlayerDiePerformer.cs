using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiePerformer : MonoBehaviour {



	void Awake()
    {
        EventManager.Instance.AddListenerOnce<GameOverEvent>(PerformExplosion);
	}

    void PerformExplosion(GameOverEvent ev)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponentInChildren<ParticleSystem>().gameObject.SetActive(false);
        foreach(SpriteRenderer t in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            Rigidbody2D rbody = t.gameObject.AddComponent<Rigidbody2D>();
            rbody.AddForceAtPosition(3*(t.transform.position - transform.position + Vector3.left), t.transform.position, ForceMode2D.Impulse);
            rbody.AddTorque(Random.Range(-5,5), ForceMode2D.Impulse);
        }
    }
}
