using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public Vector2 target;
	public Vector2 velocity;

	private Vector2 directionalInput;

	protected virtual void Start () {
		
	}
	
	protected virtual void Update () {
		transform.Translate (velocity * Time.deltaTime);
		SetDirectionalInput(velocity);
	}

	public void SetDirectionalInput(Vector2 input) {
		directionalInput = input;
		if(directionalInput.x != 0) {
			// Flip the sprite for left direction
			transform.localScale = new Vector3(Mathf.Sign(directionalInput.x), transform.localScale.y, transform.localScale.z);
		}
	}
}
