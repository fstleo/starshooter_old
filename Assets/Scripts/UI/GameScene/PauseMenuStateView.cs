using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Menu;
using UnityEngine.SceneManagement;

public class PauseMenuStateView : MenuStateView
{

    public override void Show()
    {
        base.Show();
        Time.timeScale = 0;
    }

    protected override void HandleBackEvent(BackEvent ev)
    {
        _ReturnButtonClick();
    }

    public void _ReturnButtonClick()
    {
        SetState(State.Game);
    }

	public void _OptionsButtonClick()
    {
        SetState(State.Options);
    }

    public void _MenuButtonClick()
    {
        SceneManager.LoadSceneAsync(1);
        SetState(State.MainMenu);
    }
}
