using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer MainMixer; // Is where the Music is store and Controlled 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // Quits the Game
        }
    }

   public void QuitGame()
    {
        Application.Quit(); // Quits the Game
    }
    public void PlayerSelection()
    {
        SceneManager.LoadScene("Player Selection"); // Loads Player Selection
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("HTP1"); // Loads the HTP1 
        
        Score.scoreValue = 0; // Sets all Score to 0
    }
    
    public void SetVolume (float volume)
    {
        MainMixer.SetFloat("Volume", volume); // Sets the volume for the music 
    }

    public void Optionsmenu()
    {
        SceneManager.LoadScene("Options menu"); // Loads the Options Menu

    }
   
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu"); // Loads the Main Menu
    }
   
    public void StoryGame()
    {
        SceneManager.LoadScene("HTP3"); // Loads the HTP3 
    }
   
    public void PlayGame2()
    {
        SceneManager.LoadScene("2HTP1"); // Loads the HTP1 

        Score.scoreValue = 0; // Sets all Score to 0
    }
    
    public void StoryGame2()
    {
        SceneManager.LoadScene("2HTP3"); // Loads the 2HTP3 Screen
    }
   
    public void Instructions()
    {
        SceneManager.LoadScene("3HTP1"); // Loads the 3HTP1 Screen
    }
}
