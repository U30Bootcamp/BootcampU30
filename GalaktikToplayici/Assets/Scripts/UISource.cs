using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISource : MonoBehaviour
{
    public int space, water, astorid, shield;

    public TextMeshProUGUI space_Text, water_Text, astroid_Text, shield_Text; 
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        space_Text.text = " " + space;
        water_Text.text = " " + water;
        astroid_Text.text = " " + astorid;
        shield_Text.text = " " + shield;

    }
}
