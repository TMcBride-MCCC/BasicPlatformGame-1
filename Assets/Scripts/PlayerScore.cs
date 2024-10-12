using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    //Attach to Game Manager
    //Drag connection for Guiscore

    //When we kill an enemy we will call this script to increment/set the score.
    private int playerScore;
    public TMP_Text guiScore;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
    }

    public int getScore()
    {
        return playerScore;
    }

    public void setPlayerScore(int val)
    {
        playerScore += val;
        setGUIPlayerScore();
    }

    public void setGUIPlayerScore()
    {
        guiScore.text = "Score: ";
        guiScore.text += playerScore.ToString();
    }
}
