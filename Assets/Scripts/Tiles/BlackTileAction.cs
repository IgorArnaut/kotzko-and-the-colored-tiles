using UnityEngine;
using UnityEngine.Tilemaps;

public class BlackTileAction : TileAction
{
	// Komponente
	private Tilemap tilemap;

	// Igrac
	[SerializeField]
	private Stats playerStats;

	// Crna boja
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

	// Uzima komponente
	private void GetComponents()
	{
		tilemap = GetComponent<Tilemap>();
	}

	// Proverava da li su polja crna
	private bool IsBlack()
	{
		foreach (Vector3Int tilePos in tilemap.cellBounds.allPositionsWithin) if (tilemap.GetAnimationFrame(tilePos) == 0) return true;
		return false;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && black) playerStats.TakeDamge(playerStats.HP);
	}

	// Radi nesto u koliziji
	override protected void DoEnterAction()
	{
		if (black) playerStats.HP = 0;
	}

	// Radi nesto van kolizije
	override protected void DoExitAction()
	{
		return;
	}
}
