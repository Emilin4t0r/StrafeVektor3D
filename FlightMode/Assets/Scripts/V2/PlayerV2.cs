using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV2 : MonoBehaviour {

	private int[] center = new int[2];
	private float blockX;
	private float mouseX;
	private float blockY;
	private float mouseY;
	public float Xcoord;
	public float Ycoord;

	public float turnSpeed;

	void Start() {
		Debug.Log(Screen.width);
		Debug.Log(Screen.height);
		center[0] = Screen.width / 2;
		center[1] = Screen.height / 2;
		Debug.Log(center[0]);
		Debug.Log(center[1]);
	}

	void Update() {
		blockX = Screen.width / 100f;
		mouseX = Input.mousePosition.x - center[0];
		Xcoord = mouseX / blockX;
		blockY = Screen.height / 100f;
		mouseY = Input.mousePosition.y - center[1];
		Ycoord = mouseY / blockY;

		RotateShipX();
		RotateShipY();

		float x = transform.eulerAngles.x;                  // \
		float y = transform.eulerAngles.y;                  // 	> Set Z rotation to 0
		transform.localEulerAngles = new Vector3(x, y, 0);  // /
	}

	void RotateShipX() {
		transform.Rotate(Vector3.up * (Xcoord * Time.deltaTime));
	}
	void RotateShipY() {
		transform.Rotate(Vector3.left * (Ycoord * Time.deltaTime));
	}

	private void OnGUI() {
		GUI.Label(new Rect(10, 10, 200, 20), "X = " + Xcoord);
		GUI.Label(new Rect(10, 30, 200, 20), "Y = " + Ycoord);
	}
}
