using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshipMode : MonoBehaviour {
	public bool inGunshipMode;
	public GameObject mainCam;
	public GameObject gunshipCam;
	public GameObject cannon;
	public GameObject gunRotator;
	public GameObject cnnTarget;
	public GameObject playerShip;
	ShipStrafe strf;

	void Start() {
		strf = transform.GetComponent<ShipStrafe>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.E) && inGunshipMode == false) {
			inGunshipMode = true;
			gunshipCam.SetActive(true);
			mainCam.SetActive(false);
			float y = transform.eulerAngles.y;
			transform.eulerAngles = new Vector3(0, y, 0);
			float px = playerShip.transform.eulerAngles.x;
			float py = playerShip.transform.eulerAngles.y;
			playerShip.transform.eulerAngles = new Vector3(px, py, 0);
			cannon.GetComponent<Cannon>().castRange = 10000;

		} else if (Input.GetKeyDown(KeyCode.E) && inGunshipMode == true) {
			inGunshipMode = false;
			gunshipCam.SetActive(false);
			mainCam.SetActive(true);
			cannon.GetComponent<Cannon>().castRange = cannon.GetComponent<Cannon>().origCastRange;
		}

		if (inGunshipMode) {
			transform.Rotate(0, strf.moveSpeed * Time.deltaTime, 0);
			strf.maxSpeed = strf.gunshipTurnSpeed;
			strf.accelerationSpeed = strf.GunshipAccelerationSpeed;

			gunRotator.transform.LookAt(cnnTarget.transform.position);
			float cnnY = gunRotator.transform.localEulerAngles.y;
			gunRotator.transform.localEulerAngles = new Vector3(0, cnnY, 0); // Only turn cannon turret Y-axis

			cannon.transform.LookAt(cnnTarget.transform.position);
			float cnnX = cannon.transform.eulerAngles.x;
			cannon.transform.localEulerAngles = new Vector3(cnnX, 0, 0); // Only turn cannon X-axis

		} else {
			strf.maxSpeed = strf.origMaxSpeed;
			strf.accelerationSpeed = strf.origAccSpeed;

			cannon.transform.localEulerAngles = new Vector3(5, 0, 0);
			gunRotator.transform.localEulerAngles = new Vector3(0, 0, 0);
		}
	}
}
