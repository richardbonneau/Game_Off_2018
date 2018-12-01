using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Resume : MonoBehaviour {

    public void ResumeTheGame() {
        print(GameObject.FindWithTag("GameManager"));
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().isMenuOpen = false;
    }
}
