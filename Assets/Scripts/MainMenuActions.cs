using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
	/* MAIN MENU ACTIONS
	Contains methods for UI on splash screen.
    */
	
	public void StartGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Assets/Scenes/Gameplay.unity");

	}

	public void QuitGame()
    {
        Application.Quit();
    }
}