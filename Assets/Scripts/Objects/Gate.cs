using UnityEngine;

public abstract class Gate : MonoBehaviour
{
	// Komponente
	private Animator anim;
	protected AudioSource src;

	// Otkljucavanje
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

	// Uzima komponente
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
	}

	// Otkljucava kapiju
	public abstract void Unlock();
}