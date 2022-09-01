using UnityEngine;

public abstract class Gate : MonoBehaviour
{
	private Animator anim;
	protected AudioSource src;

	private bool inRange;

	[SerializeField]
	protected AudioClip[] clips;
	public bool locked;

	void Awake()
	{
		anim = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
	}

	void Update()
	{
		Open();
	}

	private void Open()
	{
		if (!locked)
		{
			if (inRange)
			{
				anim.SetBool("open", true);
				src.PlayOneShot(clips[1]);
			}
			else
			{
				anim.SetBool("open", false);
				src.PlayOneShot(clips[2]);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			inRange = true;
			Unlock();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && !locked)
			inRange = false;
	}

	public abstract void Unlock();
}