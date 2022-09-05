using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSummon : StateMachineBehaviour
{
	// Komponente
	private Animator anim;
	private AudioSource src;
	private Boss boss;
	private CapsuleCollider2D cc2D;
	private Rigidbody2D rb2D;
	private SpriteRenderer sr;

	// Spawnovanje maceva
	[SerializeField]
	private AudioClip clip;
	[SerializeField] 
	private GameObject sword;
	private Vector2 center;
	private List<GameObject> swords; 
	private bool finished;

	// Statistika
	private Stats stats;
	private int temp;

	// Bacanje maceva
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

	// Uzima komponente
	private void GetComponents(Animator animator)
	{
		anim = animator;
		src = anim.gameObject.GetComponent<AudioSource>();
		boss = anim.gameObject.GetComponent<Boss>();
		cc2D = anim.gameObject.GetComponent<CapsuleCollider2D>();
		rb2D = anim.gameObject.GetComponent<Rigidbody2D>();
		sr = anim.gameObject.GetComponent<SpriteRenderer>();
	}

	// Inicira neke vrednosti
	private void Init()
	{
		center = cc2D.bounds.center;
		rb2D.bodyType = RigidbodyType2D.Static;
		sr.flipX = false;
		stats = anim.gameObject.GetComponent<Enemy>().stats;
		temp = stats.DEF;
		stats.DEF *= 2;
		swords = new(8);
	}

	// Baca maceve
	private void ThrowSwords()
	{
		foreach (GameObject sword in swords)
		{
			float angle = (360.0f / 8.0f) * swords.IndexOf(sword);
			Vector2 tPos;
			tPos.x = center.x + 10.0f * Mathf.Sin(angle * Mathf.Deg2Rad);
			tPos.y = center.y + 10.0f * Mathf.Cos(angle * Mathf.Deg2Rad);
			if (sword != null) sword.transform.SetPositionAndRotation(Vector2.Lerp(sword.transform.position, tPos, Time.deltaTime * 10.0f), Quaternion.Euler(Vector3.back * angle));
		}
	}

	// Unistava maceve
	private void DestroySwords()
	{
		swords.Clear();
		stats.DEF = temp;
		rb2D.bodyType = RigidbodyType2D.Kinematic;
	}

	// Spawnuje maceve
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
			yield return new WaitForSeconds(0.05f);
		}

		src.PlayOneShot(clip);
		finished = true;
	}
}
