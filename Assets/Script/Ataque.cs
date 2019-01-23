using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour {

	private GameObject target;
	public float speed = 50f;
	private static int score;

	public GameObject[] bloodSplash;
	public GameObject sangueEffect;

	void Start(){
		this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		this.GetComponent<Collider2D>().enabled = false;
	}

	void Update () {
		if(target == null){
			target = GameObject.Find("ataqueDestino(Clone)");
		}else{
			target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0);
			this.GetComponent<Collider2D>().enabled = true;
			transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
			if(Vector3.Distance(transform.position, target.transform.position) <= 0.05f){
				Destroy(this.gameObject);
				Destroy(target);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Enemy")){
			GameObject.Find("FX").GetComponent<FXManager>().enemyClip();
			Instantiate(bloodSplash[Random.Range(0,bloodSplash.Length)], other.transform.position, Quaternion.Euler(0,0, Random.Range(0,360)));
			Instantiate(sangueEffect, other.transform.position, Quaternion.identity);
			Destroy(other.gameObject);
			GameObject.FindGameObjectWithTag("GameController").GetComponent<UIManager>().Pontuador(10);
		}
		if(other.CompareTag("Enemy2")){
			GameObject.Find("FX").GetComponent<FXManager>().enemyClip();
			Instantiate(bloodSplash[Random.Range(0,bloodSplash.Length)], other.transform.position, Quaternion.Euler(0,0, Random.Range(0,360)));
			Instantiate(sangueEffect, other.transform.position, Quaternion.identity);
			Destroy(other.gameObject);
			GameObject.FindGameObjectWithTag("GameController").GetComponent<UIManager>().Pontuador(25);
		}
	}
}
