using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {
    
    [SerializeField]
    int minSpeed = 5;

    [SerializeField]
    int maxSpeed = 10;

    Rigidbody2D cachedRbody;
    Vector2 moveDelta;    

    void Awake () {
        cachedRbody = GetComponent<Rigidbody2D>();
        int speed = Random.Range(Mathf.Min(minSpeed, maxSpeed), Mathf.Max(minSpeed, maxSpeed));        
        moveDelta = new Vector2(speed * Time.fixedDeltaTime, 0);        
    }
	
	void FixedUpdate ()
    {
        cachedRbody.position += moveDelta;        
	}
}
