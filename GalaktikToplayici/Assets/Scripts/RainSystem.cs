using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSystem : MonoBehaviour
{
    public Rigidbody playerRb;
    public float rainStartPointZ;
    public float rainEndPointZ;
    public ParticleSystem particleSystem;
    public Armor armor;

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
        }
        else if (playerRb.transform.position.z >= rainEndPointZ)
        {
            particleSystem.Stop();
        }
    }
}
