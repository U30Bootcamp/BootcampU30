using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorCounter : MonoBehaviour
{
    public int armorCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Armor"))
        {
            armorCount++;
        }
    
    }

    public int GetArmorCount()
    {
        return armorCount;
    }
    
}
