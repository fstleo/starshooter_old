using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private PlayerController player;
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameObject bulletPool;

    public int Lives
    { get; private set; }

    private void Awake()
    {
        Subscribe();
    }

    void Start()
    {
        AddLives(3);
        CreatePlayer();
    }

    void OnDestroy()
    {
        Unsubscribe();           
    }

    private void Subscribe()
    {

        EventManager.Instance.AddListener<PlayerHit>(ProcessPlayerDeath);
        EventManager.Instance.AddListener<LifePowerUpEvent>(ProcessLifePickup);
    }

    private void Unsubscribe()
    {
        if (EventManager.Instance == null)
            return;        
        EventManager.Instance.RemoveListener<PlayerHit>(ProcessPlayerDeath);
        EventManager.Instance.RemoveListener<LifePowerUpEvent>(ProcessLifePickup);
    }

    private void CreatePlayer()
    {
        GameObject tmp = Instantiate(playerPrefab);
        var move = tmp.GetComponent<IPlayerMove>();
        var gun = tmp.GetComponent<IPlayerGun>();
        gun.SetPool(bulletPool.GetComponent<Pool>());
        player = new PlayerController(move, gun);        
    }


    private void ProcessPlayerDeath(PlayerHit ev)
    {
        AddLives(-1);
    }

    private void ProcessLifePickup(LifePowerUpEvent ev)
    {
        AddLives(1);
    }

    private void AddLives(int count)
    {
        Lives += count;
        EventManager.Instance.QueueEvent(new LivesCountChangeEvent(Lives));
        if (Lives <= 0)
        {
            EventManager.Instance.QueueEvent(new GameOverEvent());
        }
    }
}
