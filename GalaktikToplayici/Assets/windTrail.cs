using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class windTrail : MonoBehaviour
{
    public Wind _wind;
    public TrailRenderer _trailRenderer;
    void Start()
    {
    }

    void Update()
    { 
        Vector3 currentPosition = transform.position;
        if (_wind.GetIsApplyingForce())
        {
            _trailRenderer.enabled = true;
        }
            
        else
        {
            _trailRenderer.enabled = false;


        }
    }
}
