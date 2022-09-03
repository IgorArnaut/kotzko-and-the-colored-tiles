using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
	// Gems, hearts, keys, bosskey
	public int GEMS;
	public int HEARTS;
	public int KEYS;
	public int BOSSKEY;

	// Adds gems
	public void AddGEMS(int amount)
	{
		GEMS += amount;
	}

	// Adds hearts
	public void AddHearts(int amount)
	{
		HEARTS += amount;
	}

	// Removes hearts
	public void RemovesHEARTS(int amount)
	{
		HEARTS -= amount;
	}

	// Adds a key
	public void AddKEY()
	{
		KEYS++;
	}

	// Removes a key
	public void RemoveKEY()
	{
		if (KEYS > 0) KEYS--;
	}

	// Adds a boss key
	public void AddBOSSKEY()
	{
		if (BOSSKEY < 1) BOSSKEY++;
	}

	// Removes a boss key
	public void RemoveBOSSKEY()
	{
		if (BOSSKEY > 0) BOSSKEY--;
	}

	// Resets all items
	public void ResetInventory()
	{
		GEMS = 0;
		HEARTS = 0;
		KEYS = 0;
		BOSSKEY = 0;
	}
}