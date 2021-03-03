using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour 
{
    //Player tools
    public Wipe wiper;
    public Spray sprayer;

    public Surface currentSurface;

    public Image progressBar;
    public float progress;
    public int currentDirt;
    public int totalDirt;
    public TextMeshProUGUI time;

    public float currentTime = 0.0f;
    public bool startTime = false;
    private bool isResetting = false;

    public static Tool currentTool;
    public static Solution currentSolution;
    public Button toolUsing;
    public Button solutionUsing;

    public bool sprayEquipped = true;

    public Color disabledColor;
    public Color enabledColor;

    public Score scorePanel;

    private void Start() {
        totalDirt = currentSurface.SpawnAndGetDirt(DirtDeleted);
        currentDirt = totalDirt;
        startTime = true;
    }


    private void Update() {
        progress = (totalDirt - currentDirt) / (float)totalDirt;
        progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, progress, 0.1f);
        
        if (startTime) {
            currentTime += Time.deltaTime;
        }
        time.text = currentTime.ToString("#0.00");
    }

    public void DirtDeleted() {
        currentDirt--;
        if (currentDirt < 0) {
            currentDirt = 0;
        }

        if (currentDirt == 0) {
            if (!isResetting) {
                StartCoroutine(ResetSpawn());
                isResetting = true;
            }
        }

    }

    private IEnumerator ResetSpawn() {
        startTime = false;

        scorePanel.DisplayScore(currentTime, 40, 25, 10);

        yield return new WaitForSeconds(3.0f);

        scorePanel.HideScore();

        totalDirt = currentSurface.SpawnAndGetDirt(DirtDeleted);
        currentDirt = totalDirt;
        isResetting = false;
        startTime = true;
        currentTime = 0.0f;
        yield break;
    }

    public void SetTool(Tool toolToUse) {
        currentTool = toolToUse;
        toolUsing.GetComponent<Image>().sprite = toolToUse.toolSprite;
        wiper.SetProperties(toolToUse);
        ToggleSpray(false);
    }

    public void SetSolution(Solution solutionToUse) {
        currentSolution = solutionToUse;
        solutionUsing.GetComponent<Image>().sprite = solutionToUse.solutionSprite;
        sprayer.SetProperties(solutionToUse);
        ToggleSpray(true);
    }

    // toggles between wipe or spray mode
    public void ToggleSpray(bool sprayMode) {
        sprayEquipped = sprayMode;
        wiper.SetActivate(!sprayEquipped);
        sprayer.SetActivate(sprayEquipped);
        if (sprayEquipped) {
            toolUsing.GetComponent<Image>().color = disabledColor;
            solutionUsing.GetComponent<Image>().color = enabledColor;
        } else {
            toolUsing.GetComponent<Image>().color = enabledColor;
            solutionUsing.GetComponent<Image>().color = disabledColor;
        }
    }
}
