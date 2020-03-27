using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStrafe : MonoBehaviour {
	public float moveSpeed;
	public float accelerationSpeed = 2;
	float maxSpeed;
	public float origMaxSpeed;
	public float gunshipTurnSpeed;
	ShipMovement sm;
	public GameObject playerShip;

	void Start() {
		sm = GameObject.Find("Ship").GetComponent<ShipMovement>();
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

		if (sm.inGunshipMode) {
			transform.Rotate(0, moveSpeed * Time.deltaTime, 0);
			maxSpeed = gunshipTurnSpeed;
		} else {
			transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
			maxSpeed = origMaxSpeed;
		}

		playerShip.GetComponent<ShipRoll>().rollMultip = -moveSpeed;
	}
}
