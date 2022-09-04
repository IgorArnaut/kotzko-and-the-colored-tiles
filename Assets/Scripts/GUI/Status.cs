using UnityEngine;

public class Status : MonoBehaviour
{
	// Komponente
	[SerializeField]
	private Animator anim;

	// Status efekti
	[SerializeField]
	private BoolValue electric;
	[SerializeField]
	private BoolValue heal;
	[SerializeField]
	private BoolValue orange;
	[SerializeField]
	private BoolValue purple;

	void Update()
	{
		if (electric.value || heal.value || orange.value || purple.value)
		{
			anim.gameObject.SetActive(true);
			ChangeIcon();
		}
		else anim.gameObject.SetActive(false);
	}

	// Menja ikonicu
	private void ChangeIcon()
	{
		anim.SetBool("electric", electric.value);
		anim.SetBool("heal", heal.value);
		anim.SetBool("orange", orange.value);
		anim.SetBool("lemon", purple.value);
	}
}
