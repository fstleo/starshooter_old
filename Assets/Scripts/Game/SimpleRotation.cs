using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour {

    [SerializeField]
    int maxRotationSpeed = 80;

    Transform cachedTransform;    
    Quaternion rotationDelta;

    void Awake()
    {
        cachedTransform = transform;
        maxRotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);        
        rotationDelta = Quaternion.Euler(0, 0, maxRotationSpeed * Time.deltaTime);
    }

    void Update()
    {        
        cachedTransform.rotation *= rotationDelta;
    }
}
