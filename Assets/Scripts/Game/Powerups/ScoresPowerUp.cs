using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresPowerUp : PowerUp
{
    [SerializeField]
    int Scores;

    protected override void FireEvent()
    {
        EventManager.Instance.QueueEvent(new ScoresPowerUpEvent(Scores));
    }

}
