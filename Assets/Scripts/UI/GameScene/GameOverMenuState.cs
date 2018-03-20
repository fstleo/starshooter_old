using UnityEngine;
using UnityEngine.UI;
using Menu;
using UnityEngine.SceneManagement;

public class GameOverMenuState : MenuStateView {

    [SerializeField]
    Text ScoreLabel;

    [SerializeField]
    Text TopScoreLabel;

    protected override void Awake()
    {
        base.Awake();
        EventManager.Instance.AddListenerOnce<GameOverEvent>(ProcessGameOver);
        EventManager.Instance.AddListener<ScoresChangeEvent>(ChangeScoresLabel);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (EventManager.Instance == null)
            return;        
        EventManager.Instance.RemoveListener<ScoresChangeEvent>(ChangeScoresLabel);
    }

    private void ProcessGameOver(GameOverEvent ev)
    {
        Show();
    }

    public override void Show()
    {
        base.Show();
        TopScoreLabel.text = ScoresManager.TopScore.ToString();
    }

    protected override void HandleBackEvent(BackEvent ev)
    {
        _MenuButtonClick();
    }

    private void ChangeScoresLabel(ScoresChangeEvent ev)
    {
        ScoreLabel.text = ev.Scores.ToString();
    }

    public void _RestartButtonClick()
    {
        SetState(State.Game);
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }

    public void _MenuButtonClick()
    {
        SetState(State.MainMenu);
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }    
}
