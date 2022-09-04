using UnityEngine;

public class MusicManager : MonoBehaviour
{
	// Instanca
	public static MusicManager Manager;

	// Komponente
	private AudioSource src;

	// Klipovi
	public AudioClip[] clips;

	void Awake()
	{
		Manager = this;
		GetComponents();
	}

	// Uzima komponente
	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Pusta klip jednom
	public void PlayOneshot(AudioClip clip)
	{
		if (!src.isPlaying) src.PlayOneShot(clip);
	}

	// Pusta klip
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