using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelloader : MonoBehaviour
{
    public int iLevelToLoad; // Loads level by order 
   
    public string sLevelToLoad; // loads level by scene name

    public bool useIntegerToLevel = false; // Shows if theres no next number level in the order

    public float transitionTime = 1f; // Shows how long it takes to load between scenes

    public Animator transition; // Asigns the Animator and controls the Animation

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject; // Shows if something collides with the GameObject

        if(collisionGameObject.name == "Hero")
        {
            LoadScene(); // Runs void loadScene
        }
        
        if (collisionGameObject.name == "Hero 2")
        {
            LoadScene(); // loadScene
        }

        void LoadScene()
        {
            if(useIntegerToLevel)
            {
                SceneManager.LoadScene(iLevelToLoad); // Loads the next level in the order
            }
            else
            {
                transition.SetTrigger("Start"); // Starts the Next Level Animation
                
                SceneManager.LoadScene(sLevelToLoad); // Loads the level name
            }
        }
    }
}
