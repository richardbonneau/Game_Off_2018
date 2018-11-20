using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class GameManager : MonoBehaviour {

    public GameObject hero;
    Scene scene;

    void Start() {
        print("getting scene");
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

    // public List<GameObject> blocksToDestroy = new List<GameObject>();
    // public GameObject minimap;
    // bool minimapOn = false;

    // // Use this for initialization
    // void Start() {

    // }

    // // Update is called once per frame
    // void Update() {
    //     if (Input.GetKeyDown(KeyCode.M)) {
    //         if (minimapOn) {
    //             minimapOn = false;
    //             minimap.SetActive(false);
    //         } else {
    //             minimapOn = true;
    //             minimap.SetActive(true);
    //         }

    //     }
    // }
    // public void DestroyCubes() {

    //     blocksToDestroy = blocksToDestroy.Distinct().ToList();
    //     foreach (var j in blocksToDestroy) {
    //         j.transform.GetChild(0).gameObject.SetActive(false);
    //     }
    //     // blocksToDestroy.Clear();

    // }

}
