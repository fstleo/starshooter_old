using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresPowerUpEvent : EventBaseData
{
    public int Scores
    { get; private set; }

	public ScoresPowerUpEvent(int scores)
    {
        Scores = scores;
    }
}
