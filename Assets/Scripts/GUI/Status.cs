using UnityEngine;

public class Status : MonoBehaviour
{
	[SerializeField]
	private GameObject status;

	private Animator anim;

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
		anim = status.GetComponent<Animator>();
	}

	void Update()
	{
		if (electric.value || heal.value || orange.value || lemon.value)
		{
			status.SetActive(true);
			ChangeStatus();
		}
		else
			status.SetActive(false);
	}

	private void ChangeStatus()
	{
		anim.SetBool("electric", electric.value);
		anim.SetBool("heal", heal.value);
		anim.SetBool("orange", orange.value);
		anim.SetBool("lemon", lemon.value);
	}
}
