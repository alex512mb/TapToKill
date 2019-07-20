using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button buttonStart;

    private void Awake()
    {
        if (buttonStart == null)
        {
            Debug.LogError("buttonStart does not assigned in the inspector");
        }

        buttonStart.onClick.AddListener(OnClickStart);
    }

    private void OnClickStart()
    {
        LoadGame();
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
