using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGSoundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void Awake(){
		GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
		if (objs.Length > 1)
			Destroy(this.gameObject);
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().name == "Fighting")
		{
			Destroy(this.gameObject);
		}
	}
}
