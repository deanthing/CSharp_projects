using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    void Awake() 
    {
        // dont destroy canvas for timer TMP obj
        DontDestroyOnLoad(transform.gameObject);
    }
}
