using UnityEngine;

public class Terminal : MonoBehaviour
{
	// Komponente
	private Animator anim;
	private AudioSource src;

	// Blizina
	private GameObject clue;
	private bool inRange;
	[SerializeField]
	private AudioClip[] clips;

	// Tekst
	[SerializeField] 
	private string[] lines;

	void Awake()
	{
		GetComponents();
	}

	void Start()
	{
		clue = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
	}

	void Update()
	{
		StartDialog();
		DialogManager.Manager.CancelWriting();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			inRange = true;
			anim.SetBool("inRange", true);
			src.PlayOneShot(clips[0]);
			clue.SetActive(true);
			clue.GetComponent<Animator>().SetTrigger("ellipsis");
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			inRange = false;
			anim.SetBool("inRange", false);
			src.PlayOneShot(clips[1]);
			clue.SetActive(false);
			DialogManager.Manager.SetActive(false, false, false);
		}
	}

	// Uzima komponente
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
	}

	// Pokrece dijalog
	private void StartDialog()
	{
		if (inRange && Input.GetKeyDown(KeyCode.E))
		{
			DialogManager.Manager.SetActive(true, true, true);
			DialogManager.Manager.WriteLines(lines);
		}
	}
}
