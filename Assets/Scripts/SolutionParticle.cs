﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionParticle : MonoBehaviour 
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start() {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other) {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents) {
            if (rb) {
                if (other.TryGetComponent(out Dirt dirt)) {
                    Debug.Log("Sprayed");
                }
            }
            i++;
        }
    }
}
