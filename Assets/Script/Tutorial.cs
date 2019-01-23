using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public GameObject panel;
	public GameObject Spawn;
	public Text start;
	private int cont = 0;

    void Update(){

    	if (Input.GetMouseButtonDown(0)){
    		cont++;
		}
		if(cont >= 2){
			panel.SetActive(false);
			Spawn.SetActive(true);
			start.text = "";
		}
    }
}
