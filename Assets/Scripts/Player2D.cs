using UnityEngine;
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

	[Header("Attack")]
	public GameObject swooshPrefab;

	private Controller2D controller;
	private Animator animator;
	private Vector2 directionalInput;
	private Vector2 velocity;
	private float velocityXSmoothing;
	public bool isDefending;
	private bool isHit;
	private bool isDead;
	private float hitTimer = 0;

	void Start () {
		controller = GetComponent<Controller2D> ();
		animator = GetComponent<Animator> ();
		GetComponent<Health> ().hitEvent += OnHit;
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

		// Set how long the hit animation to be
		if (isHit) {
			hitTimer += Time.deltaTime;
			if (hitTimer >= 0.5f) {
				hitTimer = 0;
				isHit = false;
			}
		}
	}

	public void SetDirectionalInput(Vector2 input) {
		directionalInput = input;
		if (directionalInput.x != 0) {
			// Flip the sprite appropriately
			transform.localScale = new Vector3 (directionalInput.x, transform.localScale.y, transform.localScale.z);

			animator.SetInteger ("animState", isDead ? 6 : isDefending ? 4 : isHit ? 5 : (controller.collisions.below) ? 1 : 2);
		} else {
			animator.SetInteger ("animState", isDead ? 6 : isDefending ? 4 : isHit ? 5 : (controller.collisions.below) ? 0 : 2);
		}
	}

	public void SetDefending (bool defend) {
		isDefending = defend;
		GetComponent<Health> ().isInvincible = defend;
	}

	public void SetAttacking (bool attack) {
		if (attack) {
			animator.SetInteger ("animState", 3);
		}
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

	void SwingSword() {
		Vector3 offset = new Vector3 (0.16f, 0.1f, 0) * Mathf.Sign (transform.localScale.x);
		GameObject swoosh = Instantiate (swooshPrefab, transform.position + offset, Quaternion.identity);
		swoosh.GetComponent<Projectile> ().sourceSpawn = "Player";
		swoosh.transform.parent = transform;
	}

	void OnHit () {
		isHit = true;
	}

	void OnDeath () {
		isDead = true;
	}

	public void DestroySelf() {
		Destroy (gameObject);
		GameMaster.SetGameStatus(true);
	}
}
