using System.Collections;
using UnityEngine;

public abstract class Chest : MonoBehaviour
{
	private Animator anim;

	protected GameObject player;
	[SerializeField] 
	protected Inventory playerInventory;

	private GameObject clue;
	private bool inRange;

	public bool open;
	[SerializeField]
	protected AudioClip[] clips;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		clue = player.transform.GetChild(0).gameObject;

		inRange = false;

		if (open)
			anim.SetTrigger("open2");
	}

	void Update()
	{
		if (!open)
			Open();

		if (open)
			anim.SetTrigger("open2");
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

	private void Open()
	{
		if (Input.GetKeyDown(KeyCode.E) && inRange)
		{
			open = true;
			GetComponent<AudioSource>().PlayOneShot(clips[0]);
			anim.SetTrigger("open");
			GiveItems();
			PlayerItem();
		}
	}

	public void PlayerItem()
	{
		clue.SetActive(false);
		clue.GetComponent<Animator>().SetInteger("clue", 0);
		player.GetComponent<Animator>().SetTrigger("item");
	}

	public abstract void GiveItems();

	protected IEnumerator Write(string line, GameObject obj)
	{
		DialogManager.Manager.textBox.SetActive(true);
		DialogManager.Manager.dialogText.text = "";

		foreach (char c in line)
		{
			DialogManager.Manager.dialogText.text += c;
			GetComponent<AudioSource>().PlayOneShot(clips[1]);
			yield return new WaitForSeconds(0.05f);
		}

		yield return new WaitForSeconds(1.0f);
		Destroy(obj);
		DialogManager.Manager.textBox.SetActive(false);
	}
}
