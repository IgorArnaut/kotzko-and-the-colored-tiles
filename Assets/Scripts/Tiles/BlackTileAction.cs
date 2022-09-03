using UnityEngine;
using UnityEngine.Tilemaps;

public class BlackTileAction : TileAction
{
	// Components
	private Tilemap tilemap;

	// Player
	[SerializeField]
	private Stats playerStats;

	// Black
	public bool black; 

	void Awake()
	{
		GetComponents();
	}

	void Start()
	{
		black = true;
	}

	void Update()
	{
		black = IsBlack();	
	}

	// Gets Components
	private void GetComponents()
	{
		tilemap = GetComponent<Tilemap>();
	}

	// Checks if tile is black?
	private bool IsBlack()
	{
		foreach (Vector3Int tilePos in tilemap.cellBounds.allPositionsWithin) if (tilemap.GetAnimationFrame(tilePos) == 0) return true;
		return false;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && black) playerStats.TakeDamge(playerStats.HP);
	}

	override protected void DoEnterAction()
	{
		if (black) playerStats.HP = 0;
	}

	override protected void DoExitAction()
	{
		return;
	}
}
