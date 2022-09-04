using UnityEngine;

public class Portal : MonoBehaviour
{
	// Igrac
	private GameObject player;
	private GameObject clue;

	// Tranzicija
	[SerializeField]
	private AudioClip clip;
	public bool stepped;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		clue = player.transform.GetChild(0).gameObject;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			clue.SetActive(true);
			clue.GetComponent<Animator>().SetTrigger("exclamation");
			player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			SaveLoadManager.Manager.SaveData();
			Invoke(nameof(LoadScene), 1.0f);
		}
	}

	// Pokreni scenu
	private void LoadScene()
	{
		clue.SetActive(false);
		MusicManager.Manager.Stop();
		MusicManager.Manager.PlayOneshot(clip);
		SceneManager2.Manager.Transition("Boss");
	}
}
