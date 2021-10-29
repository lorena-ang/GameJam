using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioClip song;

    private void Awake(){

    	if(Instance != null){
    		Destroy(gameObject);
    		return;
    	}

    	Instance = this;
    	DontDestroyOnLoad(gameObject);
    }

    public void ChangeSong(){
    	AudioSource audio = GetComponent<AudioSource>();
    	audio.Stop();
    	audio.clip = song;
    	audio.Play();
    }
}
