using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int totalHp;
	public int hp;
	public bool isInvincible;

	public delegate void CharacterDeathDelegate();
	public event CharacterDeathDelegate deathEvent;


	void Start () {
		hp = totalHp;
	}

	void Update() {
		if (hp <= 0) {
			GameMaster.UIState = GameUIState.GAMEOVER;
			deathEvent ();
		}
	}

	public void TakeDamage(int damage) {
		if (!isInvincible) {
			hp -= damage;
		}
	}
}
