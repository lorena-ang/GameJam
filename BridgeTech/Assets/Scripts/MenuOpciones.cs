using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
	public AudioMixer audioMixer;
	public Slider sliderVolumen;
	public Dropdown dropDownGraficas;
	public Resolution[] resolutions;
	public Dropdown dropDownRes;

	void Start(){
		Debug.Log("Comenzando setup de configs...");
		// sliderVolumen = GameObject.Find("SliderVolumen").GetComponent<Slider>();
		sliderVolumen.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);

		// dropDownGraficas = GameObject.Find("DropdownGraficas").GetComponent<Dropdown>();
		dropDownGraficas.value = 2;
		QualitySettings.SetQualityLevel(2);
		dropDownGraficas.value = PlayerPrefs.GetInt("QualitySettings", 2);

		// dropDownRes = GameObject.Find("DropdownResolucion").GetComponent<Dropdown>();
		resolutions = Screen.resolutions;
		dropDownRes.ClearOptions();
		
		List<string> options = new List<string>();
		int currentResolution = 0;
		for(int i = 0; i < resolutions.Length; ++i){
			string buffer = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(buffer);

			if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
				currentResolution = i;
			}
		}
		dropDownRes.AddOptions(options);
		dropDownRes.value = currentResolution;
		dropDownRes.RefreshShownValue();

		Debug.Log("Comenzando setup de configs...");

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
    }

    public void SetResolution(int i){
    	Resolution res = resolutions[i];
    	Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
