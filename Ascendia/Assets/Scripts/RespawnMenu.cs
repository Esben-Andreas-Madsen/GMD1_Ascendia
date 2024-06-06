using UnityEngine;
using UnityEngine.UI;

public class RespawnMenu : MonoBehaviour
{
    public GameObject respawnMenuUI;

    private void Start()
    {
        respawnMenuUI.SetActive(false);
    }

    public void ShowRespawnMenu()
    {
        respawnMenuUI.SetActive(true);
    }

    public void HideRespawnMenu()
    {
        respawnMenuUI.SetActive(false);
    }

    public void Respawn()
    {
        Debug.Log("Respawning player...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ExitToMain()
    {
        Time.timeScale = 1;
    }
}
