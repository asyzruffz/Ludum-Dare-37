using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMonster : Monster {

	[Header("Attack")]
	public GameObject laserPrefab;
	public float laserCooldown = 1;

	private float timer = 0;

	protected override void Start () {
		base.Start ();
	}
	
	protected override void Update () {
		base.Update ();
		SetAttacking (fov.HasTarget ());

		timer += Time.deltaTime;
	}

	public void SetAttacking (bool attack) {
		if (attack) {
			// Set the target
			target = fov.visibleTargets [0].position + Vector3.up; // Add (0,1,0) to offset the target destination

			// Move towards attacking range
			Vector2 diff = target - (Vector2)transform.position;
			Vector2 targetDirection = diff.normalized;
			if (diff.magnitude > attackRange) {
				// Move nearer
				velocity = speed * targetDirection;
			} else {
				// Attack here
				velocity = Vector2.zero;
				ShootLaser ((diff - Vector2.up).normalized); // Substract (0,1,0) back
			}
		} else {
			// Stop attacking
			velocity = Vector2.zero;
		}
	}

	void ShootLaser(Vector2 direction) {
		Quaternion rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
		GameObject laser = Instantiate (laserPrefab, transform.position, rotation);
		laser.GetComponent<Projectile> ().direction = direction;
	}
}
