using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int totalHp;
	public int hp;
	public bool isInvincible;

	public delegate void CharacterDeathDelegate();
	public delegate void CharacterHitDelegate();
	public event CharacterDeathDelegate deathEvent;
	public event CharacterHitDelegate hitEvent;

	void Start () {
		hp = totalHp;
	}

	void Update() {
		if (hp <= 0) {
			deathEvent ();
		}
	}

	public void TakeDamage(int damage) {
		if (!isInvincible) {
			hp -= damage;
			hitEvent ();
		}
	}
}
