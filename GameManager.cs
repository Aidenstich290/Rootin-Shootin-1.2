using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false; // Shows if the game has ended or not
   
    public Score score; // Shows the score script

    public float transitionTime = 1f; // The time it takes to transition

    public Animator transition; // Asigns the Animator to control Animations

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true; // Shows the game has ended
            
            Restart(); // Runs void Restart line of code
        }
    }
    
    void Restart()
    {
        Score.scoreValue -= 250; // Takes a score away for dying in the game

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Loads the Same scene up so you restart the level
    }
}
