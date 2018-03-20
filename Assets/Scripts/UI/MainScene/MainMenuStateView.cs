using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Menu;
using UnityEngine.SceneManagement;

public class MainMenuStateView : MenuStateView {

    protected override void HandleBackEvent(BackEvent ev)
    {
        _ExitButtonClick();
    }

    public void _PlayButtonClick()
    {
        SetState(State.Game);
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }

    public void _OptionsButtonClick()
    {
        SetState(State.Options);
    }

    public void _ExitButtonClick()
    {
        Application.Quit();
    }

}
