using UnityEngine;
using UnityEngine.Events;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private int oxygenDecreaseAmount;
    [SerializeField] private IntegerScriptableObject oxygen;
    [SerializeField] private UnityEvent gameOverEvent;
    public Armor _Armor;
    public RainSystem _RainSystem;

    private float _gameTime;
    
    void Awake()
    {
        _gameTime = 0f;
    }

    void Update()
    {
        if (_RainSystem.isRainEnabled && !_Armor.isArmorEnabled)
        {
            oxygenDecreaseAmount = 6;

        }
        else
        {
            oxygenDecreaseAmount = 2;
        }
        _gameTime += Time.deltaTime;

        if (_gameTime >= 1f)
        {
            oxygen.DecreaseInt(oxygenDecreaseAmount);
            _gameTime = 0f;
            if (oxygen.number <= 0)
            {
                gameOverEvent.Invoke();
            }
        }
    }
}
