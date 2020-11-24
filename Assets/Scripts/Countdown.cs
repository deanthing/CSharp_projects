using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    // time left in game
    public float timeRemaining = 60;
    // when timer is active boolean
    private bool timerIsActive = true;

    // reference to TMP asset
    TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        // get reference to text
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Awake() 
    {
        // make sure timer text doesnt get deleted between levels
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        // if the timer is running
        if(timerIsActive) {
            // decrease timer by time delta
            timeRemaining -= Time.deltaTime;
            // make tmp equal time
            text.text = timeRemaining.ToString();

            // when timer ends
            if(timeRemaining <= 0 ) {
                // set to 0 so it doesnt go below 0
                timeRemaining = 0f;
                // set tot false and load losing scene
                timerIsActive = false;
                SceneManager.LoadScene("end");
            }
        }


    }
}
