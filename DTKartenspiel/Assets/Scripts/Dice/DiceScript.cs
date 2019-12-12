﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;
	public GameObject start;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		diceVelocity = rb.velocity;

		if (Input.GetKeyDown (KeyCode.Space)) {
			DiceNumberTextScript.diceNumber = 0;
			float dirX = Random.Range (0, 500);
			float dirY = Random.Range (0, 500);
			float dirZ = Random.Range (0, 500);
			transform.position = start.transform.position;
			transform.rotation = start.transform.rotation;
			transform.rotation = Quaternion.identity;
			rb.AddForce (transform.up * Random.Range (50, 700));
			rb.AddTorque (dirX, dirY, dirZ);
		}
	}
}