using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool lineCollision = false;
    void OnCollisionEnter2D(Collision2D collision) {
        // on collision to line, set to true to alert Player.cs. its public so the player script can access it
        if(collision.gameObject.name == "Line")
            lineCollision = true;
    }


}
