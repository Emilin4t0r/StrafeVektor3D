using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	public GameObject playerShip;
	float cameraShake;
	float shakeDuration = 0.1f;
	float counter;
	Cannon cannon;
	int oldShots;

	private void Start() {
		cannon = playerShip.GetComponent<Cannon>();
	}

	void Update() {

		if (cannon.cannontype == Cannon.CannonType.CnnSemi) {
			if (Input.GetKeyDown(KeyCode.Mouse0) && !cannon.reloading && oldShots < cannon.shotsFired) {
				oldShots = cannon.shotsFired;
				cameraShake = cannon.cameraShakeAmt;
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
