using UnityEngine;
using UnityEngine.Tilemaps;

public class BlackTileAction : TileAction
{
	[SerializeField]
	private Stats playerStats;
	
	private bool black = true;
	private Tilemap tilemap;

	void Awake()
	{
		tilemap = GetComponent<Tilemap>();
	}

	void Update()
	{
		if (tilemap.GetAnimationFrame(new Vector3Int(8, 29, 0)) == 1)
			black = false;
		else
			black = true;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && black)
			playerStats.TakeDamge(playerStats.HP);
	}

	override protected void DoEnterAction()
	{
		if (black)
			playerStats.TakeDamge(playerStats.HP);
	}

	override protected void DoExitAction()
	{
		return;
	}
}
