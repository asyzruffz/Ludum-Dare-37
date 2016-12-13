using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMonsterTeaser : MonoBehaviour {

	public float speed;

	private AudioManager audioManager;
	private bool soundPlayed = false;

	void Start () {
		audioManager = GetComponent<AudioManager> ();
		Destroy (gameObject, 5);
	}

	void Update () {
		if (!soundPlayed) {
			audioManager.PlaySoundType ("Crawl");
			soundPlayed = true;
		}

		transform.Translate (Vector3.right * speed * Time.deltaTime, Space.World);
	}
}
