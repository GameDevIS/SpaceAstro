// Website : GameDevIS (Youtube\Facebook)
// Written by GameDevIS <GameDevISR@gmail.com>, 20/02/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour {

	public GameObject MeteorExplostionPrefab;		// Meteor explostion animation

	public float meteorSpeed;						// Meteor Speed

	float maxY;										// Bottom most Y axis screen position , if we pass this position destroy game object

	// Use this for initialization
	void Start () {

		// Viewport Bottom Left Point
		maxY = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0)).y;
		
	}
	
	// Update is called once per frame
	void Update () {

		// if we passed maxY (=outside screen) position destroy gameobject
		if (transform.position.y < maxY) {
			Destroy(this.gameObject);
		}

		// Update our Meteor Position
		transform.Translate (Vector3.down * meteorSpeed * Time.deltaTime);

	}

	// Check for collisions
	void OnTriggerEnter2D(Collider2D other)
	{
		// if other collider is of type laser\player instantiate a meteor Explostion and destroy this gameobject
		if (other.CompareTag("Laser") || other.CompareTag("Player") ) {

			Instantiate (MeteorExplostionPrefab, transform.position, Quaternion.identity);

			Destroy (this.gameObject);
		}
	}

}
