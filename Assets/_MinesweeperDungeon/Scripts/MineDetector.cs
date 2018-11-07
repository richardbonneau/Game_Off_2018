﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDetector : MonoBehaviour {
    public bool mineCheckDone = false;
    public bool isCollidingWithMine = false;

    Collider collidedBlock;
    ParentOfMineDetectors thisParentMineDetectorsScript;
    ParentOfMineDetectors colMineDetectorParentScript;
    GameObject colParentMineDetectorObject;

    GameManager gameManager;
    void Start() {
        thisParentMineDetectorsScript = this.transform.parent.gameObject.GetComponent<ParentOfMineDetectors>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider col) {

        if (col.gameObject.tag == "Block") {
            collidedBlock = col;
            thisParentMineDetectorsScript.mineChecksDone += 1;
            mineCheckDone = true;
        } else if (col.gameObject.tag == "Mine") {
            thisParentMineDetectorsScript.numberOfMines += 1;
            thisParentMineDetectorsScript.mineChecksDone += 1;
            mineCheckDone = true;
        }
    }

    public void CheckCube() {
        if (collidedBlock != null) {
            print("interacting with a block");
            colMineDetectorParentScript = collidedBlock.transform.parent.GetChild(1).gameObject.GetComponent<ParentOfMineDetectors>();
            if (colMineDetectorParentScript.numberOfMines == 0) {
                print("sending a block to gamemanager " + collidedBlock.gameObject);

                gameManager.blocksToDestroy.Add(collidedBlock.transform.parent.gameObject);
                gameManager.DestroyCubes();


                //CULPRIT!
                //colMineDetectorParentScript.TriggerCheckAllCubes();
            }

            // colMineDetectorParentScript = collidedBlock.transform.parent.GetChild(1).gameObject.GetComponent<ParentOfMineDetectors>();
            // if (colMineDetectorParentScript.numberOfMines == 0) {
            //     print("destroying a block");
            //     collidedBlock.gameObject.SetActive(false);

            //     colMineDetectorParentScript.TriggerCheckAllCubes();
            // }
        }
    }
}
