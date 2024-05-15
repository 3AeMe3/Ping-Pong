using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticles : MonoBehaviour
{
    ParticleSystem particlesSystem;

    private void Awake()
    {
        particlesSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (particlesSystem.isPlaying)
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
