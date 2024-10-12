using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Drag and drop connection for Hierarchy
    public GameObject pauseMenu;
    public TMP_Text finalScore;
    private PlayerScore playerScore;

    private void Update()
    {
        pauseButtonPress();
    }
    public void pauseButtonPress()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            showPauseMenu();
            pauseGame();
        }
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        hidePauseMenu();
    }

    public void showPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void hidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        showPauseMenu();
        showScore();
    }

    public void showScore()
    {
        if (playerScore.getScore() > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", playerScore.getScore());
            Debug.Log("New highscore: " + playerScore.getScore().ToString());
        }
        finalScore.text = "Final Score: " + playerScore.getScore().ToString();
    }
}
