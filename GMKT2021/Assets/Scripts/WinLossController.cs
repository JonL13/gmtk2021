using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinLossController : MonoBehaviour{

    public TextMeshProUGUI missionOutcomeDisplay;
    public TextMeshProUGUI missionOutcomeSubtextDisplay;
    public string nextSceneName = "EndScene";

    private FuelController homeFuelController;
    private bool hasWon = false;
    private bool hasLost = false;

    void Start(){
        homeFuelController = gameObject.GetComponent<FuelController>();
        if(homeFuelController == null) {
            Debug.Log("HomeFuelController is null");
        }
        missionOutcomeDisplay.enabled = false;
        missionOutcomeSubtextDisplay.enabled = false;
    }

    void Update(){
        if (Input.GetButtonDown("Cancel")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (hasWon) {
            if (Input.GetButtonDown("Submit")) {
                SceneManager.LoadScene(nextSceneName);
            }
        }

        if (hasLost) {
            if (Input.GetButtonDown("Submit")) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if(hasWon) {
            return;
        }

        if(homeFuelController.fuel >= homeFuelController.maxFuel) {
            hasWon = true;
            winGame();
        }

        if(homeFuelController.fuel < 0) {
            hasLost = true;
            loseGame();
        }
    }

    private void winGame() {
        missionOutcomeDisplay.SetText("SUCCESS");
        missionOutcomeSubtextDisplay.SetText("Base refueled\nPress ENTER to continue...");
        missionOutcomeDisplay.enabled = true;
        missionOutcomeSubtextDisplay.enabled = true;
    }

    private void loseGame() {
        missionOutcomeDisplay.SetText("FAILURE");
        missionOutcomeSubtextDisplay.SetText("Fuel eliminated from base\nPress ENTER to retry");
        missionOutcomeDisplay.enabled = true;
        missionOutcomeSubtextDisplay.enabled = true;
    }
}
