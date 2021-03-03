using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class DirtPattern : MonoBehaviour 
{

    private void Start() {
        
    }


    private void Update() {
        
    }

    public abstract int SpawnPatternGetDirt(Dirt dirt, Action onDelete);
}
