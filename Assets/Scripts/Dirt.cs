using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Dirt : MonoBehaviour 
{
    public Tool correctTool;
    public GameObject particleCorrect;

    public Color currentColor;

    public Action onDelete;
    public float efficiency = 1.0f;

    private void Start() {
        currentColor = GetComponent<SpriteRenderer>().color;
    }


    private void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
       
        if (collision.TryGetComponent(out Wipe wipe)) {
            if (GameManager.currentTool == correctTool) {
                currentColor.a -= (wipe.strength * 2 * efficiency);
            } else {
                currentColor.a -= wipe.strength * efficiency;
            }


            GetComponent<SpriteRenderer>().color = currentColor;

            if (currentColor.a <= 0) {             
                onDelete?.Invoke();

                if (GameManager.currentTool == correctTool) {
                    Instantiate(particleCorrect, gameObject.transform.position, gameObject.transform.rotation);
                }
                
                Destroy(gameObject, 0.0f);
            }
        }

        if (collision.TryGetComponent(out Spray spray)) {
            efficiency = spray.efficiency;
            float oldAlpha = currentColor.a;
            currentColor = spray.particleUsed.main.startColor.color;
            //currentColor = spray.appliedColor;
            currentColor.a = oldAlpha;
            GetComponent<SpriteRenderer>().color = currentColor;
        }
    }



}
