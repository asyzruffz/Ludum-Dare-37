﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player2D : MonoBehaviour {

	public float moveSpeed = 6;
	public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = 0.4f;
	public float accelerationTimeGrounded = 0.1f;
	public float accelerationTimeAirborne = 0.2f;

	private float maxJumpSpeed;
	private float minJumpSpeed;
	private float gravity;

	private Controller2D controller;
	private Animator animator;
	private Vector2 directionalInput;
	private Vector2 velocity;
	private float velocityXSmoothing;

	void Start () {
		controller = GetComponent<Controller2D> ();
		animator = GetComponent<Animator> ();
		GetComponent<Health> ().deathEvent += OnDeath;

		gravity = (2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
		maxJumpSpeed = gravity * timeToJumpApex;
		minJumpSpeed = Mathf.Sqrt (gravity * minJumpHeight);
	}

	void Update () {
		CalculateVelocity ();

		controller.Move (velocity * Time.deltaTime);

		// Reset velocity gained by gravity if collided above and below
		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}
	}

	public void SetDirectionalInput(Vector2 input) {
		directionalInput = input;
		if (directionalInput.x != 0) {
			// Flip the sprite appropriately
			transform.localScale = new Vector3 (directionalInput.x, transform.localScale.y, transform.localScale.z);

			animator.SetInteger ("animState", 1);
		} else {
			animator.SetInteger ("animState", 0);
		}
	}

	public void SetAttacking (bool attack) {
		animator.SetBool ("attacking", attack);
	}

	public void OnJumpInputDown() {
		if (controller.collisions.below) {
			velocity.y = maxJumpSpeed;
		}
	}

	public void OnJumpInputUp() {
		if (velocity.y > minJumpSpeed) {
			velocity.y = minJumpSpeed;
		}
	}

	private void CalculateVelocity() {
		float targetVelocityX = directionalInput.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
		velocity.y += -gravity * Time.deltaTime;
	}

	void OnDeath () {
		Destroy (gameObject);
	}
}
