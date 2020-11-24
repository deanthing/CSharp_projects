using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScript : MonoBehaviour
{

    // when game restarts, destroy countndown
    void Awake() {
        Destroy (GameObject.Find("Countdown"));
    }

    void Update()
    {
        // when space is entered, start game at level1
        if (Input.GetKeyDown("space")) {
            SceneManager.LoadScene("Level1");
        }
    }
}
