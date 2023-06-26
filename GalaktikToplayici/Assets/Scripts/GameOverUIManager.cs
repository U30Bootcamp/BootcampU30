using UnityEngine;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject gameCanvas;

    private void Awake()
    {
        gameOverCanvas.SetActive(false);
    }

    public void GameOverEvent()
    {
        Time.timeScale = 0f;
        gameCanvas.SetActive(false);
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
