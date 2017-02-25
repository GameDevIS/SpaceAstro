// Website : GameDevIS (Youtube\Facebook)
// Written by GameDevIS <GameDevISR@gmail.com>, 20/02/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorExplostionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (DestroyAnimation ());
	}

	// Destroy this Animation game object after animation ended
	IEnumerator DestroyAnimation()
	{
		// Get animation length from Animator Component
		float AnimationTime = GetComponent<Animator> ().GetCurrentAnimatorClipInfo (0).Length;

		// Wait animationTime before continuing 
		yield return new WaitForSeconds (AnimationTime);

		// Destroy this game object
		Destroy (this.gameObject);

	}

}
