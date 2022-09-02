using UnityEngine;

public class Terminal : MonoBehaviour
{
	// Components
	private Animator anim;
	private AudioSource src;

	// Context clue
	private GameObject clue;
	private bool inRange;

	// Write text
	[SerializeField]
	private AudioClip[] clips;
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
		DialogManager.Manager.StopWriting();
	}

	// Get Components
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
	}

	// Start dialog
	private void StartDialog()
	{
		if (inRange && Input.GetKeyDown(KeyCode.Z)) DialogManager.Manager.WriteLines(lines);
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

			DialogManager.Manager.textBox.SetActive(false);
			foreach (GameObject key in DialogManager.Manager.keyboard) key.SetActive(false);
		}
	}
}
