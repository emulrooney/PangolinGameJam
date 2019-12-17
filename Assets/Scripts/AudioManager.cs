using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour {
    /* AUDIO MANAGER
    * Handles playing of main theme and end music.
    */

    public AudioSource mainTheme; //Set in inspector
    public AudioSource endMusic; //Set in inspector

    private void Awake()
    {
        StartGameMusic();
    }

	public void StartGameMusic () {
        mainTheme.Play();
	}

	public void GameOverMusic()
    {
        mainTheme.Stop();
        endMusic.Play();
    }
}
