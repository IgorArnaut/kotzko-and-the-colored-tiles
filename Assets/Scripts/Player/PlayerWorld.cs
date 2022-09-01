using UnityEngine;

public class PlayerWorld : Player
{
	public BoolValue inWater;
	public BoolValue electric;
	public BoolValue heal;
	public BoolValue orange;
	public BoolValue lemon;

	void Update()
	{
		ChangeStatus();
		Move();
		Die();
	}

	override protected void Move()
	{
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");

		if (inputX == -1.0f || inputX == 1.0f || inputY == -1.0f || inputY == 1.0f)
		{
			anim.SetFloat("lastMoveX", inputX);
			anim.SetFloat("lastMoveY", inputY);
		}

		if (inputX == 1.0f) {
			sr.flipX = true;
			transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = true;
		}

		if (inputX == -1.0f) {
			sr.flipX = false;
			transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
		}

		if (rb.bodyType != RigidbodyType2D.Static)
			rb.velocity = new Vector2(inputX, inputY) * stats.SPEED;

		anim.SetFloat("horizontal", rb.velocity.x);
		anim.SetFloat("vertical", rb.velocity.y);
		anim.SetFloat("speed", rb.velocity.sqrMagnitude);
	}

	protected override void Die()
	{
		if (orange.value && inWater.value)
			anim.SetTrigger("deadw");

		if (stats.IsDead())
			anim.SetTrigger("dead");
	}

	private void ChangeStatus()
	{
		anim.SetBool("inWater", inWater.value);
		anim.SetBool("electric", electric.value);

		if (orange.value)
		{
			sr.color = Color.Lerp(Color.HSVToRGB(40.0f / 360.0f, 0.3f, 1.0f), Color.white, Mathf.PingPong(Time.time, 2.0f));

			if (inWater.value)
			{
				sr.color = Color.white;
				anim.SetTrigger("deadw");
			}
		}
		else if (lemon.value)
			sr.color = Color.Lerp(Color.HSVToRGB(60.0f / 360.0f, 0.3f, 1.0f), Color.white, Mathf.PingPong(Time.time, 2.0f));
		else if (heal.value)
			sr.color = Color.Lerp(Color.HSVToRGB(300.0f / 360.0f, 0.3f, 1.0f), Color.white, Mathf.PingPong(Time.time, 2.0f));
		else
			sr.color = Color.white;
	}
}
