using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EnterGame : MonoBehaviour {

	public VideoPlayer myVideo;
	void Update(){
		if (!myVideo.isPlaying) { 
			if (Input.GetMouseButtonDown (0)) {
				SceneManager.LoadScene ("Main Menu");
			}
		} else {
			if (Input.GetMouseButtonDown (0)) {
				myVideo.frame = 333;
			}
		}
	}
}
