using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	// Components
    private AudioSource src;

	void Awake()
	{
		GetComponents();
	}

	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Play oneshot
	public void PlayOneShot(AudioClip clip)
	{
		src.PlayOneShot(clip);
	}
}
