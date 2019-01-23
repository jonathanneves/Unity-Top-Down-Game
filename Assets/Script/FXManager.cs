using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour {

	public AudioSource a_source;
	public AudioClip splashFX;
	public AudioClip dashFX;
	public AudioClip playerDeath;
	public AudioClip[] a_clips;

	void Start () {
		a_source = GetComponent<AudioSource>();
	}

	public void playClip(){
		//if(!a_source.isPlaying){
			a_source.clip = a_clips[Random.Range(0, a_clips.Length)];
			a_source.PlayOneShot(a_source.clip);
		//}
	}

	public void enemyClip(){
		a_source.PlayOneShot(splashFX);
	}

	public void playerClip(){
		a_source.PlayOneShot(playerDeath);
	}

	public void playerDash(){
		a_source.PlayOneShot(dashFX, 0.2f);
	}
}
