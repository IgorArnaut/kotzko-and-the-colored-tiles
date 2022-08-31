using UnityEngine;
using UnityEngine.Tilemaps;

public class BlackTileAction : TileAction
{
	[SerializeField]
	private Stats playerStats;

	private bool black; 
	private Tilemap tilemap;

	void Awake()
	{
		tilemap = GetComponent<Tilemap>();
	}

	void Start()
	{
		black = true;
	}

	void Update()
	{
		black = IsBlack();	
	}

	private bool IsBlack()
	{
		foreach (Vector3Int tilePos in tilemap.cellBounds.allPositionsWithin)
		{
			if (tilemap.GetAnimationFrame(tilePos) == 0)
				return true;
		}

		return false;
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
