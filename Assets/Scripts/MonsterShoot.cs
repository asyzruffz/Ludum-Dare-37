using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour {
	
	public float laservelocity;
	public GameObject laser;
	public Player2D player;
	public float shootRate=0f;
	public float shootRateStamp=0f;

	// Use this for initialization
	void Start () {
		laservelocity = 3;
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)&&Time.time>shootRateStamp) {
				GameObject go = (GameObject)Instantiate (laser, transform.position, Quaternion.identity);
			shootRateStamp = Time.time + shootRate;
	}
}

}