using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueBehaviour : MonoBehaviour {

	public ScoreManager _score;

	public GameObject originArea;
	public GameObject tonguePiece;
	//public BoxCollider2D coll;

	bool retracting = false;
	bool moving = false;
	bool hitBasin = false;

	public float moveSpeed = 0.02f;
	public float tonguePieceTimer = 0.5f;
	string moveDir = "Down";

	List<GameObject> tonguePieces = new List<GameObject>();

	// Update is called once per frame
	void Update () {

		if (!hitBasin) {
			if (Input.GetButtonDown("Left")) {
				moveDir = "Left";
			} else if (Input.GetButtonDown("Right")) {
				moveDir = "Right";
			} else if (Input.GetButtonDown("Down")) {

				if (!moving && !retracting) {
					moving = true;
					InvokeRepeating("PlacePiece", tonguePieceTimer, tonguePieceTimer);
				}

				moveDir = "Down";
			}

			if (moving) {
				if (Input.GetButtonDown("Retract")) {
					moveDir = "Down";
					Retract();
				}
			}

		}

	}


	void FixedUpdate() {
		if (moving && !retracting) {
			if (moveDir == "Left") {
				transform.position += new Vector3(-moveSpeed, 0, 0);
			} else if (moveDir == "Right") {
				transform.position += new Vector3(moveSpeed, 0, 0);
			} else {
				transform.position += new Vector3(0, -moveSpeed, 0);
			}
		}
	}


	void OnTriggerEnter2D(Collider2D coll) {

		if (coll.GetComponent<EdibleBehaviour>() != null) {
			_score.AddScore(coll.GetComponent<EdibleBehaviour>().Eat());
			if (coll.GetComponent<AntPatrolBehaviour>() != null) {
				AntPatrolBehaviour.antCounter--;
				LevelManager.AntKilled();
				Debug.Log(AntPatrolBehaviour.antCounter + " ants left");
			}
		} else if (coll.tag == "Ant Basin") {
			hitBasin = true;
			moveDir = "Down";
		} else {
			Retract();
		}
	}


	private void Retract() {
		hitBasin = false;
		moving = false;
		CancelInvoke();
		transform.position = originArea.transform.position;

		for (int i = 0; i < tonguePieces.Count; i++) {
			Destroy(tonguePieces[i]);
		}

		tonguePieces.Clear();
	}


	private void PlacePiece() {
		GameObject newPiece = Instantiate(tonguePiece, transform.position, Quaternion.identity);
		tonguePieces.Add(newPiece);
	}

}
