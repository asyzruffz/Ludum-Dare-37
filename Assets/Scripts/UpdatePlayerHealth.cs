using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerHealth : MonoBehaviour {

	//[Range(0,3)]
	//public int health;
	public Health player;

	public HeartStatus one, two, three;

	// Use this for initialization
	void Start () {
		//if (player.hp <= 1)
		//	one.status = true;
		//else if (player.hp <= 2)
	//		two.status = true;
	//	else if (player.hp <= 3)
	//		three.status = true;
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
