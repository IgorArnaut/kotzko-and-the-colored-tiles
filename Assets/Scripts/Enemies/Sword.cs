using UnityEngine;

public class Sword : MonoBehaviour
{
	private AudioSource src;
	[SerializeField]
	private AudioClip clip;
	
	[SerializeField]
	private Stats playerStats;
	[SerializeField]
	private BoolValue defend;

	void Awake()
	{
		src = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && !playerStats.IsDead() && collision.gameObject != null)
		{
			if (!defend.value)
				collision.gameObject.GetComponent<Animator>().SetTrigger("hurt");
			else
				src.PlayOneShot(clip);

			playerStats.TakeDamge(10);
			Destroy(gameObject);
		}
	}
}
