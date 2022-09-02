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

	// Play & stop
	public void PlayOneshot(AudioClip clip)
	{
		src.PlayOneShot(clip);
	}

	public void Play()
	{
		src.Play();
	}

	public void Stop()
	{
		src.Stop();
	}
}