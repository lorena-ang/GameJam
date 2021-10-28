using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(){
    	Debug.Log("Triggering dialogue...");
    	FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}