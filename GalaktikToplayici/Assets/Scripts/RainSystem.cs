using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSystem : MonoBehaviour
{
    public Rigidbody playerRb;
    public float rainStartPointZ;
    public float rainEndPointZ;
    public ParticleSystem particleSystem;
    public bool isRainEnabled = false;
    public AudioSource _audioSource;
    void Start()
    {
        particleSystem.Play();
        _audioSource.enabled = false;
    }

    void Update()
    {
        particleSystem.Stop();
        if (playerRb.transform.position.z >= rainStartPointZ && playerRb.transform.position.z < rainEndPointZ)
        {
            particleSystem.Play();
            isRainEnabled = true;
            if (isRainEnabled)
            {
                _audioSource.enabled = true;
            }
        }

        
        else 
        {
            particleSystem.Stop();
            isRainEnabled = false;
            _audioSource.enabled = false;
        }
        
    }
}
