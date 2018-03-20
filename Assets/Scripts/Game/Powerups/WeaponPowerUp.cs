using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : PowerUp
{

    protected override void FireEvent()
    {
        EventManager.Instance.QueueEvent(new WeaponPowerUpEvent());
    }

}
