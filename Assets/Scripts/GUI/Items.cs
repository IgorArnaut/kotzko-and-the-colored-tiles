using TMPro;
using UnityEngine;

public class Items : MonoBehaviour
{
	// Inventar
	[SerializeField]
	private Inventory playerInventory;
	[SerializeField]
	private GameObject[] items;

    void Update()
    {
		ChangeValue(playerInventory.GEMS, items[0]);
		ChangeValue(playerInventory.HEARTS, items[1]);
		ChangeValue(playerInventory.KEYS, items[2]);
		ChangeValue(playerInventory.BOSSKEY, items[3]);

	}

	// Menja kolicine predmeta
	private void ChangeValue(int value, GameObject item)
	{
		if (value > 0) item.SetActive(true); else item.SetActive(false);
		item.GetComponentInChildren<TextMeshProUGUI>().text = "" + value;
	}
}
