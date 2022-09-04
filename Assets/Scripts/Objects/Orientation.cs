using UnityEngine;

[ExecuteAlways]
public class Orientation : MonoBehaviour
{
	// Komponente
	private Animator anim;

	// Pravci
	[SerializeField] 
	private float directionX;
	[SerializeField]
	private float directionY;

	void Awake()
	{
		GetComponents();
	}

	void Start()
	{
		ChangeDirection();
    }

	// Uzima komponente
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
	}

	// Menja smer i pravac kapije
	private void ChangeDirection()
	{
		if (directionX == 1) transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
		if (directionX == -1) transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
		anim.SetFloat("directionX", directionX);
		anim.SetFloat("directionY", directionY);
	}
}
