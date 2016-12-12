using UnityEngine;
using UnityEngine.UI;

public class FadeBlack : MonoBehaviour {

	public Text toBeContinued;

	private Animator animColorFade;

	void Start () {
		animColorFade = GetComponent<Animator> ();
		animColorFade.SetTrigger ("fadeBlack");
	}

	public void ShowContinueText() {
		toBeContinued.gameObject.SetActive (true);
	}
}
