using System.Collections;
using UnityEngine;

public abstract class Chest : MonoBehaviour
{
	// Komponente
	private Animator anim;
	private AudioSource src;

	// Igrac
	protected GameObject player;
	[SerializeField] 
	protected Inventory playerInventory;
	private GameObject clue;
	private bool inRange;

	// Otvaranje kovcega
	[SerializeField]
	private AudioClip clip;
	public bool open;

	void Awake()
	{
		GetComponents();
	}

	void Start()
	{
		inRange = false;
		player = GameObject.FindGameObjectWithTag("Player");
		clue = player.transform.GetChild(0).gameObject;
		if (open) anim.SetTrigger("open2");
	}

	void Update()
	{
		if (!open) Open(); else anim.SetTrigger("open2");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && !open)
		{
			inRange = true;
			clue.SetActive(true);
			clue.GetComponent<Animator>().SetTrigger("question");
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && !open)
		{
			clue.SetActive(false);
			inRange = false;
		}
	}

	// Uzima komponente
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
	}

	// Otvara 
	private void Open()
	{
		if (Input.GetKeyDown(KeyCode.E) && inRange)
		{
			anim.SetTrigger("open");
			src.PlayOneShot(clip);
			open = true;
			GiveItems();
		}
	}

	// Daje predmete
	virtual protected void GiveItems()
	{
		clue.SetActive(false);
		player.GetComponent<Animator>().SetTrigger("item");
	}

	// Write text
	protected IEnumerator Write(string line, GameObject obj)
	{
		DialogManager.Manager.SetActive(true, false, false);
		yield return StartCoroutine(DialogManager.Manager.CWriteLine(line));
		DialogManager.Manager.ResetText();
		Destroy(obj);
	}
}
