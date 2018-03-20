using UnityEngine;
using UnityEngine.UI;
using Menu;

public class GameMenuStateView : MenuStateView
{

    [SerializeField]
    Text scoresLabel;

    [SerializeField]
    Text livesCountLabel;

    protected override void Awake()
    {
        base.Awake();
        scoresLabel.text = "";
        livesCountLabel.text = "";
        EventManager.Instance.AddListener<LivesCountChangeEvent>(ChangeLivesCountLabel);
        EventManager.Instance.AddListener<ScoresChangeEvent>(ChangeScoresLabel);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (EventManager.Instance == null)
            return;
        EventManager.Instance.RemoveListener<LivesCountChangeEvent>(ChangeLivesCountLabel);
        EventManager.Instance.RemoveListener<ScoresChangeEvent>(ChangeScoresLabel);
    }

    public override void Show()
    {
        base.Show();
        Time.timeScale = 1;
    }

    private void ChangeLivesCountLabel(LivesCountChangeEvent ev)
    {
        livesCountLabel.text = ev.LivesCount.ToString();
    }

    private void ChangeScoresLabel(ScoresChangeEvent ev)
    {
        scoresLabel.text = ev.Scores.ToString();
    }

    protected override void HandleBackEvent(BackEvent ev)
    {
        SetState(State.Pause);
    }    

}
