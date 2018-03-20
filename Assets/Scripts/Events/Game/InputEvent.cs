using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEvent : EventBaseData {

    public bool Shoot
    { get; private set; }

    public float axisX
    { get; private set; }

    public float axisY
    { get; private set; }

    public InputEvent(bool shoot, float x, float y)
    {
        Shoot = shoot;
        axisX = x;
        axisY = y;
    }
    
    public override string GetName()
    {
        return string.Format("{0} (X: {1} Y: {2} shoot: {3})",base.GetName(), axisX, axisY, Shoot);
    }
}
