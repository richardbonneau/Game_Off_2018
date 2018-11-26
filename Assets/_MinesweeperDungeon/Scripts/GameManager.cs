using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;


public class GameManager : MonoBehaviour {

    //  Assign a different neon color to the blocks depending on the level  
    public List<Material> neonColor;
    public GameObject[] prefabBlocks;
    public GameObject[] prefabMineBlocks;

    GameObject hero;
    Scene scene;

    public int lives = 5;
    Text amountLivesText;

    AsyncOperation asyncLoad;

    public GameObject loadingScreenObj;
    public Slider slider;


    void Awake() {
        amountLivesText = GameObject.FindWithTag("UI_Lives").GetComponent<Text>();
    }

    void Update() {
        amountLivesText.text = lives.ToString();
    }

    IEnumerator GoToNextScene(string lvl, Vector3 heroPos) {
        loadingScreenObj.SetActive(true);
        asyncLoad = SceneManager.LoadSceneAsync("Level_" + lvl, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone) {

            slider.value = (asyncLoad.progress);
            if (asyncLoad.progress == 0.9f) {
                slider.value = 1f;
                asyncLoad.allowSceneActivation = true;
                hero = GameObject.FindWithTag("Player");
                hero.transform.position = heroPos;
                loadingScreenObj.SetActive(false);
            }
            yield return null;
        }
    }

    public void LoadNextLevel() {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "level_1") StartCoroutine(GoToNextScene("2", new Vector3(21, 0, 13)));
        else if (scene.name == "level_2") StartCoroutine(GoToNextScene("3", new Vector3(21, 0, 13)));
        else if (scene.name == "level_3") StartCoroutine(GoToNextScene("4", new Vector3(21, 0, 13)));
        // else if (SceneManager.GetActiveScene().name == "Level_4") StartCoroutine(GoToNextScene());
        // else if (SceneManager.GetActiveScene().name == "Level_5") StartCoroutine(GoToNextScene());
        // else if (SceneManager.GetActiveScene().name == "Level_6") StartCoroutine(GoToNextScene());
        // else if (SceneManager.GetActiveScene().name == "Level_7") StartCoroutine(GoToNextScene());
        // else if (SceneManager.GetActiveScene().name == "Level_8") StartCoroutine(GoToNextScene());
        // else if (SceneManager.GetActiveScene().name == "Level_9") StartCoroutine(GoToNextScene());
        // else if (SceneManager.GetActiveScene().name == "Level_10") StartCoroutine(GoToNextScene());
    }

    public void AssignNeonColors() {
        //  Get all Blocks and Mines from the scene in Lists
        prefabBlocks = GameObject.FindGameObjectsWithTag("Block");
        prefabMineBlocks = GameObject.FindGameObjectsWithTag("Mine");

        //  Get the current scene to know which color to apply
        scene = SceneManager.GetActiveScene();
        print(scene.name);

        string currentLevel = scene.name.Substring(scene.name.Length - 1);
        int currentLevelInt = int.Parse(currentLevel);
        print("currentlevel " + currentLevelInt);

        foreach (var block in prefabBlocks) {
            print(block);
            block.transform.GetChild(1).GetComponent<Renderer>().material = neonColor[currentLevelInt - 1];
        }
        foreach (var mine in prefabMineBlocks) {
            mine.transform.GetChild(1).GetComponent<Renderer>().material = neonColor[currentLevelInt - 1];
        }
    }
}
