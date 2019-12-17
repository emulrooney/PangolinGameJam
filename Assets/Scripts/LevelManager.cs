using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	/* LEVEL MANAGER
	 *	Handles current level, including map data, ant placement, ant tracking.
	 */

	public static LevelManager _levelManager; //Set in inspector

	public int currentLevel = 0;

	public TimerManager _timer; //Set in inspector
	public ScoreManager _score; //Set in inspector
	public SpriteRenderer _cameraTint; //Set in inspector

	public Level currentLevelData;
	public GameObject antBasin; //Section where tongue won't stop moving
	public GameObject antPrefab;

	private Level[] levels;
	public GameObject[] levelObjects; //Set in inspector
	private int maxLevel; //Equal to number of levels

	public int antsLeft;

	List<GameObject> activeAnts = new List<GameObject>();

	public void Awake()
	{

		_levelManager = this;

		maxLevel = levelObjects.Length - 1;

		if (antBasin == null)
		{
			antBasin = GameObject.FindGameObjectWithTag("Ant Basin");
		}

		levels = new Level[5]
		{
			new Level(0, 0, 0, Color.white),
				new Level(4, 1, 60, new Color(1f, 1f, 1f, 1f)),
				new Level(6, 1.05f, 60, new Color(1f, .96f, .74f, .95f)),
				new Level(8, 1.1f, 60, new Color(1f, .4f, .4f, .5f)),
				new Level(11, 1.20f, 70, new Color(.5f, .2f, .5f, .6f))
		};

		LoadLevel();

	}

	public void LoadLevel()
	{

		currentLevelData = levels[currentLevel];
		levelObjects[currentLevel].SetActive(true);

		for (int i = 0; i < currentLevelData.GetQuantity(); i++)
		{
			activeAnts.Add(NewAnt(currentLevelData.GetSpeed()));
		}

		antsLeft = AntPatrolBehaviour.antCounter;

		_timer.SetTimer(currentLevelData.GetTime());

		_cameraTint.color = currentLevelData.GetTint();

	}

	public static void AntKilled()
	{
		_levelManager.antsLeft--;

		if (_levelManager.antsLeft <= 0)
		{
			_levelManager.LevelDone();
		}
	}

	public void LevelDone()
	{
		if (currentLevel >= maxLevel)
		{
			_timer.GameWon();
		}
		else
		{
			levelObjects[currentLevel].SetActive(false);
			currentLevel++;
			LoadLevel();
		}
	}

	private GameObject NewAnt(float speed = 1)
	{
		float basinWidth = antBasin.transform.localScale.x;

		Vector3 antPos = new Vector3(Random.Range(-basinWidth, basinWidth), antBasin.transform.position.y);
		GameObject newAnt = Instantiate(antPrefab, antPos, Quaternion.identity);

		newAnt.GetComponent<AntPatrolBehaviour>().ModifySpeed(speed);

		return newAnt;
	}

	public void Update()
	{
		if (Input.GetKeyDown("l"))
		{
			LevelDone();
		}
	}

}