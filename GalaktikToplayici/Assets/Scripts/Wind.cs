using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Wind : MonoBehaviour
{
    private float timer = 0f;
    private int timeBetweenWinds;
    public float windTime = 5f;
    private Rigidbody rb;
    public float movementSpeed = 1f;
    private bool isApplyingForce = false;
    private Vector3 forceDirection;
    public int minTime, maxTime; 
    public MovementController _MovementController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {            
        int timeBetweenWinds = Random.Range(minTime, maxTime);
        timer += Time.deltaTime;

        if (timer >= timeBetweenWinds && !isApplyingForce)
        {
            timer = 0f;
            ApplyForceForDuration(Vector3.forward);
                    
            
        }

        if (isApplyingForce)
        {
            timer += Time.deltaTime;
            if (timer >= windTime )
            {
                isApplyingForce = false;
                timer = 0f;
            }
            else
            {
                if (_MovementController.GetIsMoving())
                {
                    rb.AddForce(forceDirection * (movementSpeed + 20), ForceMode.Impulse);
                }
                else
                {
                    rb.AddForce(forceDirection * movementSpeed, ForceMode.Impulse);

                }
            }
        }
    }

    void ApplyForceForDuration(Vector3 direction)
    {
        isApplyingForce = true;
        forceDirection = direction;
    }

    public bool GetIsApplyingForce()
    {
        return isApplyingForce;
    }
}