using UnityEngine;

public abstract class Gate : MonoBehaviour
{
	private Animator anim;

	private bool inRange;

	public bool locked;

	void Awake()
	{
		anim = GetComponent<Animator>();
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
				anim.SetBool("open", true);
			else
				anim.SetBool("open", false);
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