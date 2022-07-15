using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Control all the buttons in the menu scene
/// </summary>
public class Menu : MonoBehaviour
{
    // Load the game's Easy scene
    public void Easy()
    {
        SceneManager.LoadScene("Easy");
    }
    // Load the game's Medium scene
    public void Medium()
    {
        SceneManager.LoadScene("Medium");
    }
    // Load the game's Hard scene
    public void Hard()
    {
        SceneManager.LoadScene("Hard");
    }
    // Load the Scoreboard scene
    public void Scoreboard()
    {
        SceneManager.LoadScene("Scoreboard");
    }
    // Load the Instruction scene
    public void Instruction()
    {
        SceneManager.LoadScene("Instruction");
    }
    // Return to the Menu scene
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    // Exit the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
