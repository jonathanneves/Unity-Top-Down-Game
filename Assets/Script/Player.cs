using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Movement
	public float speed = 7f;
	private float dashTime;
	public float startTimeDash = 0.5f;
	private float speedModifier = 1;
	public float startSpeed = 5.5f;
	public Animator animator;

	//Dash
	private float delayDash;
	public float timeBtwDash = 0.1f;
	private Rigidbody2D rb;
	public TrailRenderer trailEmit;

	//Golpe
	public GameObject ataqueOrigem;
	public GameObject ataqueDestino;
	private bool primeiroGolpe = true;
	private bool segundoGolpe = true;
	public float speedAtaque;
	public float delayTime;
	private Vector3 clickPosition;
	private Camera cam;

	public GameObject deathPart;

  	void Start(){
  		rb = GetComponent<Rigidbody2D>();
  		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
  	}

	void Update () {
		
		//ATAQUE
		clickPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetMouseButtonDown(0)){
			if(primeiroGolpe){
				Instantiate(ataqueOrigem, clickPosition, Quaternion.identity);
				primeiroGolpe = false;
			}else if(segundoGolpe){
				GameObject.Find("FX").GetComponent<FXManager>().playClip();
				Instantiate(ataqueDestino, clickPosition, Quaternion.identity);
				segundoGolpe = false;
				StartCoroutine(ataque());
			}
		}
		//MOVEMENTO
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0.0f);

		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Magnitude", movement.magnitude);

		rb.MovePosition(transform.position + movement * Time.deltaTime * speed * speedModifier);

		//DASH
		if (Input.GetButtonDown("Jump") && dashTime <= 0 && Time.time >= delayDash){
			GameObject.Find("FX").GetComponent<FXManager>().playerDash();
			trailEmit.emitting = true;
			//player.GetComponent<TrailRenderer>().emitting = true; = true;
			delayDash = Time.time + timeBtwDash;
			//Debug.Log("DASH "+delayDash);
    		dashTime = startTimeDash;
    	}

		if (dashTime > 0) {
			dashTime -= Time.deltaTime;
		    speedModifier = startSpeed;
		}
		 
		if (dashTime <= 0) {
			trailEmit.emitting = false;
		    speedModifier = 1;
		}
	}

	IEnumerator ataque(){
		yield return new WaitForSeconds(delayTime);
		primeiroGolpe = true;
		segundoGolpe = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Projectile")){			
			StartCoroutine(MorteDelay());
		}else if(other.CompareTag("Enemy")){
			StartCoroutine(MorteDelay());
		}else if(other.CompareTag("Enemy2")){
			StartCoroutine(MorteDelay());
		}
	}

	IEnumerator MorteDelay(){
		Instantiate(deathPart, transform.position, Quaternion.identity);
		this.GetComponent<SpriteRenderer>().enabled = false;
		this.GetComponent<TrailRenderer>().enabled = false;
		yield return new WaitForSeconds(0.3f);
		GameObject.Find("FX").GetComponent<FXManager>().playerClip();
		GameObject.FindGameObjectWithTag("GameController").GetComponent<UIManager>().pauseMenu();
	}
}
