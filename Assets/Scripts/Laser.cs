using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public float vanishtime = 0f;
	public float speed;
	public Health player;
	// Use this for initialization
	void Start () {
		speed = 10;
		Destroy (gameObject, vanishtime);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;
		position = new Vector2 (position.x + speed * Time.deltaTime, position.y);
		transform.position = position;
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		if (transform.position.x > max.x) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.CompareTag ("Player")) {
			player.hp -= 1;
		}

	}
}
