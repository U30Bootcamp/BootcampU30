using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private IntegerScriptableObject oxygen;
    [SerializeField] private Slider oxygenSlider;

    private void Start()
    {
        SetOxygenSliderValue(oxygen.number);
    }

    private void OnEnable()
    {
        oxygen.IntChangeEvent.AddListener(SetOxygenSliderValue);
    }

    private void OnDisable()
    {
        oxygen.IntChangeEvent.RemoveListener(SetOxygenSliderValue);
    }

    private void SetOxygenSliderValue(int amount)
    {
        oxygenSlider.value = amount / 100.0f;
    }
}
