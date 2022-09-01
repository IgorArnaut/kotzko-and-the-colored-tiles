using UnityEngine;

public abstract class Gate : MonoBehaviour
{
	private Animator anim;

	[SerializeField]
	protected AudioClip[] clips;
	public bool locked;

	void Awake()
	{
		anim = GetComponent<Animator>();

	}

	void Start()
	{
		locked = true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Unlock();

			if (!locked)
			{
				anim.SetBool("open", true);
				GetComponent<AudioSource>().PlayOneShot(clips[1]);
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
				GetComponent<AudioSource>().PlayOneShot(clips[2]);
			}
		}
	}

	public abstract void Unlock();
}