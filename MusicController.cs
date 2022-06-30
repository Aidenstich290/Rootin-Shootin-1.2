using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController instance; // Asigns the Music 

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); // Destroys if the controller is set to null
        }
        else
        {
            instance = this; // 
            DontDestroyOnLoad(transform.gameObject); // Doesn't destroy it on load into new levels 
        }
    }
}
