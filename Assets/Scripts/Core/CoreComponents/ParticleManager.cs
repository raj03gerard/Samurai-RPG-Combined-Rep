using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : CoreComponent
{
    //Transoform that will be the parent of spawned particles
    private Transform particleContainer;

    protected override void Awake()
    {
        base.Awake();

        //Setting the references 
        particleContainer = GameObject.FindGameObjectWithTag("ParticleContainer").transform;
    }

    //Functions which will instantiate particles as children of this game object.
    public GameObject StartParticles(GameObject particlePrefab, Vector2 position, Quaternion rotation)
    {
        return Instantiate(particlePrefab, position, rotation, particleContainer);
    }

    //Possibility instantiate particles if we don't want to specify position and rotation
    public GameObject StartParticles(GameObject particlePrefab)
    {
        return StartParticles(particlePrefab, transform.position, Quaternion.identity);
    }

    //Generates particles with random rotation
    public GameObject StartParticlesWithRandomRotation(GameObject particlePrefab)
    {
        //Generate a random rotation along the z-axis
        var randomRotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0f, 360f));
        //Spawn particles and return
        return Instantiate(particlePrefab, transform.position, randomRotation, particleContainer);
    }
}
