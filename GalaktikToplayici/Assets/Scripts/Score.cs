using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private IntegerScriptableObject oxygen;
    [SerializeField] private IntegerScriptableObject armor;
    public UISource source;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            if (armor.number > 0)
            {
                armor.number -= 2;
            }
        }
        
        if (other.gameObject.CompareTag("shield"))
        {
            if (armor.number <100)
            {
                armor.number += 5;
                source.shield += 1;
            }
        }
        if (other.gameObject.CompareTag("water"))
        {
            if (oxygen.number < 100)
            {
                oxygen.number += 10;
                source.water += 1;
            }
        }
        if (other.gameObject.CompareTag("spaceship"))
        {
            source.space += 1;
        }
        if (other.gameObject.CompareTag("metaor"))
        {
            source.astorid += 1;
        }
        
    }
}
