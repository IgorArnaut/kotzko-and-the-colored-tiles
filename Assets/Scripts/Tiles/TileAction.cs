using System.Collections;
using UnityEngine;

public abstract class TileAction : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
			DoEnterAction();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
			DoExitAction();
	}

	protected abstract void DoEnterAction();

	protected abstract void DoExitAction();
 }