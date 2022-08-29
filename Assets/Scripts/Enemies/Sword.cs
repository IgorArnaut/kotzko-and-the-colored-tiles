using UnityEngine;

public class Sword : MonoBehaviour
{
	[SerializeField]
	private Stats playerStats;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.GetComponent<Animator>().SetTrigger("hurt");
			playerStats.TakeDamge(5);
			Destroy(gameObject);
		}
	}
}
