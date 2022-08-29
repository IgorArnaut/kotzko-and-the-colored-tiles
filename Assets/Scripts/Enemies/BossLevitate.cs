using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevitate : StateMachineBehaviour
{
	private CapsuleCollider2D cc;
	
	private Boss b;

	[SerializeField] 
	private GameObject sword;
	private List<GameObject> swords; 

	[SerializeField]
	private float speed;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		b = animator.gameObject.GetComponent<Boss>();
		cc = animator.gameObject.GetComponent<CapsuleCollider2D>();

		animator.gameObject.GetComponent<SpriteRenderer>().flipX = false;
		
		swords = new(8);
		b.StartCoroutine(SpawnSwords());
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MoveSwords();
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		DestroySwords();
	}

	private void MoveSwords()
	{
		foreach (GameObject sword in swords)
		{
			float angle = (360.0f / 8.0f) * swords.IndexOf(sword);

			Vector2 tPos;
			tPos.x = cc.bounds.center.x + 10.0f * Mathf.Sin(angle * Mathf.Deg2Rad);
			tPos.y = cc.bounds.center.y + 10.0f * Mathf.Cos(angle * Mathf.Deg2Rad);

			if (sword != null)
				sword.transform.position = Vector2.Lerp(sword.transform.position, tPos, Time.deltaTime * 5.0f);
		}
	}

	private void DestroySwords()
	{
		foreach (GameObject sword in swords)
			Destroy(sword);

		swords.Clear();
	}

	private IEnumerator SpawnSwords()
	{
		for (int i = 0; i < 8; i++)
		{
			float angle = (360.0f / 8.0f) * i;

			Vector2 swordPos;
			swordPos.x = cc.bounds.center.x + 1.5f * Mathf.Sin(angle * Mathf.Deg2Rad);
			swordPos.y = cc.bounds.center.y + 1.5f * Mathf.Cos(angle * Mathf.Deg2Rad);

			swords.Add(Instantiate(sword, swordPos, Quaternion.Euler(Vector3.back * angle)));
			yield return new WaitForSeconds(0.0f);
		}
	}
}
