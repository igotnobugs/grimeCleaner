using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
    public Image[] stars;
    public ParticleSystem starParticle;
    private int score = 0;

    public void Start() {
        for (int i = 0; i < stars.Length; i++) {
            stars[i].enabled = false;
        }

        gameObject.SetActive(false);
    }


    public void DisplayScore(float totalTime, float oneTime, float twoTime, float threeTime) {
        gameObject.SetActive(true);

        if (totalTime <= threeTime) {
            score = 3;
        } else if (totalTime <= twoTime) {
            score = 2;
        } else if (totalTime <= oneTime) {
            score = 1;
        }

        StartCoroutine(ShowStars());

    }


    private IEnumerator ShowStars() {

        for (int i = 0; i < score; i++) {
            stars[i].enabled = true;
            Instantiate(starParticle, stars[i].rectTransform.position, gameObject.transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
    }

    public void HideScore() {
        StopCoroutine(ShowStars());
        
        for (int i = 0; i < stars.Length; i++) {
            stars[i].enabled = false;
        }

        gameObject.SetActive(false);
    }
}
