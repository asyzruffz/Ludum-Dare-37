using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour{

	public AudioClip[] audios;

	// Use this for initialization
	void Start () {
		
	}

	void PlaySound (){
		AudioSource audio = gameObject.AddComponent<AudioSource >();
		audio.PlayOneShot (Randommizer());
	}

	AudioClip Randommizer (){
		int size = audios.Length;
		System.Random r = new System.Random();
		int rIndex = r.Next(0, size);
		return audios [rIndex];
	}

	// Update is called once per frame
	void Update () {
		// test
		if (true) {
			PlaySound ();
		}
	}
}
