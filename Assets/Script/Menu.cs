using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	
	void Start(){
        Destroy(GameObject.Find("Music"));
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}
	}

	public void creditos(){
		SceneManager.LoadScene("Creditos");
	}

	public void voltar(){
		SceneManager.LoadScene("Menu");
	}
	
	public void sair(){
		Application.Quit();
	}
}
