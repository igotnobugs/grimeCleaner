using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour 
{

    public Vector3 defaultPosition;

    private bool isCenter = true;

    private Vector3 targetPosition;

    public Wipe wipeGameObject;

    private void Start() {
        defaultPosition = gameObject.transform.position;
        targetPosition = defaultPosition;
    }


    private void Update() {
        
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
            targetPosition,
            0.2f);

        if (Input.touchCount <= 0) return;

        Touch touch = Input.GetTouch(0);

        //Two fingers move
        if (Input.touchCount == 2) {
            Vector2 touchDelta = touch.deltaPosition / 100.0f;
            targetPosition -= new Vector3(touchDelta.x, touchDelta.y);
            isCenter = false;
            return;

        }

        //Tap to center
        if (Input.touchCount == 1 && !isCenter) {
            //Touch touch = Input.GetTouch(0);
            if (touch.tapCount == 2) {
                targetPosition = defaultPosition;
                isCenter = true;
            }
        }

    }

}
