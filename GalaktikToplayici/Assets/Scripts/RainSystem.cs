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
    void Start()
    {
        particleSystem.Play();

    }

    void Update()
    {
        particleSystem.Stop();
        if (playerRb.transform.position.z >= rainStartPointZ && playerRb.transform.position.z < rainEndPointZ)
        {
            particleSystem.Play();
            isRainEnabled = true;

        }
        else if (playerRb.transform.position.z >= rainEndPointZ)
        {
            particleSystem.Stop();
            isRainEnabled = false;

        }
    }
}
