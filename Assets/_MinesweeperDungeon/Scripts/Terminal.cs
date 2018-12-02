using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour {

    bool isPlayerNear = false;
    GameObject finalSolution;
    bool finalSolutionOpen;
    GameObject hero;
    void OnTriggerEnter() {
        isPlayerNear = true;
        print("trigger");
    }
    void OnTriggerExit() {
        isPlayerNear = false;
        print("exiting");
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNear) {
            finalSolution = GameObject.FindWithTag("UI_SubmitSolution").transform.GetChild(0).gameObject;
            if (finalSolution.activeSelf) {
                finalSolutionOpen = false;
            } else {
                finalSolutionOpen = true;
            }
        }

        if (finalSolutionOpen) {
            if (hero == null) hero = GameObject.FindWithTag("Player").gameObject;
            hero.GetComponent<vp_FPInput>().MouseCursorForced = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            vp_Utility.LockCursor = false;
            finalSolution.SetActive(true);
        } else {
            finalSolution.SetActive(false);
        }
    }

    public void SubmitTerminal() {

    }
    public void ExitTerminal() {
        finalSolutionOpen = false;
    }
}
