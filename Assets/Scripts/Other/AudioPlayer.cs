using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	// Components
    private AudioSource src;

	void Awake()
	{
		GetComponents();
	}

	// Gets components
	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Plays a oneshot
	public void PlayOneShot(AudioClip clip)
	{
		src.PlayOneShot(clip);
	}
	
	public void PlayOneShot2(AudioClip clip)
	{
		if (!src.isPlaying) src.PlayOneShot(clip);
	}
}
