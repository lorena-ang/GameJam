using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public void BackToMainMeno(){
    	SceneManager.LoadScene(0);
    }

    public void QuitGame(){
    	Debug.Log("Quitting game...");
    	Application.Quit();
    }
}
