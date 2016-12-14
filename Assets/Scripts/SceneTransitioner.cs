using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour {

	public Subtitles story;

	void Update () {
		if (story.HasEnded ()) {
			SceneManager.LoadScene ("MainGame");
		}
	}
}
