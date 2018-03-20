using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : EventBaseData
{
    public Vector3 Position
    {
        get;private set;
    }

    public int Scores
    {
        get; private set;
    }

	public EnemyDie(int scores, Vector3 position)
    {
        Position = position;
        Scores = scores;
    }
}
