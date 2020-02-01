using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;
	public GameObject start;
	public Vector3 originPosition;

	private bool firstTimeThrown;

	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		originPosition = transform.position;
		firstTimeThrown = true;
	}

	void Update () 
	{
		diceVelocity = rb.velocity;

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			float dirX = Random.Range (0, 500);
			float dirY = Random.Range (0, 500);
			float dirZ = Random.Range (0, 500);
			transform.position = start.transform.position;
			transform.rotation = start.transform.rotation;
			transform.rotation = Quaternion.identity;
			rb.AddForce (transform.up * Random.Range (50, 700));
			rb.AddTorque (dirX, dirY, dirZ);

			if (firstTimeThrown)
			{
				DiceCheckZoneScript.instance.firstTimeThrown = true;
				firstTimeThrown = false;
			}
		}
	}
}
