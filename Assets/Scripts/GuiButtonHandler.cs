using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiButtonHandler : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        //Can only do this because the GameManager script is attached to the same object
        //as this script.
        gameManager = GetComponent<GameManager>();
    }
    public void loadGame()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1;
        //Show Highscore
        Debug.Log("Highscore: " + PlayerPrefs.GetInt("Highscore"));
    }

    public void resumeGame()
    {
        gameManager.resumeGame();
    }

    public void exitGame()
    {
        //this only works on a build
        Application.Quit();
    }

    public void displayMenu()
    {

    }
}
