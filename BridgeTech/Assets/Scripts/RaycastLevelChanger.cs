using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastLevelChanger : MonoBehaviour
{
    public float dist;
    public string sceneName;

	void Update(){

		Debug.DrawRay(this.transform.position, Vector2.down * dist, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), dist);
        if(hit){
            GameObject Player = hit.transform.gameObject;
            if(Player.tag == "Player")
            {
                SceneManager.LoadScene(sceneName);
                
            }
        }
	}

    
}
