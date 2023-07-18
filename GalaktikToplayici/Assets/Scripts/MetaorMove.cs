using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaorMove : MonoBehaviour
{
    public GameObject player;

    public MetaorScript mScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mScript)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 50f);
        }
        
    }
}