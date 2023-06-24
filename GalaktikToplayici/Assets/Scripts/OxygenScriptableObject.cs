using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = nameof(OxygenScriptableObject), menuName  = "ScriptableObjects/Oxygen")]
public class OxygenScriptableObject : ScriptableObject
{
    public int oxygen;
    [SerializeField] private int maxOxygen = 100;
    [NonSerialized] public UnityEvent<int> OxygenChangeEvent;

    private void OnEnable()
    {
        oxygen = maxOxygen;
        if (OxygenChangeEvent == null)
        {
            OxygenChangeEvent = new UnityEvent<int>();
        }
    }

    public void DecreaseOxygen(int amount)
    {
        oxygen -= amount;
        OxygenChangeEvent.Invoke(oxygen);
    }
    
    public void IncreaseOxygen(int amount)
    {
        oxygen += amount;
        OxygenChangeEvent.Invoke(oxygen);
    }
}