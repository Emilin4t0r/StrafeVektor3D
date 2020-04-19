using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
	public float moveSpeed;
	public float accelerationSpeed = 2;
	public float maxSpeedF;
	public float maxSpeedB;
	public float turboSpeed;
	public float turboCamShake;
	public Rigidbody rb;
	GunshipMode gsm;

	float turboAccSpd;
	float normalMaxSpeedF; // Store normal speed & acceleration values
	float normalAccSpd;

	private int[] center = new int[2];
	private float blockX;
	private float mouseX;
	private float blockY;
	private float mouseY;
	public float Xcoord;
	public float Ycoord;

	void Start() {
		center[0] = Screen.width / 2;
		center[1] = Screen.height / 2;

		turboAccSpd = accelerationSpeed - accelerationSpeed / 2;
		normalMaxSpeedF = maxSpeedF; // Store normal speed & acceleration values
		normalAccSpd = accelerationSpeed;

		gsm = transform.GetComponent<GunshipMode>();
	}

	void Update() {

		blockX = Screen.width / 100f;
		mouseX = Input.mousePosition.x - center[0];
		Xcoord = mouseX / blockX;
		blockY = Screen.height / 100f;
		mouseY = Input.mousePosition.y - center[1];
		Ycoord = mouseY / blockY;

		float x = transform.eulerAngles.x;                  // \
		float y = transform.eulerAngles.y;                  // 	> Set Z rotation to 0
		transform.localEulerAngles = new Vector3(x, y, 0);  // /

		if (!gsm.inGunshipMode || !gsm.isActiveAndEnabled) {
			RotateShipX();
			RotateShipY();
		}

		//Acceleration for moving forward/backward
		float moveTowards;
		if (!gsm.inGunshipMode) {
			moveTowards = 0;
		} else {
			moveTowards = 50;
		}

		float changeRatePerSecond = 1 / accelerationSpeed * Time.deltaTime;

		if (Input.GetKey(KeyCode.S) && !gsm.inGunshipMode) {
			moveTowards = -maxSpeedB;
		} else
		if (Input.GetKey(KeyCode.W)) {
			moveTowards = maxSpeedF;
		}
		changeRatePerSecond *= 50;
		moveSpeed = Mathf.MoveTowards(moveSpeed, moveTowards, changeRatePerSecond);

		//Turbo

		if (Input.GetKey(KeyCode.LeftControl)) {
			maxSpeedF = turboSpeed;
			accelerationSpeed = turboAccSpd;
		} else {
			maxSpeedF = normalMaxSpeedF;
			accelerationSpeed = normalAccSpd;
		}

		transform.Translate(0, 0, moveSpeed * Time.deltaTime);

		if (rb.velocity.magnitude < .01) {
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
	}

	void RotateShipX() {
		transform.Rotate(Vector3.up * (Xcoord * Time.deltaTime) * 1.5f);
	}
	void RotateShipY() {
		float angle = transform.localEulerAngles.x;
		angle = (angle > 180) ? angle - 360 : angle;
		if (angle > -82f && Ycoord >= 0)
			transform.Rotate(Vector3.left * (Ycoord * Time.deltaTime) * 1.5f);
		if (angle < 82f && Ycoord <= 0)
			transform.Rotate(Vector3.left * (Ycoord * Time.deltaTime) * 1.5f);
	}

	private void OnGUI() {
		GUI.Label(new Rect(10, 10, 400, 40), "PRE-ALPHA BUILD");
		GUI.Label(new Rect(10, 70, 100, 20), "Speed: " + moveSpeed);
		GUI.Label(new Rect(10, 90, 200, 20), "X = " + Xcoord);
		GUI.Label(new Rect(10, 110, 200, 20), "Y = " + Ycoord);
	}
}
