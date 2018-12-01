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

    GameObject loadingScreenObj;
    Slider slider;


    void Awake() {



    }
    void Start() {
        //loadingScreenObj = GameObject.FindWithTag("UI_LoadingScreen");
        amountLivesText = GameObject.FindWithTag("UI_Lives").GetComponent<Text>();
    }

    void Update() {
        amountLivesText.text = lives.ToString();
    }

    IEnumerator MenuToFirstLevel(string lvl, Vector3 heroPos) {
        loadingScreenObj = GameObject.FindWithTag("UI_LoadingScreen");
        slider = loadingScreenObj.transform.GetChild(1).GetComponent<Slider>();

        loadingScreenObj.transform.GetChild(0).gameObject.SetActive(true);
        loadingScreenObj.transform.GetChild(1).gameObject.SetActive(true);

        loadingScreenObj.transform.parent.transform.GetChild(0).gameObject.SetActive(false);
        loadingScreenObj.transform.parent.transform.GetChild(1).gameObject.SetActive(false);
        loadingScreenObj.transform.parent.transform.GetChild(2).gameObject.SetActive(false);

        asyncLoad = SceneManager.LoadSceneAsync("Level_" + lvl, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone) {

            slider.value = (asyncLoad.progress);
            if (asyncLoad.progress == 0.9f) {
                slider.value = 1f;
                asyncLoad.allowSceneActivation = true;
                hero = GameObject.FindWithTag("Player").gameObject;
                hero.transform.position = heroPos;
                loadingScreenObj.SetActive(false);
            }
            yield return null;
        }
    }

    IEnumerator GoToNextScene(string lvl, Vector3 heroPos) {
        loadingScreenObj = GameObject.FindWithTag("UI_LoadingScreen");
        loadingScreenObj.SetActive(true);
        asyncLoad = SceneManager.LoadSceneAsync("Level_" + lvl, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone) {

            slider.value = (asyncLoad.progress);
            if (asyncLoad.progress == 0.9f) {
                slider.value = 1f;
                asyncLoad.allowSceneActivation = true;
                hero = GameObject.FindWithTag("Player").gameObject;
                hero.transform.position = heroPos;
                loadingScreenObj.SetActive(false);
            }
            yield return null;
        }
    }

    public void LoadNextLevel() {
        print("in load next level");
        scene = SceneManager.GetActiveScene();
        if (scene.name == "mainmenu") StartCoroutine(MenuToFirstLevel("1", new Vector3(21, 0, 13)));
        else if (scene.name == "level_1") StartCoroutine(GoToNextScene("2", new Vector3(21, 0, 13)));
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

        string currentLevel = scene.name.Substring(scene.name.Length - 1);
        int currentLevelInt = int.Parse(currentLevel);

        foreach (var block in prefabBlocks) {
            block.transform.GetChild(1).GetComponent<Renderer>().material = neonColor[currentLevelInt - 1];
        }
        foreach (var mine in prefabMineBlocks) {
            mine.transform.GetChild(1).GetComponent<Renderer>().material = neonColor[currentLevelInt - 1];
        }
    }
}
