using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void changeScene(string scenename){
		StartCoroutine (changeSceneDelay (scenename));
	}

	IEnumerator changeSceneDelay(string scenename,float delay = 0.075f){
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene (scenename);
	}
		
}
