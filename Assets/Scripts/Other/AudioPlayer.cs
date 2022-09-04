using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	// Komponente
    private AudioSource src;

	void Awake()
	{
		GetComponents();
	}

	// Uzima komponente
	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Pusta zvuk jednom
	public void PlayOneShot(AudioClip clip)
	{
		src.PlayOneShot(clip);
	}
	

	// Pusta zvuk jednom 2
	public void PlayOneShot2(AudioClip clip)
	{
		if (!src.isPlaying) src.PlayOneShot(clip);
	}
}
