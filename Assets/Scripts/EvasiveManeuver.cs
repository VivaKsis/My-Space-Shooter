using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour
{
	public Done_Boundary boundary;
	public float tilt;
	public float dodge;
	public float smoothing;
	public float moveSpeed;

	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	public Rigidbody enemyRigidbody;

	private float targetManeuver;
	private float currentSpeed;

	private bool mustTurn = false;

	void Start ()
	{
		currentSpeed = moveSpeed;
		enemyRigidbody.velocity = transform.forward * currentSpeed;
		StartCoroutine(Evade());
	}
	
	IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true)
		{
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}
	
	void FixedUpdate ()
	{
		if (!mustTurn)
        {
			Move();
		}
        else if (mustTurn == true)
        {
			TurnAround();
		}
	}

	private void Move()
    {
		float newManeuver = Mathf.MoveTowards(enemyRigidbody.velocity.x, targetManeuver, smoothing * Time.deltaTime);
		enemyRigidbody.velocity = new Vector3(newManeuver, 0, currentSpeed);
		enemyRigidbody.position = new Vector3
		(
			Mathf.Clamp(enemyRigidbody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(enemyRigidbody.position.z, boundary.zMin, boundary.zMax)
		);
		Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 0, enemyRigidbody.velocity.x * -tilt) * Time.deltaTime);
		enemyRigidbody.MoveRotation(enemyRigidbody.rotation * deltaRotation);
	}

	public void Stop ()
    {
		StopCoroutine(Evade());
		currentSpeed = 0;
		enemyRigidbody.rotation = Quaternion.identity;
		enemyRigidbody.velocity = transform.forward * currentSpeed;
		mustTurn = true;
	}

	private void TurnAround ()
    {
		Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 100, 0) * Time.deltaTime);
		enemyRigidbody.MoveRotation(enemyRigidbody.rotation * deltaRotation);
		if ((enemyRigidbody.rotation.y >= 1) || (enemyRigidbody.rotation.y <= -1))
		{
			mustTurn = false;
			currentSpeed = -moveSpeed;
			enemyRigidbody.velocity = transform.forward * currentSpeed;
			StartCoroutine(Evade());
		}
    }

}
