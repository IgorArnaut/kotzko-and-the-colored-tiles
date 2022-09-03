using UnityEngine;

public abstract class Gate : MonoBehaviour
{
	// Components
	private Animator anim;
	protected AudioSource src;

	// Unlock
	[SerializeField]
	protected AudioClip[] clips;
	public bool locked;

	void Awake()
	{
		GetComponents();
	}

	void Start()
	{
		locked = true;
	}

	// Gets Components
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Unlock();

			if (!locked)
			{
				anim.SetBool("open", true);
				src.PlayOneShot(clips[1]);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && !locked)
		{
			if (!locked)
			{
				anim.SetBool("open", false);
				src.PlayOneShot(clips[2]);
			}
		}
	}

	// Unlocks gate
	public abstract void Unlock();
}