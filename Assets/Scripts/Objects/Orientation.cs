using UnityEngine;

[ExecuteAlways]
public class Orientation : MonoBehaviour
{
	[SerializeField] 
	private float directionX;
	[SerializeField]
	private float directionY;
	[SerializeField]
	private bool flip;

	private Animator anim;

    void Awake()
    {
		anim = GetComponent<Animator>();
	}

	void Start()
	{
		anim.SetFloat("directionX", directionX);
		anim.SetFloat("directionY", directionY);

		if (flip && directionX == 1)
			transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

		if (flip && directionX == -1)
			transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
}
