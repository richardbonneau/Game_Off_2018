using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour {

    public List<GameObject> blocksToDestroy = new List<GameObject>();
    public List<GameObject> blocksToIgnore = new List<GameObject>();

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void DestroyCubes() {
        foreach (var i in blocksToIgnore) {
            blocksToDestroy.Remove(i);
        }
        blocksToDestroy = blocksToDestroy.Distinct().ToList();
        foreach (var j in blocksToDestroy) {
            j.transform.GetChild(0).gameObject.SetActive(false);
            //j.transform.GetChild(1).gameObject.GetComponent<ParentOfMineDetectors>().TriggerCheckAllCubes();
        }
        // blocksToDestroy.Clear();
        // blocksToIgnore.Clear();
    }

}
