using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	public GameObject playerGun;
	float cameraShake;
	float shakeDuration = 0.1f;
	float counter;
	Cannon cannon;
	ShipMovement ship;
	int oldShots;

	private void Start() {
		cannon = playerGun.GetComponent<Cannon>();
		ship = GameObject.Find("Ship").GetComponent<ShipMovement>();
	}

	void Update() {

		if (cannon.cannontype == Cannon.CannonType.CnnSemi) {
			if (Input.GetKeyDown(KeyCode.Mouse0) && !cannon.reloading && oldShots < cannon.shotsFired) {
				oldShots = cannon.shotsFired;
				cameraShake = cannon.cameraShakeAmt;
			} else if (Input.GetKey(KeyCode.LeftControl)) {
				cameraShake = ship.turboCamShake;
			}
			if (cannon.shotsFired == 0) {
				oldShots = 0;
			}
			if (cameraShake > 0) {
				transform.localPosition = Random.insideUnitSphere * cameraShake;
				if (counter > shakeDuration) {
					counter = 0;
					cameraShake = 0;
				} else {
					counter += Time.deltaTime;
				}
			} else {
				transform.localPosition = new Vector3(0, 0, 0);
			}

		} else {
			if (Input.GetKey(KeyCode.Mouse0) && !cannon.reloading) {
				cameraShake = cannon.cameraShakeAmt;
			} else if (Input.GetKey(KeyCode.LeftControl)) {
				cameraShake = ship.turboCamShake;
			} else {
				cameraShake = 0;
			}

			if (cameraShake > 0) {
				transform.localPosition = Random.insideUnitSphere * cameraShake;
			} else {
				transform.localPosition = new Vector3(0, 0, 0);
			}
		}
	}
}
