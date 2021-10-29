using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void PlayGame(){
    	// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   		SceneManager.LoadScene("IntroImages");
    }

    public void QuitGame(){
    	Debug.Log("Quitting game...");
    	Application.Quit();
    }
}
