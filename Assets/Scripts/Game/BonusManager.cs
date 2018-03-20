using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour {

    [SerializeField]
    Pool [] powerUps;

    [SerializeField]
    int[] chances;

    private void Awake()
    {
        EventManager.Instance.AddListener<EnemyDie>(GenerateBonus);        
    }

    private void OnDestroy()
    {
        if (EventManager.Instance == null)
            return;
        EventManager.Instance.RemoveListener<EnemyDie>(GenerateBonus);
    }

    private void GenerateBonus(EnemyDie ev)
    {
        int roll = Random.Range(0, 100);
        int minIndex = -1;
        for(int i = 0; i < chances.Length; i++)
        {
            if ((roll < chances[i]) && ((minIndex < 0) || (chances[i] < chances[minIndex])))
            {
                minIndex = i;
            }
        }
        if (minIndex > -1)
        {
            powerUps[minIndex].GetObject().Use(ev.Position);            
        }
    }
}
