using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    [SerializeField]
    float ChangeSpeed;

    private Material mat;
    private Vector2 offsetChangeVector;
	
	void Awake () {
        mat = GetComponent<MeshRenderer>().materials[0];
        offsetChangeVector = new Vector2(ChangeSpeed * Time.fixedDeltaTime, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        mat.mainTextureOffset += offsetChangeVector;
        if (mat.mainTextureOffset.x > 1)
        {
            mat.mainTextureOffset -= new Vector2(1, 0);
        }
	}
}
