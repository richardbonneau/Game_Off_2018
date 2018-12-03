using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour {

    GameObject tutorialUI;

    // Use this for initialization
    void Start() {
        tutorialUI = GameObject.FindWithTag("UI_Tutorial").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            if (tutorialUI.activeSelf) tutorialUI.SetActive(false);
            else tutorialUI.SetActive(true);
        }
    }
    public void OpenHowToPlay() {
        tutorialUI.SetActive(true);
    }
}
