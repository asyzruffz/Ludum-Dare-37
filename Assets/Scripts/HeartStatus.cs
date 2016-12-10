using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartStatus : MonoBehaviour {

	public bool status;

	// Use this for initialization
	void Start () {
		status = true;	
	}

	void Update (){
			GetComponent<Image> ().enabled = status;
	}
}
