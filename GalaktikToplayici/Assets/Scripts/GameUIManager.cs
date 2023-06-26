using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private IntegerScriptableObject oxygen;
    
    private void OnEnable()
    {
        oxygen.IntChangeEvent.AddListener(PrintOxygen);
    }

    private void OnDisable()
    {
        oxygen.IntChangeEvent.RemoveListener(PrintOxygen);
    }

    public void PrintOxygen(int amount)
    {
        Debug.Log("Oxygen level: " + amount);
    }
}
