using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
	private Animator anim;

	private GameObject clue;
	private bool inRange;

	[SerializeField] 
	private string[] lines;

	void Awake()
	{
		anim = GetComponent<Animator>();
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
			DialogManager.dManager.Write(new Queue<string>(lines));
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			inRange = true;

			anim.SetBool("inRange", true);
			clue.SetActive(true);
			clue.GetComponent<Animator>().SetInteger("clue", 1);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			inRange = false;

			anim.SetBool("inRange", false);
			clue.SetActive(false);
			clue.GetComponent<Animator>().SetInteger("clue", 0);
			DialogManager.dManager.textBox.SetActive(false);
		}
	}
}
