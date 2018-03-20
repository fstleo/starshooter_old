using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresManager : MonoBehaviour {

    public static int TopScore
    {
        get
        {
            return PlayerPrefs.GetInt("TopScores", 0);
        }
        set
        {
            PlayerPrefs.SetInt("TopScores", value);
        }
    }

    int Complexity = 0;
    public int Scores = 0;

    int[] ComplexityGradation = new int[] { 50, 100, 200, 400, 800, 1600, 3200 };
    
    private void Awake () {
        EventManager.Instance.AddListener<EnemyDie>(ProcessEnemyDeath);
        EventManager.Instance.AddListener<ScoresPowerUpEvent>(ProcessScoresPowerUp);
    }

    private void Start()
    {
        AddScores(0);
    }

    private void OnDestroy()
    {
        if (EventManager.Instance == null)
            return;
        EventManager.Instance.RemoveListener<EnemyDie>(ProcessEnemyDeath);
        EventManager.Instance.RemoveListener<ScoresPowerUpEvent>(ProcessScoresPowerUp);
    }

    private void ProcessEnemyDeath(EnemyDie ev)
    {
        AddScores(ev.Scores);
    }

    private void ProcessScoresPowerUp(ScoresPowerUpEvent ev)
    {
        AddScores(ev.Scores);
    }

    private void AddScores(int scores)
    {
        Scores += scores;
        if (Scores > TopScore)
            TopScore = Scores;
        EventManager.Instance.QueueEvent(new ScoresChangeEvent(Scores));
        if (Scores > ComplexityGradation[Complexity])
        {
            Complexity++;
            EventManager.Instance.QueueEvent(new ComplexityUpEvent(Complexity));
        }
    }



}
