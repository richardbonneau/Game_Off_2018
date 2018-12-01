using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class NextLevelZone : MonoBehaviour {
    GameManager gameManager;

    void Start() {
        //gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter() {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameManager.LoadNextLevel();
    }
}

