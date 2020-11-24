using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // when game is over, allow player to start again by pressing space
        if (Input.GetKeyDown("space")) {
            SceneManager.LoadScene("Intro");
        }
    }
}
