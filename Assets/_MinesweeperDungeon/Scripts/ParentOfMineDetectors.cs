using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentOfMineDetectors : MonoBehaviour {
    public int mineChecksDone = 0;
    public int numberOfMines = 0;
    public GameObject[] mineDetectors;

    public Texture[] numberedTextures;


    bool cubeCheck = false;
    void Start() {
        foreach (var i in mineDetectors) {
        }
    }
    void Update() {
        if (cubeCheck == false) {
            cubeCheck = true;
            this.transform.parent.GetChild(0).gameObject.GetComponent<Renderer>().material.mainTexture = numberedTextures[numberOfMines];
        }
        // else if (mineChecksDone > 0 && cubeCheck == false) {
        //     cubeCheck = true;
        //     if (numberOfMines == 0) {
        //         this.transform.parent.GetChild(0).gameObject.SetActive(false);
        //         TriggerCheckAllCubes();
        //     }
        // }
    }
    public void TriggerCheckAllCubes() {
        print("in triggercheckAll");

        // mineDetectors[0].GetComponent<MineDetector>().CheckCube();
        // mineDetectors[1].GetComponent<MineDetector>().CheckCube();
        // mineDetectors[2].GetComponent<MineDetector>().CheckCube();
        // mineDetectors[3].GetComponent<MineDetector>().CheckCube();
        // mineDetectors[4].GetComponent<MineDetector>().CheckCube();
        // mineDetectors[6].GetComponent<MineDetector>().CheckCube();
        // mineDetectors[7].GetComponent<MineDetector>().CheckCube();
        foreach (var i in mineDetectors) {
            i.GetComponent<MineDetector>().CheckCube();
        }

    }
}

