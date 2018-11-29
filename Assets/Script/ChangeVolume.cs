using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ChangeVolume : MonoBehaviour {

	public AudioMixer audioMixer;
	public Slider slider;
	public string mySlider;
	public string parameter;

	public void Start(){
		slider.value = PlayerPrefs.GetFloat (mySlider, 0.75f);
	}

	public void SetVolume(float sliderValue){
		audioMixer.SetFloat (parameter, Mathf.Log10(sliderValue) * 20);
		PlayerPrefs.SetFloat (mySlider, sliderValue);
	}

	public float Test_SetVolume(float sliderValue){
		/*audioMixer.SetFloat (parameter, Mathf.Log10(sliderValue) * 20);
		PlayerPrefs.SetFloat (mySlider, sliderValue);*/

		float test = Mathf.Log10 (sliderValue) * 20;
		return test;

	}

}
