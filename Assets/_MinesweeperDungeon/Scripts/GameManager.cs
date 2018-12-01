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
    GameObject gameMenu;
    public bool isMenuOpen = false;
    Slider slider;
    public bool isMainMenu = false;


    void Awake() {



    }
    void Start() {
        //loadingScreenObj = GameObject.FindWithTag("UI_LoadingScreen");

    }

    void Update() {
        if (amountLivesText == null) amountLivesText = GameObject.FindWithTag("UI_Lives").GetComponent<Text>();
        amountLivesText.text = lives.ToString();


        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameMenu = GameObject.FindWithTag("PlayerHud").transform.GetChild(1).gameObject;
            if (gameMenu.activeSelf) {
                isMenuOpen = false;
            } else {
                isMenuOpen = true;
            }
        }

        if (isMainMenu) {
            isMenuOpen = false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            vp_Utility.LockCursor = false;
            lives = 5;
            Time.timeScale = 1;
        } else if (lives <= 0) {
            GameObject.FindWithTag("PlayerHud").transform.GetChild(2).gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (hero == null) hero = GameObject.FindWithTag("Player").gameObject;
            hero.GetComponent<vp_FPInput>().MouseCursorForced = true;
            vp_Utility.LockCursor = false;
            Time.timeScale = 0.0001f;
        } else if (isMenuOpen) {
            if (hero == null) hero = GameObject.FindWithTag("Player").gameObject;
            hero.GetComponent<vp_FPInput>().MouseCursorForced = true;
            vp_Utility.LockCursor = false;
            if (gameMenu == null) gameMenu = GameObject.FindWithTag("PlayerHud").transform.GetChild(1).gameObject;
            gameMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            vp_Utility.LockCursor = false;
            Time.timeScale = 0.00001f;
        } else if (!isMenuOpen && SceneManager.GetActiveScene().name != "mainmenu") {
            if (hero == null) hero = GameObject.FindWithTag("Player").gameObject;
            hero.GetComponent<vp_FPInput>().MouseCursorForced = false;
            if (gameMenu == null) gameMenu = GameObject.FindWithTag("PlayerHud").transform.GetChild(1).gameObject;
            gameMenu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            vp_Utility.LockCursor = true;

            Time.timeScale = 1;
        }
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
        loadingScreenObj = GameObject.FindWithTag("PlayerHud").transform.GetChild(0).gameObject;
        slider = loadingScreenObj.transform.GetChild(1).GetComponent<Slider>();

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
        scene = SceneManager.GetActiveScene();
        if (scene.name == "mainmenu") StartCoroutine(MenuToFirstLevel("1", new Vector3(21, 0, 13)));
        else if (scene.name == "level_1") StartCoroutine(GoToNextScene("2", new Vector3(21, 0, 13)));
        else if (scene.name == "level_2") StartCoroutine(GoToNextScene("3", new Vector3(21, 0, 13)));
        else if (scene.name == "level_3") StartCoroutine(GoToNextScene("4", new Vector3(21, 0, 13)));
        else if (scene.name == "level_4") StartCoroutine(GoToNextScene("5", new Vector3(21, 0, 13)));
        else if (scene.name == "level_5") StartCoroutine(GoToNextScene("6", new Vector3(21, 0, 13)));
        else if (scene.name == "level_6") StartCoroutine(GoToNextScene("7", new Vector3(21, 0, 13)));
        else if (scene.name == "level_7") StartCoroutine(GoToNextScene("8", new Vector3(21, 0, 13)));
        else if (scene.name == "level_8") StartCoroutine(GoToNextScene("9", new Vector3(21, 0, 13)));
        else if (scene.name == "level_9") StartCoroutine(GoToNextScene("10", new Vector3(21, 0, 13)));
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
            block.transform.GetChild(1).GetComponent<Renderer>().material = neonColor[currentLevelInt - 1 + 1];
        }
        foreach (var mine in prefabMineBlocks) {
            mine.transform.GetChild(1).GetComponent<Renderer>().material = neonColor[currentLevelInt - 1 + 1];
        }
    }

    void GameOver() {

    }
}
