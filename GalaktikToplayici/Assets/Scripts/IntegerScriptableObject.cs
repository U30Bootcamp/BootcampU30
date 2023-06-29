using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = nameof(IntegerScriptableObject), menuName  = "Scriptable Objects/Int")]
public class IntegerScriptableObject : ScriptableObject
{
    public int number;
    [SerializeField] private int initalNumber;
    [NonSerialized] public UnityEvent<int> IntChangeEvent;

    private void OnEnable()
    {
        number = initalNumber;
        if (IntChangeEvent == null)
        {
            IntChangeEvent = new UnityEvent<int>();
        }
    }

    public void DecreaseInt(int amount)
    {
        number -= amount;
        IntChangeEvent.Invoke(number);
    }
    
    public void IncreaseInt(int amount)
    {
        number += amount;
        IntChangeEvent.Invoke(number);
    }
    
    public void SetInt(int amount)
    {
        number = amount;
        IntChangeEvent.Invoke(number);
    }
}