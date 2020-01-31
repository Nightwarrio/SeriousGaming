using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour {

	Vector3 diceVelocity;
	public int diceNumber;
	public static DiceCheckZoneScript instance;
	[HideInInspector] public bool firstTimeThrown;
	public GameObject dice;

	private void Start()
	{
		if (instance == null) instance = this;
		firstTimeThrown = false;
	}

	void FixedUpdate () {
		diceVelocity = DiceScript.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
		if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
		{
			switch (col.gameObject.name)
			{
				case "Side1":
					diceNumber = 6;
					break;
				case "Side2":
					diceNumber = 5;
					break;
				case "Side3":
					diceNumber = 4;
					break;
				case "Side4":
					diceNumber = 3;
					break;
				case "Side5":
					diceNumber = 2;
					break;
				case "Side6":
					diceNumber = 1;
					break;
			}

			if(firstTimeThrown && dice.transform.position.y <= 1.03) //Würfel ist gelandet
			{
				GameManager.instance.SelectStarterTeam();
				firstTimeThrown = false;
			}
		}
	}
}
