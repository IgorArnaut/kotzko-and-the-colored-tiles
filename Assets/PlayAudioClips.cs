using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioClips : MonoBehaviour
{
    private AudioSource src;

	void Awake()
	{
		src = GetComponent<AudioSource>();
	}

	public void PlayOneShot(AudioClip clip)
	{
		src.PlayOneShot(clip);
	}
}
