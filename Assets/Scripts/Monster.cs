using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FieldOfView2D))]
public class Monster : MonoBehaviour {

	public float speed = 1;
	public float attackRange = 1;
	public Vector2 target;

	//private Vector2 directionalInput;
	protected FieldOfView2D fov;
	protected Vector2 velocity;

	protected virtual void Start () {
		fov = GetComponent<FieldOfView2D> ();
	}
	
	protected virtual void Update () {
		transform.Translate (velocity * Time.deltaTime);
		SetDirectionalInput(velocity);
	}

	public void SetDirectionalInput(Vector2 input) {
		Vector2 directionalInput = input;
		if(directionalInput.x != 0) {
			// Flip the sprite for left direction
			transform.localScale = new Vector3(Mathf.Sign(directionalInput.x), transform.localScale.y, transform.localScale.z);
		}
	}
}
