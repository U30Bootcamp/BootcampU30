using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private int oxygenDecreaseAmount;
    [SerializeField] private IntegerScriptableObject oxygen;
    private float _gameTime;
    
    void Awake()
    {
        _gameTime = 0f;
    }

    void Update()
    {
        _gameTime += Time.deltaTime;

        if (_gameTime >= 1f)
        {
            oxygen.DecreaseInt(oxygenDecreaseAmount);
            _gameTime = 0f;
        }
    }
}
