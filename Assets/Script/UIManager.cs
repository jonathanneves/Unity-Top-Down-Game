using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	private static int score = 0;
	private static int scoreRecord;
	public Text scoreText;

	public Text pontuacaoText;
	public Text recordText;
	public GameObject pauseMenuUI;
	private bool morto = false;

	void Start () {
		score = 0;
		scoreText.text = "Score: "+score;
		scoreRecord = PlayerPrefs.GetInt("Melhor Recorde");
	}
	
	// Update is called once per frame
	void Update () {
		if(morto){
			if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Return)){
				morto = false;
				Time.timeScale = 1f;
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
			if(Input.GetKeyDown(KeyCode.Escape)){
				Application.Quit();
			}
		}
	}

	public void Pontuador(int scr){
		CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
		score += scr;
		scoreText.text = "Score: "+score;
		StartCoroutine(mudarCor());
	}

	public void pauseMenu(){
		scoreText.text = "";
		if(score>=scoreRecord){
			scoreRecord = score;		
			PlayerPrefs.SetInt("Melhor Recorde", scoreRecord);
		}
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		pontuacaoText.text = "Sua Pontuação: "+score;
		recordText.text = "Melhor Recorde: "+scoreRecord;
		morto = true;
	}

	IEnumerator mudarCor(){
		scoreText.color = Color.yellow;
		scoreText.fontSize += 3;
		scoreText.rectTransform.rotation = Quaternion.Euler(0,0, Random.Range(-5,5));
		yield return new WaitForSeconds(1f);
		scoreText.color = Color.white;
		scoreText.rectTransform.rotation = Quaternion.Euler(0,0,0);
		scoreText.fontSize = 90;
	}

	public int getScore(){
		return score;
	}

	public void voltarMenu(){
		Destroy(GameObject.Find("Music"));
		Destroy(GameObject.Find("TutorialController"));
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
	}
}
