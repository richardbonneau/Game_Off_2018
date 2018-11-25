using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MineManager : MonoBehaviour {
    public List<GameObject> blocksToDestroy = new List<GameObject>();


    public int quantityMinesInLevel = 0;
    public int quantityMinesFlagged = 0;
    public int quantityMinesFalselyFlagged = 0;
    public int quantityMinesBlown = 0;
    Text remainingMines;


    public GameObject minimap;
    bool minimapOn = false;

    void Start() {
        quantityMinesInLevel = GameObject.FindGameObjectsWithTag("Mine").Length;
        remainingMines = GameObject.FindWithTag("UI_Mines").GetComponent<Text>();
    }

    void Update() {
        remainingMines.text = (quantityMinesInLevel - quantityMinesBlown - quantityMinesFlagged - quantityMinesFalselyFlagged).ToString();
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
            print(block.transform);
            print(block.transform.GetChild(0));
            //print(block.transform.GetChild(0).GetComponent<vp_DamageHandler>());
            //print(block.transform.GetChild(0).GetComponent<vp_DamageHandler>().isFlagged);
            //if (block.GetComponent<vp_DamageHandler>().isFlagged) { quantityMinesFalselyFlagged -= 1; }
            block.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
