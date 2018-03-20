using System;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMove
{
    void Move(float xAxis, float yAxis);
}

public interface IPlayerGun
{    
    void SetPool(Pool pool);
    void Shoot();
}

public class PlayerController
{
    private IPlayerMove move;
    private IPlayerGun gun;

    public PlayerController(IPlayerMove playerMove, IPlayerGun playerGun)
    {
        move = playerMove;
        gun = playerGun;
        EventManager.Instance.AddListener<InputEvent>(HandleInput);
        EventManager.Instance.AddListener<GameOverEvent>(HandleGameOver);
    }

    private void HandleInput(InputEvent ev)
    {
        if (ev.Shoot)
            gun.Shoot();
        move.Move(ev.axisX, ev.axisY);
    }

    private void HandleGameOver(GameOverEvent ev)
    {
        EventManager.Instance.RemoveListener<InputEvent>(HandleInput);
    }

}
