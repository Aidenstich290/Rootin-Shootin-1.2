using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score; // Asgin Where the score will be Displayed
    
    public Text highScore; // Asgin Where the Highscore will be Displayed
    
    public static int scoreValue = 0; // Shows the score value

        void Start ()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); // Shows and stores the Highest score in the game
    }

    void Update()
    {
        int number = scoreValue; // Shows the number of score
        
        score.text = number.ToString(); // Shows the text as a number

        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number); // Takes the Highscore
            
            highScore.text = number.ToString(); // Puts the Highscore on the text as a number
        }
        
        PlayerPrefs.SetInt("Highscore", number); // Saves the Highscore 
    }
}
