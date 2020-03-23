using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStrafe : MonoBehaviour {
	public float moveSpeed;
	public float accelerationSpeed = 2;
	public float maxSpeed;

	public GameObject playerShip;
	void Start() {

	}

	void Update() {
		float moveTowards = 0;
		float changeRatePerSecond = 1 / accelerationSpeed * Time.deltaTime;

		if (Input.GetKey(KeyCode.A)) {
			moveTowards = -maxSpeed;
		} else
		if (Input.GetKey(KeyCode.D)) {
			moveTowards = maxSpeed;
		}
		changeRatePerSecond *= 50;
		moveSpeed = Mathf.MoveTowards(moveSpeed, moveTowards, changeRatePerSecond);

		transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

		playerShip.GetComponent<ShipRoll>().rollMultip = -moveSpeed;
	}
}
