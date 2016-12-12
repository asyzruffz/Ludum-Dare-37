using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerHealth : MonoBehaviour {

	public Health player;

	public HeartStatus one, two, three;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		switch (player.hp) 
		{
		case 3:
			one.status = true;
			two.status = true;
			three.status = true;
			break;
		case 2:
			one.status = true;
			two.status = true;
			three.status = false;
			break;
		case 1:
			one.status = true;
			two.status = false;
			three.status = false;
			break;
		case 0:
			one.status = false;
			two.status = false;
			three.status = false;
			break;
		}
	}
}
