using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public Text txtScores;
    public Text txtTime;
    public Button pauseButton;
    public Text txtPauseButton;

    private bool paused;

    private void Awake()
    {
        if (txtScores == null)
        {
            Debug.LogError("txtScores does not assigned in the inspector");
            return;
        }
        if (txtTime == null)
        {
            Debug.LogError("txtTime does not assigned in the inspector");
            return;
        }
        if (pauseButton == null)
        {
            Debug.LogError("pauseButton does not assigned in the inspector");
            return;
        }
        if (txtPauseButton == null)
        {
            Debug.LogError("txtPauseButton does not assigned in the inspector");
            return;
        }

        txtPauseButton.text = "Pause";
        SetScores(0);

        pauseButton.onClick.AddListener(OnClickPause);
    }

    private void OnClickPause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        txtPauseButton.text = paused ? "Resume" : "Pause";
    }


    public void SetScores(int scores)
    {
        txtScores.text = "Scores: " + scores;
    }
    public void SetTimeRemain(float remainSeconds)
    {
        txtTime.text = "Time: " + remainSeconds;
    }
}
