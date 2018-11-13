using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramCube : MonoBehaviour {

    public int rotSpeed = 100;

    // Use this for initialization


    // Update is called once per frame
    void Update() {
        transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
    }
}
