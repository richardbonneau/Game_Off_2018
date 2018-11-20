using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MineManager : MonoBehaviour {

    public List<GameObject> blocksToDestroy = new List<GameObject>();
    public GameObject minimap;
    bool minimapOn = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
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
        foreach (var j in blocksToDestroy) {
            j.transform.GetChild(0).gameObject.SetActive(false);
        }
        // blocksToDestroy.Clear();

    }

}
