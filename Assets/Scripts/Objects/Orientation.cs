using UnityEngine;

[ExecuteAlways]
public class Orientation : MonoBehaviour
{
	// Components
	private Animator anim;

	// Directions
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
		anim.SetFloat("directionX", directionX);
		anim.SetFloat("directionY", directionY);
		if (directionX == 1) transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
		if (directionX == -1) transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

	// Get Components
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
	}
}
