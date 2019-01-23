using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
	
	public float speed;
	public float stoppingDistance;
	public float retreatDistance;

    /*public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject ProjectilePrefab;

    private Vector3 startPoint;
    private const float radius = 1f;*/

	private float timeBtwShots;
	public float startTimeBtwShots; 

	public float moveSpeed = 3f;
	public GameObject ProjectilePrefab;
	public Animator animator;

//	public GameObject projectile;

	private Transform player;

	void Start () {
//		startPoint = Vector3.zero;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		timeBtwShots = startTimeBtwShots;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Vector2.Distance(transform.position, player.position) > stoppingDistance){
			transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
		} else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position,player.position) > retreatDistance){
			transform.position = this.transform.position;
		} else if(Vector2.Distance(transform.position, player.position)<retreatDistance){
			transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
		}

     	Vector3 movement = new Vector3(player.transform.position.x, player.transform.position.y, 0.0f);
     	
		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Magnitude", movement.magnitude);


		if(timeBtwShots <=0){
			CheckTimeToFire();
			//SpawnProjectile(numberOfProjectiles);
			timeBtwShots = startTimeBtwShots;
		}else{
			timeBtwShots -= Time.deltaTime;
		}
	}

	/*private void SpawnProjectile(int _numberOfProjectiles)
    {
        float angleStep = 45f / _numberOfProjectiles;
        float angle = 1f;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - player.transform.position).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;
        }
    }*/

    private void CheckTimeToFire(){
    //	if(Time.time > nextFire){
	    	GameObject tmpObj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
	    	Vector2 moveDirection = (player.transform.position - tmpObj.transform.position).normalized * moveSpeed;
	    	tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x, moveDirection.y);

	    	//nextFire = Time.time + fireRate;
    }
}
