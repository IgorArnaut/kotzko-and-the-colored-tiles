using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
	private Animator anim;
	private AudioSource src;

	private GameObject clue;
	private bool inRange;
	[SerializeField]
	private AudioClip[] clips;

	[SerializeField] 
	private string[] lines;

	void Awake()
	{
		anim = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
	}

	void Start()
	{
		clue = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
	}

	void Update()
	{
		StartDialog();
	}

	private void StartDialog()
	{
		if (inRange && Input.GetKeyDown(KeyCode.E))
			DialogManager.Manager.Write(new Queue<string>(lines));
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			inRange = true;

			src.PlayOneShot(clips[0]);
			anim.SetBool("inRange", true);
			clue.SetActive(true);
			clue.GetComponent<Animator>().SetTrigger("ellipsis");
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			inRange = false;

			src.PlayOneShot(clips[1]);
			anim.SetBool("inRange", false);
			clue.SetActive(false);
			DialogManager.Manager.textBox.SetActive(false);
		}
	}
}
