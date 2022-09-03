using UnityEngine;

public class Status : MonoBehaviour
{
	// Components
	[SerializeField]
	private Animator anim;

	// Status
	[SerializeField]
	private BoolValue electric;
	[SerializeField]
	private BoolValue heal;
	[SerializeField]
	private BoolValue orange;
	[SerializeField]
	private BoolValue lemon;

	void Update()
	{
		if (electric.value || heal.value || orange.value || lemon.value)
		{
			anim.gameObject.SetActive(true);
			ChangeStatus();
		}
		else anim.gameObject.SetActive(false);
	}

	// Changes status effect
	private void ChangeStatus()
	{
		anim.SetBool("electric", electric.value);
		anim.SetBool("heal", heal.value);
		anim.SetBool("orange", orange.value);
		anim.SetBool("lemon", lemon.value);
	}
}
