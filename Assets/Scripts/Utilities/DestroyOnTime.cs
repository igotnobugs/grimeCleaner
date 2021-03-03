using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour 
{
    public float seconds = 1;

    private void Start() {
        Destroy(gameObject, seconds);
    }
}
