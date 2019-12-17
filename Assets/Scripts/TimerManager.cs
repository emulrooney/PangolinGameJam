using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    /* TIMER MANAGER
    Handles game time and text output relating to time. 
    */

    public Text timeText, gameOverText; //Set in inspector
    public AudioManager _audioManager; //Set in inspector

    private int timeLeft = 100;

    void Awake()
    {
        InvokeRepeating("TickTimer", 0.0f, 1.0f);
    }

    //Setter for timer.
    public void SetTimer(int time)
    {
        timeLeft = time;
    }

    //Invoked by Awake(), handles clock ticking, text update and calls gameover when complete.
    void TickTimer()
    {
        if (timeLeft <= 0)
            GameOver();
        else if (timeLeft > 0)
        {
            timeLeft--;
            timeText.text = "Timer: " + timeLeft;
        }
    }

    //Sets text to game won, pauses game and plays appropriate music.
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        Time.timeScale = 0;
        _audioManager.GameOverMusic();
    }

    //Sets text to game won, pauses game and plays inappropriate music.
    public void GameWon()
    {
        gameOverText.text = "WINNER WINNER\nPANGOLIN DINNER";
        Time.timeScale = 0;
        _audioManager.GameOverMusic();
    }

}