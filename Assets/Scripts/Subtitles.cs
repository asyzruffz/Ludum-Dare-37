using UnityEngine;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour {

	public float timePerPage = 1;
	public bool startOnAwake = true;
	public string[] subtitleText;
	[Header("Sound")]
	public AudioClip textSound;

	private Text displayText;
	private AudioSource audioSource;
	private float timer = 0;
	private int currentPage = 0;
	private bool textStart = true;
	private bool textEnd = false;

	void Start() {
		displayText = GetComponent<Text> ();
		audioSource = GetComponent<AudioSource> ();
		textStart = startOnAwake;
	}

	void Update () {
		if (textEnd || !textStart) {
			return;
		}

		if (timer >= timePerPage) {
			timer = 0;
			currentPage++;

			if (currentPage >= subtitleText.Length) {
				displayText.text = "";
				textEnd = true;
				return;
			} else {
				if (textSound) {
					audioSource.PlayOneShot (textSound);
				}
			}
		}

		if (subtitleText.Length > 0) {
			displayText.text = subtitleText[currentPage];
		}

		timer += Time.deltaTime;
	}

	public void RestartSubtitle() {
		currentPage = 0;
		timer = 0;
		textStart = true;
		textEnd = false;
	}

	public bool HasEnded() {
		return textEnd;
	}
}
