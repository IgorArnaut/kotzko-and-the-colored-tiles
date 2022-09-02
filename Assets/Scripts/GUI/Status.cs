using UnityEngine;

public class Status : MonoBehaviour
{
	// Components
	private Animator anim;

	// Status
	[SerializeField]
	private GameObject status;
	[SerializeField]
	private BoolValue electric;
	[SerializeField]
	private BoolValue heal;
	[SerializeField]
	private BoolValue orange;
	[SerializeField]
	private BoolValue lemon;

	void Awake()
	{
		GetComponents();
	}

	void Update()
	{
		if (electric.value || heal.value || orange.value || lemon.value)
		{
			status.SetActive(true);
			ChangeStatus();
		}
		else status.SetActive(false);
	}

	// Get Components
	private void GetComponents()
	{
		anim = status.GetComponent<Animator>();
	}

	// Status
	private void ChangeStatus()
	{
		anim.SetBool("electric", electric.value);
		anim.SetBool("heal", heal.value);
		anim.SetBool("orange", orange.value);
		anim.SetBool("lemon", lemon.value);
	}
}
