using UnityEngine;

public class Status : MonoBehaviour
{
	[SerializeField]
	private BoolValue electric;
	[SerializeField]
	private BoolValue heal;
	[SerializeField]
	private BoolValue orange;
	[SerializeField]
	private BoolValue lemon;

	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		anim.SetBool("electric", electric.value);
		anim.SetBool("heal", heal.value);
		anim.SetBool("orange", orange.value);
		anim.SetBool("lemon", lemon.value);
	}
}
