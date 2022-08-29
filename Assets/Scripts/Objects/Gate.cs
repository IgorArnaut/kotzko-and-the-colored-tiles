using UnityEngine;

public abstract class Gate : MonoBehaviour
{
	private Animator anim;

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
			if (!locked)
				anim.SetBool("open", true);
			
			Unlock();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && !locked)
		{
			if (!locked)
				anim.SetBool("open", false);
		}
	}

	public abstract void Unlock();
}