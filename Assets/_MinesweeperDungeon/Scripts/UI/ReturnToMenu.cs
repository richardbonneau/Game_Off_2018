using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class ReturnToMenu : MonoBehaviour {

    public void ReturnBackToMenu() {
        print(GameObject.FindWithTag("GameManager"));
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().isMenuOpen = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("mainmenu", LoadSceneMode.Single);
    }
}
