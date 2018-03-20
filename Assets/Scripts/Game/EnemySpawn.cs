using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [SerializeField]
    float SpawnCooldown = 5;    
    float startCooldown = 5;
    float currentCooldown = 5;

    Pool[] pools;

	void Awake()
    {
        pools = GetComponentsInChildren<Pool>();
        startCooldown = SpawnCooldown;
        currentCooldown = Random.Range(1, SpawnCooldown);
        EventManager.Instance.AddListener<ComplexityUpEvent>(OnCompexityUp);
	}

    private void OnDestroy()
    {
        if (EventManager.Instance != null)
            EventManager.Instance.RemoveListener<ComplexityUpEvent>(OnCompexityUp);
    }

    private void OnCompexityUp(ComplexityUpEvent ev)
    {
        SpawnCooldown = startCooldown / (ev.Complexity+1);
    }

    void Update()
    {
        if (currentCooldown <= 0)
        {
            Spawn();                        
            currentCooldown = SpawnCooldown;
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }

	
    void Spawn()
    {        
        pools[Random.Range(0, pools.Length)]
            .GetObject()
            .Use(transform.position + new Vector3(0, Random.Range(-5, 5), 0));
    }
}
