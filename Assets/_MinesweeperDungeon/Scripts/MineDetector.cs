using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDetector : MonoBehaviour {
    public bool mineCheckDone = false;
    public bool isCollidingWithMine = false;

    public Collider collidedBlock;
    ParentOfMineDetectors thisParentMineDetectorsScript;
    ParentOfMineDetectors colMineDetectorParentScript;
    GameObject colParentMineDetectorObject;

    MineManager mineManager;
    void Start() {
        thisParentMineDetectorsScript = this.transform.parent.gameObject.GetComponent<ParentOfMineDetectors>();
        mineManager = GameObject.FindWithTag("MineManager").GetComponent<MineManager>();
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
    public void DeactivateSurroundingCubes() {

        if (collidedBlock != null) {

            mineManager.blocksToDestroy.Add(collidedBlock.transform.parent.gameObject);
            mineManager.DestroyCubes();
            colMineDetectorParentScript = collidedBlock.transform.parent.GetChild(1).gameObject.GetComponent<ParentOfMineDetectors>();
            colMineDetectorParentScript.TriggerCheckAllCubes();
        }
    }
}
