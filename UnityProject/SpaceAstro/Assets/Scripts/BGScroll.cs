// Website : GameDevIS (Youtube\Facebook)
// Written by GameDevIS <GameDevISR@gmail.com>, 20/02/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

	public float scrollSpeed;				// Background Scroll speed
	public float tileSizeY;					// Background tile Height

	private Vector3 startPosition;			// Background start position

	// Use this for initialization
	void Start () {

		// Set startPosition
		startPosition = transform.position;

		// Get background sprite height
		tileSizeY = GetComponent<Renderer> ().bounds.size.y;

	}

	// Update is called once per frame
	void Update () {

		// Calculate the new position
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeY);

		// Set our position to new Position
		transform.position = startPosition + Vector3.down * newPosition;
	}
}
