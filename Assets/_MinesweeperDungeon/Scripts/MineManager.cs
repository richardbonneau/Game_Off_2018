using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MineManager : MonoBehaviour {
    public GameObject gameManagerPrefab;
    public GameObject playerHudPrefab;

    public List<GameObject> blocksToDestroy = new List<GameObject>();

    public int quantityMinesInLevel = 0;
    public int quantityMinesFlagged = 0;
    public int quantityMinesFalselyFlagged = 0;
    public int quantityMinesBlown = 0;
    Text remainingMines;


    public GameObject minimap;
    bool minimapOn = false;

    void Awake() {
        quantityMinesInLevel = GameObject.FindGameObjectsWithTag("Mine").Length;
        remainingMines = GameObject.FindWithTag("UI_Mines").GetComponent<Text>();
        if (GameObject.FindWithTag("GameManager") == null) GameObject.Instantiate(gameManagerPrefab);
        if (GameObject.FindWithTag("PlayerHud") == null) GameObject.Instantiate(playerHudPrefab);
    }
    void Start() {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().AssignNeonColors();
    }

    void Update() {
        //  UI
        remainingMines.text = (quantityMinesInLevel - quantityMinesBlown - quantityMinesFlagged - quantityMinesFalselyFlagged).ToString();


        if (blocksToDestroy.Count > 0) DestroyCubes();


        if (Input.GetKeyDown(KeyCode.M)) {
            if (minimapOn) {
                minimapOn = false;
                minimap.SetActive(false);
            } else {
                minimapOn = true;
                minimap.SetActive(true);
            }
        }
    }

    public void DestroyCubes() {
        blocksToDestroy = blocksToDestroy.Distinct().ToList();
        foreach (var block in blocksToDestroy) {
            if (block.transform.GetChild(0).GetComponent<vp_DamageHandler>().isFlagged == true) { quantityMinesFalselyFlagged -= 1; }
            block.transform.GetChild(0).gameObject.SetActive(false);
        }
        blocksToDestroy.Clear();
    }

}
