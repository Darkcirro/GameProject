using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	// Update is called once per frame
	public void exit(){
		StartCoroutine (quitDelay ());

	}

	IEnumerator quitDelay(float delay = 0.05f){
		yield return new WaitForSeconds (delay);
		Application.Quit();
	}

}
