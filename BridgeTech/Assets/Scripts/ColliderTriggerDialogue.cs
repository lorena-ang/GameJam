using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTriggerDialogue : MonoBehaviour
{
    public bool passed = false;
    public Dialogue dialogue;
    Collider2D col;

    void Start(){
    	col = GetComponent<Collider2D>();
    }


    void OnCollisionEnter2D(Collision2D other){
    	if(other.collider.tag == "Player" && !passed){
    		passed = true;
    		TriggerDialogue();
    		col.enabled = false;

    	}
    }

    public void TriggerDialogue(){
        Debug.Log("Triggering dialogue...");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
