using UnityEngine;

public class Sword : MonoBehaviour
{
	[SerializeField]
	private AudioClip clip;
	
	[SerializeField]
	private Stats playerStats;
	[SerializeField]
	private BoolValue defend;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && !playerStats.IsDead() && collision.gameObject != null)
		{
			if (!defend.value)
				collision.gameObject.GetComponent<Animator>().SetTrigger("hurt");
			else
				GetComponent<AudioSource>().PlayOneShot(clip);

			playerStats.TakeDamge(10);
			Destroy(gameObject);
		}
	}
}
