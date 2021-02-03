using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour 
{

    public Vector3 defaultPosition;

    private void Start() {
        defaultPosition = gameObject.transform.position;
    }


    private void Update() {
        if (Input.touchCount == 2) {

            Touch touch = Input.GetTouch(0);

            Vector2 touchDelta = touch.deltaPosition / 100.0f;
            gameObject.transform.position += new Vector3(touchDelta.x, touchDelta.y);

        }
        else {
            ResetPosition();
        }
    }

    private void ResetPosition() {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
            defaultPosition, 
            0.2f);
    }
}
