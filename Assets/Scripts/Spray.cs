using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour 
{
    public bool isEnabled = true;
    public ParticleSystem particleUsed;
    public float efficiency = 0.0f;
    //public Color appliedColor;

    private bool applied = false;

    private void Start() {

    }


    private void Update() {
        if (!isEnabled) return;

        if ((!applied && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)) {

            Plane plane = new Plane(Camera.main.transform.forward * -1, transform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.touchCount > 1) return;

            if (plane.Raycast(ray, out float rayDist)) {
                transform.position = ray.GetPoint(rayDist);
                Instantiate(particleUsed, transform.position, transform.rotation);              
            }
            applied = true;
        }

        if (applied && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            applied = false;
        }
    }

    public void SetActivate(bool isActivate) {
        isEnabled = isActivate;
        gameObject.SetActive(isEnabled);
    }

    public void SetProperties(Solution solution) {
        particleUsed = solution.solutionParticle;
        gameObject.transform.localScale = new Vector2(solution.size, solution.size);
    }
}
