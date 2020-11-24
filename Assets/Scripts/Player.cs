using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

{
    // reference to players collider 
    PlayerCollision playerCollision;
    private Rigidbody2D rb2d;
    // bool to see if player is on line 
    private bool onLine;
    // start pos of biker
    Vector3 originalPos;
    Quaternion originalRotation;
    float speed = 0.35f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        originalPos = gameObject.transform.position;
        onLine = false;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(onLine)
            movement();
        if (Input.GetKeyDown("space"))
            restartLevel();

        // assign reference to bodyCollider script called PlayerCollision
        playerCollision = GameObject.Find("bodyCollider").GetComponent<PlayerCollision>();
        // if true, restart level and set var to false
        if(playerCollision.lineCollision == true) {
            restartLevel();
            playerCollision.lineCollision = false;
        }
    }
    // reset level
    void restartLevel() {
        // set transform to original pos
        gameObject.transform.position = originalPos;

        // reset rigid body
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0f;

        // reset rotation 
        Vector3 rotationReset = new Vector3(0, 0, 0);
        transform.rotation = originalRotation;
    }

    // movement handler    
    void movement() {
        // gas and lean vars init
        float lean = Input.GetAxis("Horizontal");
        float gasBreak = Input.GetAxis("Vertical");

        // gas input
        if(gasBreak!=0) {
            // gas and break
            Vector2 movement = new Vector2(gasBreak, 0) * speed;
            rb2d.MovePosition(rb2d.position + movement);
        }
        
        // bike rotation for leaning
        if(lean!=0) {
            Vector3 rotation = new Vector3(0, 0, -lean * 8);
            transform.Rotate(rotation, Space.Self);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {

        // while on line
        if(collision.gameObject.name == "Line") {
            onLine = true;
        }

        // when player hits end level flag, load next level
        if(collision.gameObject.name == "FinishFlag1") {
            SceneManager.LoadScene("Level2");
        }

        if(collision.gameObject.name == "FinishFlag2") {
            SceneManager.LoadScene("Level3");
        }

        if(collision.gameObject.name == "FinishFlag3") {
            SceneManager.LoadScene("Level4");
        }

        if(collision.gameObject.name == "FinishFlag4") {
            SceneManager.LoadScene("win");
        }
    }


    // set onLine to false when players disconnects from line 
    void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.name == "Line") {
            onLine = false;
        }
    }
}