using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{

    public Rigidbody playerRb;
    public int armorCount = 0;
    public bool isArmorEnabled = false;
   

    void Update()
    {
        if (armorCount >= 3)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                isArmorEnabled = !isArmorEnabled;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Armor"))
        {
            armorCount++;
        }
    
    }

    public bool GetIsArmorEnabled()
    {
        return isArmorEnabled;
    }
}
