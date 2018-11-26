using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramCube : MonoBehaviour {

    public int rotSpeed = 100;

    void Update() {
        transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
    }
}
