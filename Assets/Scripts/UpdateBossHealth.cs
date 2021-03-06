﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBossHealth : MonoBehaviour {

	[Range(0,1)]
	public float health;
	public Health monster;

	private float healthBefore;
	Rect rectHealth;

	// Use this for initialization
	void Start () {
		rectHealth = GetComponent<RectTransform> ().rect;
		healthBefore = rectHealth.width;
	}
	
	// Update is called once per frame
	void Update () {
		health = (float)monster.hp / monster.totalHp;

		rectHealth.width = health * healthBefore;
		//GetComponent<RectTransform> ().offsetMin = rectHealth.min;
		//GetComponent<RectTransform> ().offsetMax = rectHealth.max-22;
		RectTransform rt = GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2(rectHealth.width, rectHealth.height);
	}
}
