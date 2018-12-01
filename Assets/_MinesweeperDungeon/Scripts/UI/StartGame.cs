using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour {

    GameManager gameManager;
    void Start() {
        Time.timeScale = 1;

    }
    void Update() {
        Destroy(GameObject.FindGameObjectsWithTag("GameManager")[1]);

        if (gameManager == null) gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameManager.isMainMenu = true;
        gameManager.isMenuOpen = false;
    }

    public void GameStart() {

        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().LoadNextLevel();
    }
}
