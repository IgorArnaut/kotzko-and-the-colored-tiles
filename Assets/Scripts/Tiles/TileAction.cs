using UnityEngine;

public abstract class TileAction : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) DoEnterAction();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) DoExitAction();
	}

	// Radi nesto u koliziji
	protected abstract void DoEnterAction();

	// Radi nesto van kolizije
	protected abstract void DoExitAction();
 }