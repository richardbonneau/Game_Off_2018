using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class NextLevelZone : MonoBehaviour {

    GameManager gameManager;

    // Use this for initialization
    void Start() {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter() {
        print("trigger");
        gameManager.LoadNextLevel();
    }
}

