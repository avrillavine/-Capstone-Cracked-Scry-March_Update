using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FireSound : MonoBehaviour
{
	public AudioClip[] _clipStorage;

	AudioSource _audio;
	// Start is called before the first frame update
	void Start()
    {
		_audio = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
		_audio.Play();
		_audio.PlayOneShot(_clipStorage[Random.Range(0, _clipStorage.Length)]);
	}
}
