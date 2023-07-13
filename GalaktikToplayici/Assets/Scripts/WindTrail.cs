using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WindTrail : MonoBehaviour
{
    public Wind _wind;
    public TrailRenderer _trailRenderer;
    public AudioSource _audioSource;

    void Start()
    {
        _audioSource.Stop();
        _audioSource.enabled = false;
    }

    void Update()
    { 
        Vector3 currentPosition = transform.position;
        if (_wind.GetIsApplyingForce())
        {
            _trailRenderer.enabled = true;
            _audioSource.enabled = true;

        }
            
        else
        {
            _trailRenderer.enabled = false;
            _audioSource.enabled = false;


        }
    }
}
