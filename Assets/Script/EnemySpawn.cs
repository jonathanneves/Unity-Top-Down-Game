using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public GameObject enemies;
	public Transform[] spawns;
	private float timeBtwEnemy;
    public float startTimeBtwEnemy = 3f;
    public float increaseLevel = 0.5f;
    private int level = 1;


	void Update () {
		//float angle = Random.Range(0.0f,Mathf.PI*2); 
		//Vector3 V = new Vector3(Mathf.Sin(angle),0,Mathf.Cos(angle));
		//V *= Range;

		if(startTimeBtwEnemy > 2f){
			if(GameObject.Find("GameManager").GetComponent<UIManager>().getScore() > 100 * level){
	            startTimeBtwEnemy -= increaseLevel;
	            level++;
	            Debug.Log(GameObject.Find("GameManager").GetComponent<UIManager>().getScore());
	        }
    	}

       	if (timeBtwEnemy <= 0)
        {
            Instantiate(enemies, spawns[Random.Range(0, spawns.Length)].position, Quaternion.identity);
            if(startTimeBtwEnemy <= 2f){
            	Instantiate(enemies, spawns[Random.Range(0, spawns.Length)].position, Quaternion.identity);
            }
            timeBtwEnemy = startTimeBtwEnemy;
        }
        else
        {
            timeBtwEnemy -= Time.deltaTime;
        }
	}
}
