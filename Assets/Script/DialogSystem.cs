using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogSystem : MonoBehaviour {

	public Text textTop;
	public Text textBot;
	public string[] setencesTop;
	public string[] setencesBot;
	private int indexTop, indexBot;
	public float typingSpeed;
//	private AudioSource a_source;


	void Start(){
		StartCoroutine(TypeTop());
		//a_source = GetComponent<AudioSource>();
	}

	void Update()
	{
		if(indexBot == 1){
			GameObject.Find("Gato").GetComponent<Animator>().SetTrigger("GatoFadeIn");
		}

		if(textTop.text == setencesTop[indexTop] && textBot.text == setencesBot[indexBot])
			if(Input.anyKey)
				//a_source.Play();
				NextSentence();
	}

	IEnumerator TypeTop(){
		GUIStyle style = new GUIStyle ();
		style.richText = true;
		foreach(char letter in setencesTop[indexTop].ToCharArray()){
			textTop.text += letter;
			yield return new WaitForSeconds(typingSpeed);			
		}
		StartCoroutine(TypeBot());
	}

	IEnumerator TypeBot(){
		GUIStyle style = new GUIStyle ();
		style.richText = true;
		foreach(char letter in setencesBot[indexBot].ToCharArray()){
			textBot.text += letter;
			yield return new WaitForSeconds(typingSpeed);	
			//a_source.Stop();		
		}
	}

	public void NextSentence(){

		if(indexBot < setencesBot.Length - 1){
			indexBot++;
			textBot.text = "";
		}else{
			textBot.text = "";
        	Destroy(GameObject.Find("MusicMenu"));
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}

		if(indexTop < setencesTop.Length - 1){
			indexTop++;
			textTop.text = "";
			StartCoroutine(TypeTop());
		}else{
			textTop.text = "";
		}

	}
}
