using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wipe : MonoBehaviour 
{
    public float strength = 0.2f;
    public bool isEnabled = true;

    private CircleCollider2D wipeCollider;

    private void Start() {
        wipeCollider = GetComponent<CircleCollider2D>();
    }


    private void Update() {
        if (!isEnabled) return;

        if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            || Input.GetMouseButton(0) ) {

            Plane plane = new Plane(Camera.main.transform.forward * -1, transform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.touchCount > 1) return;

            if (plane.Raycast(ray, out float rayDist)) {
                transform.position = ray.GetPoint(rayDist);

            }
        }
    }

    public void SetActivate(bool isActivate) {
        isEnabled = isActivate;
        gameObject.SetActive(isEnabled);
    }

    public void SetProperties(Tool tool) {
        strength = tool.strength;
        gameObject.transform.localScale = new Vector2(tool.size, tool.size);
    }

}
