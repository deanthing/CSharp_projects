using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

    void Start()
    {
        // when game is over, delete countdown
        Destroy(GameObject.Find("Canvas/Countdown"));
    }

    void Update()
    {
        // if space is pressed after a win, restart game
        if (Input.GetKeyDown("space")) {
            SceneManager.LoadScene("Intro");
        }
    }
}
