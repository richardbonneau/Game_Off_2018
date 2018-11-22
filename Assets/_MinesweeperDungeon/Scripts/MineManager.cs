using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MineManager : MonoBehaviour {
    public List<GameObject> blocksToDestroy = new List<GameObject>();
    public int quantityMinesInLevel = 0;
    public int quantityMinesFlagged = 0;
    public GameObject minimap;
    bool minimapOn = false;

    void Start() {
        quantityMinesInLevel = GameObject.FindGameObjectsWithTag("Mine").Length;
    }

    void Update() {
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
            block.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
