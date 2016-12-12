using UnityEngine;
using UnityEngine.SceneManagement;

public class ComingSoon : MonoBehaviour {

	private bool shifted = false;

	void Update() {
		if (GameMaster.PlayerWinId > 0 && !shifted) {
			transform.Translate (Vector3.right * 0.6f, Space.World);
			shifted = true;
		}
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (GameMaster.PlayerWinId > 0) {
			SceneManager.LoadScene ("Teaser");
		}
	}
}
