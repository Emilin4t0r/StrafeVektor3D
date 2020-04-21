using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStrafe : MonoBehaviour {
	public float moveSpeed;
	public float accelerationSpeed = 2;
	public float origAccSpeed;
	public float GunshipAccelerationSpeed;
	public float maxSpeed;
	public float origMaxSpeed;
	public float gunshipTurnSpeed;
	public GameObject playerShip;
	Controls controls;

	float dashCounter;
	public bool dashing;

	void Start() {
		origAccSpeed = accelerationSpeed;
		controls = FindObjectOfType<Controls>();
	}

	void Update() {
		float moveTowards = 0;
		float changeRatePerSecond = 1 / accelerationSpeed * Time.deltaTime;

		if (controls.Left("hold")) {
			moveTowards = -maxSpeed;
		} else
		if (controls.Right("hold")) {
			moveTowards = maxSpeed;
		}

		if (dashing) {
			if (dashCounter > 0.5f) {
				dashing = false;
				dashCounter = 0;
			} else {
				dashCounter += Time.deltaTime;
			}
		}

		changeRatePerSecond *= 50;
		if (!dashing)
			moveSpeed = Mathf.MoveTowards(moveSpeed, moveTowards, changeRatePerSecond);
		transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

		playerShip.GetComponent<ShipRoll>().rollMultip = -moveSpeed;
	}

	public void Dash(float force) {
		dashing = true;
		moveSpeed = force;
	}
}
