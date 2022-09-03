using UnityEngine;

public class MusicManager : MonoBehaviour
{
	// Instance
	public static MusicManager Manager;

	// Components
	private AudioSource src;

	// Audio clips
	[SerializeField]
	public AudioClip[] clips;

	void Awake()
	{
		Manager = this;
		GetComponents();
	}

	// Get Components
	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Plays a oneshot
	public void PlayOneshot(AudioClip clip)
	{
		if (!src.isPlaying) src.PlayOneShot(clip);
	}

	// Plays audio clip
	public void Play()
	{
		src.Play();
	}

	// Stops playing
	public void Stop()
	{
		src.Stop();
	}
}