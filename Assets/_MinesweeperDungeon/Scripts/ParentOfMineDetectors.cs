using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentOfMineDetectors : MonoBehaviour {
    public int mineChecksDone = 0;
    public int numberOfMines = 0;
    public GameObject[] mineDetectors;
    public Texture[] numberedTextures;
    MineManager mineManager;
    bool hasbeenTriggered = false;


    bool cubeCheck = false;
    void Start() {
        mineManager = GameObject.FindWithTag("MineManager").GetComponent<MineManager>();
    }
    void Update() {
        if (cubeCheck == false && numberOfMines != 0) {
            cubeCheck = true;
            this.transform.parent.GetChild(2).GetChild(numberOfMines - 1).gameObject.SetActive(true);
        }

    }
    public void TriggerCheckAllCubes() {
        if (!hasbeenTriggered) {
            hasbeenTriggered = true;
            GameObject parentCube = this.transform.parent.GetChild(0).gameObject;
            if (numberOfMines == 0) {
                this.transform.parent.GetChild(2).gameObject.SetActive(false);
                this.transform.parent.GetChild(3).gameObject.SetActive(false);
                parentCube.SetActive(false);

                foreach (var i in mineDetectors) {
                    i.GetComponent<MineDetector>().DeactivateSurroundingCubes();
                }
            } else {
                parentCube.SetActive(false);
            }
        }
    }
}

