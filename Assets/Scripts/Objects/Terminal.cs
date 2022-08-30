using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
	private Animator anim;

	private GameObject clue;

	[SerializeField] 
	private List<string> lines;
	private bool inRange;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void Start()
	{
		clue = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
	}

	// Update is called once per frame
	void Update()
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
