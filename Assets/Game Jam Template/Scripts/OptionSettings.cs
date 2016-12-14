using UnityEngine;
using UnityEngine.UI;

public class OptionSettings : MonoBehaviour {

	public Toggle cutsceneToggle;

	void Update () {
		cutsceneToggle.isOn = GameMaster.showCutscene;
	}
}
