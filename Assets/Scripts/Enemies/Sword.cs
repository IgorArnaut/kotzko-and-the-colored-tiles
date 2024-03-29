using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
	// Komponente
	private AudioSource src;

	// Povredjivanje igraca
	[SerializeField]
	private AudioClip clip;
	private GameObject player;
	[SerializeField]
	private Stats playerStats;
	[SerializeField]
	private BoolValue defend;

	void Awake()
	{
		GetComponents();
	}

	void Start()
	{
		StartCoroutine(nameof(Live));
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			player = collision.gameObject;
			DamagePlayer();
		}
	}

	// Uzima komponente
	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Povredjuje igraca
	private void DamagePlayer()
	{
		if (!playerStats.IsDead() && player != null)
		{
			if (!defend.value) player.GetComponent<Animator>().SetTrigger("hurt"); else src.PlayOneShot(clip);
			playerStats.TakeDamge(5);
			Destroy(gameObject);
		}
	}

	// Zivi
	private IEnumerator Live()
	{
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
}
