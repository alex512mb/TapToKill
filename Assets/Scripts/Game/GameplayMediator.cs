using UnityEngine;

public class GameplayMediator : MonoBehaviour
{
    public GameplayUI gameplayUI;
    public GameplayController gameplayController;
    public GameTimer gameTimer;
    public SpawnerInArea spawnerPlayerTargets;
    public GameObject gameEndUI;


    private void Awake()
    {
        if (gameplayUI == null)
        {
            Debug.LogError("gameplayUI does not assigned in the inspector");
            return;
        }
        if (gameplayController == null)
        {
            Debug.LogError("gameplayController does not assigned in the inspector");
            return;
        }
        if (gameTimer == null)
        {
            Debug.LogError("gameTimer does not assigned in the inspector");
            return;
        }
        gameTimer.OnTimeOver += OnGameTimeOver;
        gameplayController.OnScoresChanges += OnPlayerScoresChanges;
        gameTimer.OnTimeChanged += OnTimeChanged;
    }

    private void OnTimeChanged()
    {
        float roundedTimeRamain = (float)System.Math.Round(gameTimer.TimeRemain, 1);
        gameplayUI.SetTimeRemain(roundedTimeRamain);
    }

    private void OnGameTimeOver()
    {
        spawnerPlayerTargets.enabled = false;
        gameEndUI.SetActive(true);
    }

    private void OnPlayerScoresChanges(int scores)
    {
        gameplayUI.SetScores(scores);
    }
}
