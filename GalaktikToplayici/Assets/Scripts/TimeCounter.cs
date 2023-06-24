using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private int oxygenDecreaseAmount;
    [SerializeField] private OxygenScriptableObject oxygen;
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
            oxygen.DecreaseOxygen(oxygenDecreaseAmount);
            _gameTime = 0f;
        }
    }
}
