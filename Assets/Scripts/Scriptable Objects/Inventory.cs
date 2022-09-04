using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
	// Predmeti
	public int GEMS;
	public int HEARTS;
	public int KEYS;
	public int BOSSKEY;

	// Dodaje dragulje
	public void AddGEMS(int amount)
	{
		GEMS += amount;
	}

	// Dodaje srca
	public void AddHearts(int amount)
	{
		HEARTS += amount;
	}

	// Oduzima srca
	public void RemovesHEARTS(int amount)
	{
		HEARTS -= amount;
	}

	// Dodaje kljuc
	public void AddKEY()
	{
		KEYS++;
	}

	// Oduzima kljuc
	public void RemoveKEY()
	{
		if (KEYS > 0) KEYS--;
	}

	// Dodaje Boss kljuc
	public void AddBOSSKEY()
	{
		if (BOSSKEY < 1) BOSSKEY++;
	}

	// Oduzima Boss kljuc
	public void RemoveBOSSKEY()
	{
		if (BOSSKEY > 0) BOSSKEY--;
	}

	// Resetuje sve predmete
	public void ResetInventory()
	{
		GEMS = 0;
		HEARTS = 0;
		KEYS = 0;
		BOSSKEY = 0;
	}
}