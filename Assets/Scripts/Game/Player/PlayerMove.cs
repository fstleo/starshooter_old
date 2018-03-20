using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IPlayerMove
{

    public float XSpeed;
    public float YSpeed;

    private Transform cachedTransform;
    private Vector2 leftBottomBorder, rightTopBorder;

    private void Awake()
    {
        cachedTransform = transform;
        leftBottomBorder = Camera.main.ViewportToWorldPoint(Vector3.zero) + new Vector3(0.5f, 0.5f, 0);
        rightTopBorder = Camera.main.ViewportToWorldPoint(Vector3.one) - new Vector3(0.5f, 0.5f, 0);
    }

    public void Move(float xAxis, float yAxis)
    {        
        cachedTransform.position = new Vector3(Mathf.Clamp(cachedTransform.position.x + xAxis * XSpeed * Time.deltaTime, leftBottomBorder.x, rightTopBorder.x),
            Mathf.Clamp(cachedTransform.position.y + yAxis * YSpeed * Time.deltaTime, leftBottomBorder.y, rightTopBorder.y),0);
    }

}
