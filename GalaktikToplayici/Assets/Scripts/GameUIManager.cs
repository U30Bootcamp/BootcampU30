using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private IntegerScriptableObject oxygen;
    [SerializeField] private Slider oxygenSlider;
    [SerializeField] private IntegerScriptableObject distance;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private IntegerScriptableObject highScore;
    [SerializeField] private TextMeshProUGUI highScoreText;
    
    private void Start()
    {
        SetOxygenSliderValue(oxygen.number);
        SetDistanceTextValue(distance.number);
        SetHighScoreTextValue(highScore.number);
    }

    private void OnEnable()
    {
        oxygen.IntChangeEvent.AddListener(SetOxygenSliderValue);
        distance.IntChangeEvent.AddListener(SetDistanceTextValue);
        highScore.IntChangeEvent.AddListener(SetHighScoreTextValue);
    }

    private void OnDisable()
    {
        oxygen.IntChangeEvent.RemoveListener(SetOxygenSliderValue);
        distance.IntChangeEvent.RemoveListener(SetDistanceTextValue);
        highScore.IntChangeEvent.RemoveListener(SetHighScoreTextValue);
    }

    private void SetOxygenSliderValue(int amount)
    {
        oxygenSlider.value = amount / 100.0f;
    }
    
    private void SetDistanceTextValue(int amount)
    {
        distanceText.text = amount.ToString();
    }
    
    private void SetHighScoreTextValue(int amount)
    {
        highScoreText.text = amount.ToString();
    }
}
