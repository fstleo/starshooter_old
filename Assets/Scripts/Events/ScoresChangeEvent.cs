using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresChangeEvent : EventBaseData
{

    public int Scores
    { get; private set; }

    public ScoresChangeEvent(int scores)
    {
        Scores = scores;
    }
}
