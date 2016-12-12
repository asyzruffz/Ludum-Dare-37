using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMonster : Monster {

	[Header("Attack")]
	public GameObject laserPrefab;
	public float laserCooldown = 1;

	private Animator animator;
	private float laserTimer = 0;
	private bool isShooting = false;
	private bool isStaggered = false;
	private bool isDead = false;

	protected override void Start () {
		base.Start ();
		animator = GetComponent<Animator> ();
		GetComponent<Health> ().hitEvent += OnHit;
		GetComponent<Health> ().deathEvent += OnDeath;
	}
	
	protected override void Update () {
		base.Update ();
		SetAttacking (fov.HasTarget () && !(isStaggered || isDead));

		if (GetComponent<Health> ().hp <= 5) {
			isStaggered = true;
		}

		UpdateAnimation ();

		laserTimer += Time.deltaTime;
	}

	public void SetAttacking (bool attack) {
		if (attack) {
			if (fov.visibleTargets [0] != null) {
				// Set the target
				target = fov.visibleTargets [0].position;
			} else {
				return;
			}

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
		if (laserTimer >= laserCooldown) {
			laserTimer = 0;
			isShooting = true;

			Quaternion rotation = Quaternion.AngleAxis (Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
			GameObject laser = Instantiate (laserPrefab, transform.position + offset, rotation);
			laser.GetComponent<Projectile> ().direction = direction;
			laser.GetComponent<Projectile> ().sourceSpawn = "Enemy";
		} else {
			isShooting = false;
		}
	}

	void UpdateAnimation() {
		animator.SetInteger ("animState", isDead ? 3 : isStaggered ? 1 : isShooting ? 2 : 0);
	}

	void OnHit () {
		
	}

	void OnDeath () {
		isDead = true;
	}

	public void DestroySelf() {
		Destroy (gameObject);
	}
}
