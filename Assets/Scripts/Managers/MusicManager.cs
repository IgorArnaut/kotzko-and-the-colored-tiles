using UnityEngine;

public class MusicManager : MonoBehaviour
{
	// Instanca
	public static MusicManager Manager;

	// Komponente
	private AudioSource src;

	// Zvuci
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

	// Pusta zvuk jednom
	public void PlayOneshot(AudioClip clip)
	{
		if (!src.isPlaying) src.PlayOneShot(clip);
	}

	// Pusta zvuk
	public void Play()
	{
		src.Play();
	}

	// Prekida pustanje
	public void Stop()
	{
		src.Stop();
	}
}