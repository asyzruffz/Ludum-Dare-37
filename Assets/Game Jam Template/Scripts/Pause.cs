using UnityEngine;

public class Pause : MonoBehaviour {

	private ShowPanels showPanels;						//Reference to the ShowPanels script used to hide and show UI panels
    private GameUIState pauseFrom;
	
	//Awake is called before Start()
	void Awake() {
		//Get a component reference to ShowPanels attached to this object, store in showPanels variable
		showPanels = GetComponent<ShowPanels> ();
        pauseFrom = GameUIState.MAINMENU;
    }

	// Update is called once per frame
	void Update () {
		//Check if the Cancel button in Input Manager is down this frame (default is Escape key) and that game is not paused, and that we're not in main menu
		if (Input.GetButtonDown ("Cancel") && GameMaster.UIState == GameUIState.INGAME) {
			//Call the DoPause function to pause the game
			DoPause();
		} 
		//If the button is pressed and the game is paused and not in main menu
		else if (Input.GetButtonDown ("Cancel") && GameMaster.UIState == GameUIState.PAUSED) {
			//Call the UnPause function to unpause the game
			UnPause ();
		}
	
	}
    
	public void DoPause() {
        pauseFrom = GameMaster.UIState;
        GameMaster.UIState = GameUIState.PAUSED;
		//Set time.timescale to 0, this will cause animations and physics to stop updating
        if(GameMaster.IsSinglePlayerMode) {
            Time.timeScale = 0;
        }
		//call the ShowPausePanel function of the ShowPanels script
		showPanels.ShowPausePanel ();
	}
    
	public void UnPause() {
        GameMaster.UIState = pauseFrom;
        //Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
        if (GameMaster.IsSinglePlayerMode) {
            Time.timeScale = 1;
        }
        //call the HidePausePanel function of the ShowPanels script
        showPanels.HidePausePanel ();
	}
}
