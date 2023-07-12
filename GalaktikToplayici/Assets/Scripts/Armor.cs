using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class Armor : MonoBehaviour
{

    public int armorCount = 0;
    private float timer = 0f;
    public ArmorCounter _armorCounter;
    public Renderer objectRenderer;
    public bool isArmorEnabled = false;


    private void Start()
    {
        objectRenderer.enabled = false;
    }

    void Update()
    {
        armorCount = _armorCounter.GetArmorCount();
        if (armorCount >= 3)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                objectRenderer.enabled = !objectRenderer.enabled;
                isArmorEnabled = !isArmorEnabled;
            }
        }
    }
    
}
