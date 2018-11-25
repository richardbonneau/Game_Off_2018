using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;


public class GameManager : MonoBehaviour {
    GameObject hero;
    Scene scene;

    public int lives = 5;
    Text amountLivesText;
    void Awake() {
        amountLivesText = GameObject.FindWithTag("UI_Lives").GetComponent<Text>();
    }


    void Update() {
        amountLivesText.text = lives.ToString();
    }
    public void LoadNextLevel() {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "level_1") {
            SceneManager.LoadScene("level_2");
            hero = GameObject.FindWithTag("Player");
            hero.transform.position = new Vector3(21, 0, 13);
        } else if (scene.name == "level_2") {
            SceneManager.LoadScene("level_3");
            hero = GameObject.FindWithTag("Player");
            hero.transform.position = new Vector3(21, 0, 13);
        }
    }
}
