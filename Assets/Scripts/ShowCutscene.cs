using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowCutscene : MonoBehaviour {
	
	void OnEnable() {
		SceneManager.sceneLoaded += SceneWasLoaded;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= SceneWasLoaded;
	}

	void SceneWasLoaded(Scene scene, LoadSceneMode mode) {
		if (GameMaster.showCutscene) {
			SceneManager.LoadScene ("Backstory");
			GameMaster.showCutscene = false;
		}
	}
}
