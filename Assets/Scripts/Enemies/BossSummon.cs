using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSummon : StateMachineBehaviour
{
	// Components
	private Animator anim;
	private AudioSource src;
	private Boss boss;
	private CapsuleCollider2D cc2D;
	private SpriteRenderer sr;

	// Spawn swords
	[SerializeField]
	private AudioClip clip;
	[SerializeField] 
	private GameObject sword;
	private List<GameObject> swords; 
	private bool finished;

	// Throw swords
	[SerializeField]
	private float speed;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GetComponents(animator);
		Init();
		boss.StartCoroutine(SpawnSwords());
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (finished) ThrowSwords();
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		DestroySwords();
	}

	// Get Components
	private void GetComponents(Animator animator)
	{
		anim = animator;
		src = anim.gameObject.GetComponent<AudioSource>();
		boss = anim.gameObject.GetComponent<Boss>();
		cc2D = anim.gameObject.GetComponent<CapsuleCollider2D>();
		sr = anim.gameObject.GetComponent<SpriteRenderer>();
	}

	// Initialize
	private void Init()
	{
		sr.flipX = false;
		swords = new(8);
	}

	// Throw swords
	private void ThrowSwords()
	{
		foreach (GameObject sword in swords)
		{
			float angle = (360.0f / 8.0f) * swords.IndexOf(sword);
			Vector2 tPos;
			tPos.x = cc2D.bounds.center.x + 10.0f * Mathf.Sin(angle * Mathf.Deg2Rad);
			tPos.y = cc2D.bounds.center.y + 10.0f * Mathf.Cos(angle * Mathf.Deg2Rad);
			if (sword != null) sword.transform.SetPositionAndRotation(Vector2.Lerp(sword.transform.position, tPos, Time.deltaTime * 10.0f), Quaternion.Euler(0.0f, 0.0f, Time.deltaTime));
		}
	}

	// Destroy swords
	private void DestroySwords()
	{
		foreach (GameObject sword in swords) Destroy(sword);
		swords.Clear();
	}

	// Spawn swords
	private IEnumerator SpawnSwords()
	{
		finished = false;

		for (int i = 0; i < 8; i++)
		{
			float angle = (360.0f / 8.0f) * i;
			Vector2 swordPos;
			swordPos.x = cc2D.bounds.center.x + 1.5f * Mathf.Sin(angle * Mathf.Deg2Rad);
			swordPos.y = cc2D.bounds.center.y + 1.5f * Mathf.Cos(angle * Mathf.Deg2Rad);
			swords.Add(Instantiate(sword, swordPos, Quaternion.Euler(Vector3.back * angle)));
			yield return new WaitForSeconds(0.1f);
		}

		src.PlayOneShot(clip);
		finished = true;
	}
}
