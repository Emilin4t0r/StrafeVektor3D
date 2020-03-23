using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
	public float moveSpeed;
	public float accelerationSpeed = 2;
	public float maxSpeedF;
	public float maxSpeedB;

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

		RotateShipX();
		RotateShipY();

		//Acceleration for moving forward/backward
		float moveTowards = 0;
		float changeRatePerSecond = 1 / accelerationSpeed * Time.deltaTime;

		if (Input.GetKey(KeyCode.S)) {
			moveTowards = -maxSpeedB;
		} else
		if (Input.GetKey(KeyCode.W)) {
			moveTowards = maxSpeedF;
		}
		changeRatePerSecond *= 50;
		moveSpeed = Mathf.MoveTowards(moveSpeed, moveTowards, changeRatePerSecond);

		transform.Translate(0, 0, moveSpeed * Time.deltaTime);
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
		GUI.Label(new Rect(10, 10, 100, 20), "Speed: " + moveSpeed);
		GUI.Label(new Rect(10, 30, 200, 20), "X = " + Xcoord);
		GUI.Label(new Rect(10, 50, 200, 20), "Y = " + Ycoord);
	}
}
