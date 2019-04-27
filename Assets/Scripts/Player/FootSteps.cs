using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootSteps : MonoBehaviour
{
	AudioSource _audio;
	public AudioClip step;    
	void Start()
	{
		_audio = GetComponent<AudioSource>();
		_audio.playOnAwake = false;
		_audio.clip = step;

	}

	private void OnTriggerEnter(Collider other)
	{
		_audio.Play();
	}
}
