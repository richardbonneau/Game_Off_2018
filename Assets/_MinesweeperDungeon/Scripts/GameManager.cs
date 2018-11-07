using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour {

    public List<GameObject> blocksToDestroy = new List<GameObject>();
    public bool boolSwitch = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void DestroyCubes() {

        blocksToDestroy = blocksToDestroy.Distinct().ToList();
        foreach (var i in blocksToDestroy) {
            i.transform.GetChild(0).gameObject.SetActive(false);
            i.transform.GetChild(1).gameObject.GetComponent<ParentOfMineDetectors>().TriggerCheckAllCubes();
        }
    }

}
