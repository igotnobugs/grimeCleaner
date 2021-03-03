using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Surface : MonoBehaviour 
{
    public Dirt dirtToSpawn;
    public DirtPattern pattern;

    private void Start() {

    }


    private void Update() {

    }

    //Spawn dirt and get amount spawned
    public int SpawnAndGetDirt(Action onDelete) {
        return pattern.SpawnPatternGetDirt(dirtToSpawn, onDelete);
    }
}
 