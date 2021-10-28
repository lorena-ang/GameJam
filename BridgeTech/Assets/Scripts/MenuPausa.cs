using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

	// Si esta otro menu yhace click en escape regresar a menu principal enable
	public static bool paused = false;
	public GameObject pauseMenuUI;
	public GameObject controlsMenuUI;
	public GameObject optionsMenuUI;
	public GameObject mainMenuUI;

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(paused){
					Resume();
				}else{
					Pause();
				}
		}
	}

	void Resume(){
		mainMenuUI.SetActive(true);
		controlsMenuUI.SetActive(false);
		optionsMenuUI.SetActive(false);
		
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		paused = false;
	}

	void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		paused = true;

	}

    public void QuitGame(){
    	Debug.Log("Quitting game...");
    	Application.Quit();
    }
}
