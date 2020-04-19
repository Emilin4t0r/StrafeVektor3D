using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHover : MonoBehaviour {
	public float moveSpeed;
	public float accelerationSpeed = 2;
	public float maxSpeed;

	void Start() {

	}

	void Update() {
		float moveTowards = 0;
		float changeRatePerSecond = 1 / accelerationSpeed * Time.deltaTime;

		if (Input.GetKey(KeyCode.Space)) {
			moveTowards = maxSpeed;
		} else
		if (Input.GetKey(KeyCode.LeftShift)) {
			moveTowards = -maxSpeed;
		}
		changeRatePerSecond *= 50;
		moveSpeed = Mathf.MoveTowards(moveSpeed, moveTowards, changeRatePerSecond);

		transform.Translate(0, moveSpeed * Time.deltaTime, 0);
	}
}
