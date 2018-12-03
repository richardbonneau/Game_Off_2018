using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class MineManager : MonoBehaviour {
    public GameObject gameManagerPrefab;
    public GameObject playerHudPrefab;


    public List<GameObject> blocksToDestroy = new List<GameObject>();
    List<GameObject> blocksDestroyed = new List<GameObject>();

    public int quantityBlocksInLevel = 0;
    public int quantityBlocksDestroyed = 0;
    public int quantityMinesInLevel = 0;
    public int quantityMinesFlagged = 0;
    public int quantityMinesFalselyFlagged;
    public int quantityMinesBlown = 0;

    int totalRemainingMines;

    Text remainingMines;
    Text remainingBlocks;
    Text currentLevel;
    GameObject tutorialUI;


    public GameObject minimap;
    bool minimapOn = false;

    void Awake() {

    }
    void Start() {
        Time.timeScale = 1;
        try {
            if (GameObject.FindWithTag("GameManager") == null) {
                GameObject.Instantiate(gameManagerPrefab);
            }
        } catch (NullReferenceException ex) {
            GameObject.Instantiate(gameManagerPrefab);
        }
        try {
            if (GameObject.FindWithTag("PlayerHud") == null) {
                GameObject.Instantiate(playerHudPrefab);
            }
        } catch (NullReferenceException ex) {
            GameObject.Instantiate(playerHudPrefab);
        }

        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().AssignNeonColors();

        //  ui
        tutorialUI = GameObject.FindWithTag("UI_Tutorial").transform.GetChild(0).gameObject;
        quantityMinesInLevel = GameObject.FindGameObjectsWithTag("Mine").Length;
        quantityBlocksInLevel = GameObject.FindGameObjectsWithTag("Block").Length;

        //remainingBlocks = GameObject.FindWithTag("UI_Blocks").GetComponent<Text>();
        remainingMines = GameObject.FindWithTag("UI_Mines").GetComponent<Text>();
        currentLevel = GameObject.FindWithTag("UI_CurrentLevel").GetComponent<Text>();
        currentLevel.text = SceneManager.GetActiveScene().name.ToUpper();

        if (SceneManager.GetActiveScene().name == "level_1") tutorialUI.SetActive(true);
    }

    void Update() {
        //  UI
        if (Input.GetKeyDown(KeyCode.H)) {
            if (tutorialUI.activeSelf == true) tutorialUI.SetActive(true);
            else if (tutorialUI.activeSelf == false) tutorialUI.SetActive(false);
        }
        totalRemainingMines = (quantityMinesInLevel - quantityMinesBlown - quantityMinesFlagged - quantityMinesFalselyFlagged);
        remainingMines.text = totalRemainingMines.ToString();
        //remainingBlocks.text = (quantityBlocksInLevel - quantityBlocksDestroyed + totalRemainingMines).ToString();
        if (blocksToDestroy.Count > 0) DestroyCubes();

        //  MINIMAP
        // if (Input.GetKeyDown(KeyCode.M)) {
        //     if (minimapOn) {
        //         minimapOn = false;
        //         minimap.SetActive(false);
        //     } else {
        //         minimapOn = true;
        //         minimap.SetActive(true);
        //     }
        // }
    }

    public void DestroyCubes() {
        blocksToDestroy = blocksToDestroy.Distinct().ToList();

        quantityBlocksDestroyed -= 1;
        foreach (var block in blocksToDestroy) {

            quantityBlocksDestroyed += 1;
            if (block.transform.GetChild(0).GetComponent<vp_DamageHandler>().isFlagged == true) { quantityMinesFalselyFlagged -= 1; }
            block.transform.GetChild(0).gameObject.SetActive(false);
            block.transform.GetChild(3).gameObject.SetActive(false);


        }
        blocksToDestroy.Clear();
    }

}
