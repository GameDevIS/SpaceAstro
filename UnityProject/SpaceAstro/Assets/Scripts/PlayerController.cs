// Website : GameDevIS (Youtube\Facebook)
// Written by GameDevIS <GameDevISR@gmail.com>, 20/02/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int Lives;								// Player lives count
	public float numBlinks;							// Number of blinks to do when respawning
	public float blinkSeconds;						// Time between blinks

	public Transform laserSpwan;					// Laser spawn position
	public GameObject laserPrefab;					// Laser prefab game object


	private float maxWidth;							// Defines the X axis range we can't cross outside our screen	
	private float maxHeight;						// Defines the Y axis range we can't cross outside our screen

	private AudioSource audioSource;				// Reference to Audio Source component so we can play sounds

	// Use this for initialization
	void Start () {

		// Get reference to this game object Audio Source component
		audioSource = GetComponent<AudioSource> ();

		// Find screen upper corner and convert it to world point
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0);
		Vector3 targetWidth = Camera.main.ScreenToWorldPoint (upperCorner);

		// Get player extents in the y+x axis 
		float playerWidth = GetComponent<Renderer> ().bounds.extents.x;
		float playerHeight = GetComponent<Renderer> ().bounds.extents.y;

		// Decrease our player extents from the moveable boundaries so we be seen half way offscreen  
		maxWidth = targetWidth.x - playerWidth;
		maxHeight = targetWidth.y - playerHeight;

	}
	
	// Update is called once per frame
	void Update() {

		// if we pressed left mouse button call fire function
		if (Input.GetMouseButtonDown(0)) {
			Fire ();
		}

		UpdatePosition ();
		
	}

	// Instantiate a laser prefabe and playing laser sound
	void Fire()
	{
		Instantiate (laserPrefab, laserSpwan.position, Quaternion.identity);
		audioSource.PlayOneShot (audioSource.clip);
	}

	// Update player position based on the mouse position
	void UpdatePosition()
	{

		Vector3 rawPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPosition = new Vector3 (rawPosition.x, rawPosition.y, 0.0f);

		float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
		float targetHeight = Mathf.Clamp (targetPosition.y, -maxHeight, maxHeight);

		targetPosition = new Vector3 (targetWidth, targetHeight, targetPosition.z);

		transform.position = targetPosition;

	}

	// Check for collisions
	void OnTriggerEnter2D(Collider2D other)
	{
		// if we collide with Meteor destroy player
		if (other.CompareTag("Meteor")) {
			DestroyPlayer ();
		}
	}

	// Decrease 1 from our player lives and start Respawning 
	void DestroyPlayer()
	{
		Lives--;
		StartCoroutine(RespawnPlayer(numBlinks,blinkSeconds));
	}

	// Blinks our player upon respawning and make him invulnerable while respawning
	IEnumerator RespawnPlayer(float numBlinks,float seconds )
	{
		Renderer renderer = GetComponent<Renderer> ();
		BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D> ();

		// Disable Our Box Collider 2D so we can't be hit while respawning
		boxCollider2D.enabled = false;

		// Make our player blink
		for (int i = 0; i < numBlinks*2; i++) {

			// Toggle renderer
			renderer.enabled = !renderer.enabled;

			// Wait for a x Seconds
			yield return new WaitForSeconds (seconds);

		}

		// Enable our box coliider 2D so we can get hit
		boxCollider2D.enabled = true;

		// Make sure renderer is enabled when we exit
		renderer.enabled = true;

	}

}
