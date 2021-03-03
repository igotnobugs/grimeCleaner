using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class TilePattern : DirtPattern 
{
    //Dirt in between tiles 

    public Vector2 center;
    public int horizontalLines;
    public float horizontalSpacing;
    public float horizontalLength;

    public int verticalLines;
    public float verticalSpacing;
    public float verticalLength;

    public int maxDirt = 50;
    public int minDirt = 10;

    public override int SpawnPatternGetDirt(Dirt dirt, Action onDelete) {

        int dirtSpawns = 0;

        int dirtHorizontal = Random.Range(minDirt, maxDirt);


        float leftHorizontal = (horizontalSpacing * horizontalLines) / 2;
        leftHorizontal = center.x - leftHorizontal;

        //horizontalLines
        for (int i = 0; i < horizontalLines; i++) {
            if (dirtHorizontal <= 0) continue;

            int currentDirtSpawns = Random.Range(0, dirtHorizontal);
            dirtHorizontal -= currentDirtSpawns;

            for (int ii = 0; ii < currentDirtSpawns; ii++) {
                Vector3 randomPosition = new Vector3(leftHorizontal,
                                                    Random.Range(-horizontalLength, horizontalLength),
                                                    transform.position.z);
                randomPosition.y = center.y - randomPosition.y;
                Dirt spawnedDirt = Instantiate(dirt, randomPosition, transform.rotation);
                spawnedDirt.transform.parent = transform;
                spawnedDirt.onDelete = onDelete;
            }
            leftHorizontal += horizontalSpacing;
            dirtSpawns += currentDirtSpawns;
        }

        int dirtVertical = Random.Range(minDirt, maxDirt);
        float upVertical = (verticalSpacing * verticalLines) / 2;
        
        if (verticalLines % 2 == 0) {
            upVertical = center.x + upVertical;
        } else {
            upVertical = center.x;
        }

        //verticalLines
        for (int i = 0; i < verticalLines; i++) {
            if (dirtVertical <= 0) continue;

            int currentDirtSpawns = Random.Range(0, dirtVertical);
            dirtVertical -= currentDirtSpawns;

            for (int ii = 0; ii < currentDirtSpawns; ii++) {
                Vector3 randomPosition = new Vector3(Random.Range(-verticalLength, verticalLength),
                                                    upVertical,
                                                    transform.position.z);
                randomPosition.y = center.y - randomPosition.y;                
                Dirt spawnedDirt = Instantiate(dirt, randomPosition, transform.rotation);
                spawnedDirt.transform.parent = transform;
                spawnedDirt.onDelete = onDelete;
            }
            upVertical -= verticalSpacing;
            dirtSpawns += currentDirtSpawns;
        }

        return dirtSpawns;
    }

    private void Start() {
        
    }


    private void Update() {
        
    }
}
