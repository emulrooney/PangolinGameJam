using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntPatrolBehaviour : MonoBehaviour
{

	public float randomValue = 0.08f;

	public float moveSpeed = 0.35f;
	public int facingDirection = 1; //Positive is forward, negative is backwards

	public SpriteRenderer _sprite;

	int layerMask = 512;

	public static int antCounter = 0;

	void Awake()
	{
		antCounter++;
	}

	void FixedUpdate()
	{
		if (Physics2D.Raycast(transform.position,
				new Vector2(facingDirection, 0),
				1, layerMask))
		{

			facingDirection = facingDirection * -1;
			_sprite.flipX = !_sprite.flipX;
		}

		transform.position += new Vector3(facingDirection * moveSpeed, 0, 0);

	}

	public void ModifySpeed(float speed, bool randomizer = true)
	{
		moveSpeed *= speed;

		if (randomizer)
		{
			moveSpeed += Random.Range(-randomValue, randomValue);
		}
	}

}