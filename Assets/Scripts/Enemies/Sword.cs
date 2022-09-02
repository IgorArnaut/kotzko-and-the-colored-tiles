using UnityEngine;

public class Sword : MonoBehaviour
{
	// Components
	private AudioSource src;

	// Damage Player
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

	// Get Components
	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Collision
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			player = collision.gameObject;
			DamagePlayer();
		}
	}

	// Damage Player
	private void DamagePlayer()
	{
		if (!playerStats.IsDead() && player != null)
		{
			if (!defend.value) player.GetComponent<Animator>().SetTrigger("hurt");
			else src.PlayOneShot(clip);
			playerStats.TakeDamge(10);
			Destroy(gameObject);
		}
	}
}
