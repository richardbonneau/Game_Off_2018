using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour {

    // Use this for initialization
    public void GameStart() {
        print("in game start");
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().LoadNextLevel();
    }
}
