using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDialogueTrigger : MonoBehaviour
{
    public float dist;
	public bool passed = false;
    public Dialogue dialogue;

	void Update(){

		Debug.DrawRay(this.transform.position, Vector2.down * dist, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), dist);
        if(hit){
            GameObject Player = hit.transform.gameObject;
            if(Player.tag == "Player" && !passed)
            {
                passed = true;
                TriggerDialogue();
                
            }
        }
	}

    public void TriggerDialogue(){
        Debug.Log("Triggering dialogue...");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

