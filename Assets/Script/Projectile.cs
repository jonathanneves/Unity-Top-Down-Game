using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour {

	private Transform player;
	private Vector2 target;
	public float lifeTime = 5f;

	void Awake(){
   		Invoke("DestroyProjectile", lifeTime);
	}

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player").transform;
		target = new Vector2(player.position.x, player.position.y);
	}

	void Update(){
		//transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
		//SpawnProjectile(int numberOfProjectiles);

		if(transform.position.x == target.x && transform.position.y == target.y){
			DestroyProjectile();
		}
	}



	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			DestroyProjectile();
			//Destroy(other);
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void DestroyProjectile(){
		Destroy(this.gameObject);
	}
}
