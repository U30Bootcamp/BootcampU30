using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = nameof(IntegerScriptableObject), menuName  = "Scriptable Objects/Int")]
public class IntegerScriptableObject : ScriptableObject
{
    [SerializeField] private int initalNumber;
    [NonSerialized] public UnityEvent<int> IntChangeEvent;
    private int _number;

    private void OnEnable()
    {
        _number = initalNumber;
        if (IntChangeEvent == null)
        {
            IntChangeEvent = new UnityEvent<int>();
        }
    }

    public void DecreaseInt(int amount)
    {
        _number -= amount;
        IntChangeEvent.Invoke(_number);
    }
    
    public void IncreaseInt(int amount)
    {
        _number += amount;
        IntChangeEvent.Invoke(_number);
    }
}