using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class GameManager : MonoBehaviour {
    GameObject hero;
    Scene scene;

    void Start() {
        scene = SceneManager.GetActiveScene();
    }

    public void LoadNextLevel() {
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
