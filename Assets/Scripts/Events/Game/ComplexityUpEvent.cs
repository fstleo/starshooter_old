using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexityUpEvent : EventBaseData {

    public int Complexity
    { get; private set; }

	public ComplexityUpEvent(int complexity)
    {
        Complexity = complexity;
    }
}
