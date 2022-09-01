using UnityEngine;

public class AudioPlayer : MonoBehaviour
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
