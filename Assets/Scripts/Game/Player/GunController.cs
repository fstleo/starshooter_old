using UnityEngine;
using System.Collections.Generic;

public class GunController : GunsSet
{
    public int level = 0;

    protected override void Awake()
    {
        base.Awake();

        EventManager.Instance.AddListener<WeaponPowerUpEvent>(UpgradeWeapons);
        EventManager.Instance.AddListener<PlayerHit>(ResetWeapons);
        EventManager.Instance.AddListenerOnce<GameOverEvent>(TurnOffWeapons);
    }

    private void OnDestroy()
    {
        if (EventManager.Instance == null)
            return;
        EventManager.Instance.RemoveListener<WeaponPowerUpEvent>(UpgradeWeapons);
        EventManager.Instance.RemoveListener<PlayerHit>(ResetWeapons);
    }

    private void UpgradeWeapons(WeaponPowerUpEvent w)
    {
        if (level < guns.Length - 1)
        {
            level++;
        }
    }

    private void TurnOffWeapons(GameOverEvent ev)
    {
        for(int i = 0; i < guns.Length; i++)
        {
            if (i != level)
            {
                (guns[i] as GunsSet).gameObject.SetActive(false);
            }
        }
    }

    private void ResetWeapons(PlayerHit w)
    {
        level = 0;
    }

    public override void Shoot()
    {
        if (Time.timeScale > 0.5f)
            guns[level].Shoot();
    }

}
