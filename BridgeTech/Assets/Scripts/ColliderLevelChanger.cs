using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderLevelChanger : MonoBehaviour
{
	public string sceneName;

    void OnCollisionEnter2D(Collision2D other){
    	if(other.collider.tag == "Player"){
    		SceneManager.LoadScene(sceneName);
    	}
    }
}
