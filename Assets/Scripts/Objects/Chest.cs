using UnityEngine;

public abstract class Chest : MonoBehaviour
{
	private Animator anim;

	private GameObject player;
	private GameObject clue;

	[SerializeField] 
	protected Inventory playerInventory;

	private bool inRange;
	public bool open;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		clue = player.transform.GetChild(0).gameObject;

		inRange = false;
		open = false;
	}

	void Update()
	{
		Open();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && !open)
		{
			inRange = true;
			clue.SetActive(true);
			clue.GetComponent<Animator>().SetInteger("clue", 2);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && !open)
		{
			inRange = false;
			clue.SetActive(false);
			clue.GetComponent<Animator>().SetInteger("clue", 0);
		}
	}

	private void Open()
	{
		if (Input.GetKeyDown(KeyCode.E) && inRange && !open)
		{
			open = true;
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
}
