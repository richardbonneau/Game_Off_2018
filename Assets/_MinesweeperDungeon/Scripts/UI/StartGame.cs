using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour {

    GameManager gameManager;

    void Update() {
        if (gameManager == null) gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager.isMainMenu == false) gameManager.isMainMenu = true;
    }

    public void GameStart() {
        print("in game start");
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().LoadNextLevel();
    }
}
