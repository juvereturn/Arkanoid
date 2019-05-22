using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Script Destroys Particle Effect With Its Time duration
/// </summary>

[RequireComponent(typeof(ParticleSystem))]
public class ParticleAutoDestroy : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
    }
}
