using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OpcionesJuego : MonoBehaviour
{

	public AudioMixer audioMixer;
	public Slider sliderVolumen;
	public Dropdown dropDownGraficas;
	// public Resolution[] resolutions;
	// public Dropdown dropDownRes;
	public Toggle toggleFullScreen;

	void Start(){
		// Debug.Log("Comenzando en juego setup de configs...");
		sliderVolumen.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);

		dropDownGraficas.value = PlayerPrefs.GetInt("QualitySettings", 2);

		// dropDownRes.ClearOptions();
		
		// dropDownRes.AddOptions(GameManagerSingleton.Instance.options);
		// dropDownRes.value = GameManagerSingleton.Instance.currentResolution;
		// dropDownRes.RefreshShownValue();

		// Debug.Log("Checando volume " + PlayerPrefs.GetFloat("MusicVolume", 0.75f));
		// Debug.Log("Checando volume " + PlayerPrefs.GetInt("QualitySettings", 2));
		// Debug.Log("Checando fullscreen " + GameManagerSingleton.Instance.isFullScreen);
		// Debug.Log("Checando res " + GameManagerSingleton.Instance.currentResolution);

		toggleFullScreen.isOn = GameManagerSingleton.Instance.isFullScreen;
		Screen.fullScreen = GameManagerSingleton.Instance.isFullScreen;

		// Debug.Log("Terminando en juego setup de configs...");

	}
     public void SetVolume(float volume){
		audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
		PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetQuality(int i){
    	QualitySettings.SetQualityLevel(i);
    	PlayerPrefs.SetInt("QualitySettings", i);
    }

    public void SetFullscreen(bool status){
    	Screen.fullScreen = status;
    	GameManagerSingleton.Instance.isFullScreen = status;
    }

    // public void SetResolution(int i){
    // 	GameManagerSingleton.Instance.currentResolution = i;
    // 	Resolution res = GameManagerSingleton.Instance.resolutions[i];
    // 	Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    // }
}
