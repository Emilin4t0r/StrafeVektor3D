using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHover : MonoBehaviour {
	public float moveSpeed;
	public float accelerationSpeed = 2;
	public float maxSpeed;
	Controls controls;

	void Start() {
		controls = FindObjectOfType<Controls>();
	}

	void Update() {
		float moveTowards = 0;
		float changeRatePerSecond = 1 / accelerationSpeed * Time.deltaTime;

		if (controls.Up("hold")) {
			moveTowards = maxSpeed;
		} else
		if (controls.Down("hold")) {
			moveTowards = -maxSpeed;
		}
		changeRatePerSecond *= 50;
		moveSpeed = Mathf.MoveTowards(moveSpeed, moveTowards, changeRatePerSecond);

		transform.Translate(0, moveSpeed * Time.deltaTime, 0);
	}
}
