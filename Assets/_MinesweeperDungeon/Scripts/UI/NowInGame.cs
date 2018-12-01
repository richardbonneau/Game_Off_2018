using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowInGame : MonoBehaviour {
    GameManager gameManager;

    void Update() {
        if (gameManager == null) gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager.isMainMenu == true) gameManager.isMainMenu = false;

    }
}
