using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{
    public Button buttonExit;
    public Button buttonRestart;

    private void Awake()
    {
        if (buttonExit == null)
        {
            Debug.LogError("buttonExit does not assigned in the inspector");
            return;
        }
        if (buttonRestart == null)
        {
            Debug.LogError("buttonRestart does not assigned in the inspector");
            return;
        }
        buttonExit.onClick.AddListener(OnClickExit);
        buttonRestart.onClick.AddListener(OnClickRestart);
    }

    private void OnClickExit()
    {
        LoadMainMenu();
    }

    private void OnClickRestart()
    {
        ReloadLevel();
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
