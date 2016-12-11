﻿using UnityEngine;
using System.Collections;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;                           //Store a reference to the Game Object PausePanel
	public GameObject creditsPanel;                         //Store a reference to the Game Object CreditsPanel
    public GameObject multiplayerPanel;                     //Store a reference to the Game Object MultiplayerPanel
    public GameObject gameOverPanel;                        //Store a reference to the Game Object GameOverPanel 

    //Call this function to activate and display the Options panel during the main menu
    public void ShowOptionsPanel() {
		optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel() {
		optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu() {
		menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu() {
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel() {
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel() {
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);

    }

    //Call this function to activate and display the Options panel during the main menu
    public void ShowMultiplayerPanel() {
        multiplayerPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    //Call this function to deactivate and hide the Options panel during the main menu
    public void HideMultiplayerPanel() {
        multiplayerPanel.SetActive(false);
        optionsTint.SetActive(false);
    }

    //Call this function to activate and display the GameOver panel after game play
    public void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
    }

    //Call this function to deactivate and hide the GameOver panel to restar or quit
    public void HideGameOverPanel() {
        gameOverPanel.SetActive(false);
	}

	//Call this function to activate and display the Credits panel after game play
	public void ShowCreditsPanel() {
		creditsPanel.SetActive(true);
	}

	//Call this function to deactivate and hide the Credits panel to restar or quit
	public void HideCreditsPanel() {
		creditsPanel.SetActive(false);
	}
}
