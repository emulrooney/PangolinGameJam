using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	public Text scoreDisplay; //Set in inspector
	public float multiplierLingerTime = 3.5f;

	private int score = 0;
	private float multiplier = 1;

	private void Awake()
	{
		UpdateScoreDisplay();
	}

	public void ResetScore()
	{
		CancelInvoke();
		score = 0;
		multiplier = 1;
		UpdateScoreDisplay();
	}

	public void AddScore(int toAdd)
	{
		score += (int) (toAdd * multiplier);
		ModMultiplier(1);
	}

	private void TickMultiplierTimer() {
		ModMultiplier(-1);
	}

	private void ModMultiplier(int amount) {
		multiplier += amount;
		UpdateScoreDisplay();
		CancelInvoke();

		if (multiplier >= 2) {
			float invokeTime = multiplierLingerTime - ((float)multiplier / 4);
			InvokeRepeating("TickMultiplierTimer", invokeTime, invokeTime);
		}

		if (multiplier < 1) {
			multiplier = 1;
		}
	}

	private void UpdateScoreDisplay()
	{
		scoreDisplay.text = "SCORE: " + score + "\nx" + multiplier;
	}

}