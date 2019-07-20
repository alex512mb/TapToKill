using UnityEngine;
using UnityEngine.SceneManagement;


public class PreloadingUI : MonoBehaviour
{
    public MonoBehaviour serverController;
    private void Start()
    {
        if (serverController == null)
        {
            Debug.LogError("serverController does not assigned in the inspector");
        }

        if (serverController is IServer)
        {
            IServer server = serverController as IServer;

            server.Connect(OnToServerConnected);
        }
        else
        {
            Debug.LogError("Server controller script must implement IServer interface");
        }
    }

    private void OnToServerConnected(bool success)
    {
        if (success)
        {
            LoadMainMenu();
        }
        else
        {
            Debug.LogError("Fail cennection to the server");
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
