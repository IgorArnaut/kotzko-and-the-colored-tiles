using System.Collections;
using UnityEngine;

public abstract class Chest : MonoBehaviour
{
	// Components
	private Animator anim;
	private AudioSource src;

	// Player
	protected GameObject player;
	[SerializeField] 
	protected Inventory playerInventory;

	// Context clue
	private GameObject clue;
	private bool inRange;

	// Open chest
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

	// Get Components
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
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
			inRange = false;
			clue.SetActive(false);
		}
	}

	// Open chest
	private void Open()
	{
		if (Input.GetKeyDown(KeyCode.E) && inRange)
		{
			open = true;
			src.PlayOneShot(clip);
			anim.SetTrigger("open");
			GiveItems();
		}
	}

	protected void PlayerItem()
	{
		clue.SetActive(false);
		player.GetComponent<Animator>().SetTrigger("item");
	}

	// Give items
	public abstract void GiveItems();

	// Write text
	protected IEnumerator Write(string line, GameObject obj)
	{
		DialogManager.Manager.SetActive(true, false, false);
		DialogManager.Manager.WriteLine(line);
		Destroy(obj);
		yield return new WaitForSeconds(0.0f);
	}
}
