using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputConfiguration configuration;
    float x = 0, y = 0;

    private void Awake()
    {
        configuration = UserSettings.KeyConfiguration;        
    }

	private void Update()
    {
        if (Input.GetKeyUp(configuration.Back))
        {
            EventManager.Instance.QueueEvent(new BackEvent());
            return;
        }

        ProcessGameInput();
    }

    private void ProcessGameInput()
    {
        x = 0;
        y = 0;

        if (Input.GetKey(configuration.Left))
        {
            x -= 1;
        }

        if (Input.GetKey(configuration.Right))
        {
            x += 1;
        }

        if (Input.GetKey(configuration.Up))
        {
            y += 1;
        }

        if (Input.GetKey(configuration.Down))
        {
            y -= 1;
        }
        EventManager.Instance.QueueEvent(new InputEvent(Input.GetKey(configuration.Shoot), x, y));
    }
}
