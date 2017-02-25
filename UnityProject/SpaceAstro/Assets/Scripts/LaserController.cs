// Website : GameDevIS (Youtube\Facebook)
// Written by GameDevIS <GameDevISR@gmail.com>, 20/02/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	public float Speed;								// Laser Speed

	float offscreenY;								// Screen Top Y offset

	// Use this for initialization
	void Start () {

		// Get Viewport Top Right Point in the Y axis
		offscreenY = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1)).y;
	}
	
	// Update is called once per frame
	void Update () {

		// Check if our laser moved offscreen in the Y axis then destroy it else keep moving up
		if (transform.position.y > offscreenY) {
			Destroy (this.gameObject);
		} else {
			transform.Translate (Vector3.up * Speed * Time.deltaTime);
		}
	}

	// Check for collisions
	void OnTriggerEnter2D(Collider2D other)
	{

		// if we collide with Meteor destroy this gameobject
		if (other.CompareTag("Meteor")) {
			Destroy (this.gameObject);
		}
	}

}
