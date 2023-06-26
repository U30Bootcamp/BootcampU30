using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;

    private void Awake()
    {
        gameOverCanvas.SetActive(false);
    }

    public void GameOverEvent()
    {
        Time.timeScale = 0f;
        gameOverCanvas.SetActive(true);
    }

    public void ReviveWithAds()
    {
        Debug.Log("watch ads");
    }
    
    public void RestartLevel()
    {
        Debug.Log("restart level");
    }

    public void GoToMainMenu()
    {
        Debug.Log("main menu");
    }
}
