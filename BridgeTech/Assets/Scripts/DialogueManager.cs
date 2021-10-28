using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class DialogueManager : MonoBehaviour
{
	private Queue<string> sentences;
	public Text nameText;
	public Text dialogueText;
	public AudioSource TypeSound;
	public GameObject dialogueBox;


    void Start()
    {
    	TypeSound = GetComponent<AudioSource>();
        sentences = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue){
    	// Debug.Log("Starting conv with " + dialogue.charName);
    	Time.timeScale = 0f;
    	dialogueBox.SetActive(true);
    	nameText.text = dialogue.charName;
    	sentences.Clear();
    	foreach(string sentence in dialogue.sentences){
    		sentences.Enqueue(sentence);
    	}
    	DisplayNextSentence();
    }

    public void DisplayNextSentence(){
    	if(sentences.Count == 0){
    		EndDialogue();
    		return;
    	}

    	string sentence = sentences.Dequeue();
    	// Debug.Log(sentence);
    	// dialogueText.text = sentence;
    	StopAllCoroutines();
    	StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence){
    	TypeSound.Play();
    	dialogueText.text = "";
    	foreach(char letter in sentence.ToCharArray()){
    		dialogueText.text += letter;
    		// yield return null;
    		// yield return new WaitForSeconds(0.02f);
    		yield return new WaitForSecondsRealtime(0.02f);
    	}
    	// yield return new WaitForSeconds(1.0f);
    	yield return new WaitForSecondsRealtime(1.0f);
		TypeSound.Stop();    	
    	// TypeSound.Stop();
    }

    public void EndDialogue(){
    	Debug.Log("End of conv");
    	Time.timeScale = 1f;

    	if(TypeSound.isPlaying){
    		TypeSound.Stop();
    	}
    	dialogueBox.SetActive(false);
    }
}
