using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMonster : Monster {

	[Header("Attack")]
	public GameObject laserPrefab;
	public float laserCooldown = 1;

	private float timer = 0;
	private Animator animator;
	private bool isStaggered = false;
	private bool isDead = false;

	protected override void Start () {
		base.Start ();
		animator = GetComponent<Animator> ();
		GetComponent<Health> ().deathEvent += OnDeath;
	}
	
	protected override void Update () {
		base.Update ();
		SetAttacking (fov.HasTarget () && !isDead);

		timer += Time.deltaTime;
	}

	public void SetAttacking (bool attack) {
		if (attack) {
			// Set the target
			target = fov.visibleTargets [0].position;

			Vector2 diff = target - (Vector2)transform.position;
			// Move towards attacking range
			if (diff.magnitude > attackRange) {
				Vector2 targetDirection = (diff + Vector2.up).normalized; // Add (0,1,0) to offset the target destination
				velocity = speed * targetDirection;
			} else {
				// Attack here
				Vector3 offset = new Vector3(-0.1f * Mathf.Sign(transform.localScale.x), 0.48f, 0); // offset of eye position
				diff = target - (Vector2)(transform.position + offset);
				Vector2 aim = diff.normalized;
				ShootLaser (aim, offset);

				SetDirectionalInput (aim);
				velocity = Vector2.zero;
			}
		} else {
			// Stop attacking
			velocity = Vector2.zero;
		}
	}

	void ShootLaser(Vector2 direction, Vector3 offset) {
		if (timer >= laserCooldown && !isDead) {
			timer = 0;
			animator.SetInteger ("animState", 2);

			Quaternion rotation = Quaternion.AngleAxis (Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
			GameObject laser = Instantiate (laserPrefab, transform.position + offset, rotation);
			laser.GetComponent<Projectile> ().direction = direction;
			laser.GetComponent<Projectile> ().sourceSpawn = "Enemy";
		} else {
			if (isStaggered) {
				animator.SetInteger ("animState", 1);
			} else {
				animator.SetInteger ("animState", 0);
			}
		}
	}

	void OnDeath () {
		isDead = true;
		animator.SetInteger ("animState", 3);
		Destroy (gameObject, 2);
	}
}
