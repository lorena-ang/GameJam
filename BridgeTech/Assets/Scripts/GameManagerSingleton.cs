using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton Instance;
    // public float volume;
    // public int quality;
    // public List<string> options;
    // public Resolution[] resolutions;
    // public int currentResolution;
    public bool isFullScreen;

    private void Awake(){

    	if(Instance != null){
    		Destroy(gameObject);
    		return;
    	}

    	Instance = this;
    	DontDestroyOnLoad(gameObject);
    }
}
