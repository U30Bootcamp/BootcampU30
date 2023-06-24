using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private OxygenScriptableObject oxygen;

    private void OnEnable()
    {
        oxygen.OxygenChangeEvent.AddListener(PrintOxygen);
    }

    private void OnDisable()
    {
        oxygen.OxygenChangeEvent.RemoveListener(PrintOxygen);
    }

    public void PrintOxygen(int amount)
    {
        Debug.Log("oxygen level: " + amount);
    }
}
