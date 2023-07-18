using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector3 controlDigi;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveSpeed = 70f;
        if (Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Moved)
            {
               
                if (touch.deltaPosition.x > 0 )
                {
                   
                    controlDigi = new Vector3(1*moveSpeed*Time.deltaTime, 1,1);
                }

                if (touch.deltaPosition.x < 0)
                {
                    
                    controlDigi = new Vector3(-1*moveSpeed*Time.deltaTime, 1,1);
                    
                }

            }
            if (touch.phase == TouchPhase.Ended)
            {
                controlDigi = new Vector3(0, 1,1);
                
            }
            
        }
        else
        {
            controlDigi = new Vector3(0, 1,1);
        }
    }

    void GetTouch()
    {
        
    }
}
