using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour {
	private bool attacking=false;
	private float attacktimer = 0;
	private float attackcd = 0.3f;
	public Collider2D slash;

	void awake()
	{
		slash.enabled=false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)&&!attacking) {
			attacking = true;
			attacktimer = attackcd;
			slash.enabled = true;
		}
		if (attacking) {
			if (attacktimer > 0) {
				attacktimer -= Time.deltaTime;
			} else {
				attacking = false;
				slash.enabled = false;
			}
		}
	}
}
