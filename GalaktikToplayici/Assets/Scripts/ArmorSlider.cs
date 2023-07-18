using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorSlider : MonoBehaviour
{
    [SerializeField] private Slider oxygenSlider;
    [SerializeField] private IntegerScriptableObject armor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        oxygenSlider.value = armor.number / 100f;
    }
}
