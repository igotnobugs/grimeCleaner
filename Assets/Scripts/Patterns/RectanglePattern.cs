using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RectanglePattern : DirtPattern 
{

    public Vector2 center;
    public Vector2 startingRectangleSize;
    public float spacing;

    public int maxDirt = 50;
    public int minDirt = 10;

    public override int SpawnPatternGetDirt(Dirt dirt, Action onDelete) {
        throw new NotImplementedException();
    }


    /*
    public override int SpawnPatternGetDirt(Dirt dirt, Action onDelete) {
        int dirtSpawns = 0;

        int dirtHorizontal = Random.Range(minDirt, maxDirt);


        float horizontal = (spacing * horizontalLines) / 2;
        leftHorizontal = center.x - leftHorizontal;

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

        return dirtSpawns;
    }
    */


}
