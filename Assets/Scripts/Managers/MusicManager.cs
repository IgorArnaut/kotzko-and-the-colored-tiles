using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public static MusicManager Manager;

	private AudioSource src;

	[SerializeField]
	public AudioClip[] clips;

	void Awake()
	{
		Manager = this;	
		src = GetComponent<AudioSource>();
	}

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