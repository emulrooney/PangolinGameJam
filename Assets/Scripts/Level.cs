using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Level
{
	/** LEVEL
	* Simple struct for handling map data. Only ever created by LevelManager.
	*/

	public Level(int q, float s, int t, Color ti)
	{
		this.quantity = q;
		this.speed = s;
		this.time = t;
		this.tint = ti;
	}

	int quantity;
	float speed;
	int time;
	Color tint;

	public int GetQuantity()
	{
		return quantity;
	}

	public float GetSpeed()
	{
		return speed;
	}

	public int GetTime()
	{
		return time;
	}

	public Color GetTint()
	{
		return tint;
	}

}