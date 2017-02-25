// Website : GameDevIS (Youtube\Facebook)
// Written by GameDevIS <GameDevISR@gmail.com>, 20/02/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	public GameObject MeteorPrefab;

	public float MinSpeed;						// Min Meteor Speed
	public float MaxSpeed;						// Max Meteor Speed
	public float SpawnRate;						// Meteors Spwan rate
	public float SpawnStart;					// Meteors Spwan Start Time

	Vector2 min;								// Viewport Bottom Left Point
	Vector2 max;								// Viewport Top Right Point

	// Use this for initialization
	void Start () {

		// Viewport bottom Left Point
		min = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0));

		// Viewport Top right point
		max = Camera.main.ViewportToWorldPoint(new Vector3(1,1));

		// repeat SpawnMeteor function every SpawnRate and start at SpawnStart time
		InvokeRepeating ("SpawnMeteor", SpawnStart, SpawnRate);

	}

	void SpawnMeteor()
	{
		
		// Get Meteor Sprite Y+X extents
		float meteorExtentsX = MeteorPrefab.GetComponent<Renderer> ().bounds.extents.x;
		float meteorExtentsY = MeteorPrefab.GetComponent<Renderer> ().bounds.extents.y;

		// Generate random position on the X axis
		float randomX = Random.Range (min.x + meteorExtentsX, max.x - meteorExtentsX);

		// Set Our Random Position + Y offset so the meteor will spawn outside our view
		Vector2 randomPosition = new Vector2 (randomX, max.y + meteorExtentsY);

		// Instantiate our meteor
		GameObject Meteor = Instantiate (MeteorPrefab, randomPosition, Quaternion.identity);

		// Set Meteor's Random Speed
		Meteor.GetComponent<MeteorController> ().meteorSpeed = Random.Range (MinSpeed, MaxSpeed);

	}

}
