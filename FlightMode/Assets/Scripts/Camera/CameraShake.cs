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
	GunshipMode gsm;
	Controls controls;
	int oldShots;

	private void Start() {
		cannon = playerGun.GetComponent<Cannon>();
		ship = GameObject.Find("Ship").GetComponent<ShipMovement>();
		gsm = GameObject.Find("Ship").GetComponent<GunshipMode>();
		controls = FindObjectOfType<Controls>();
	}

	void Update() {

		if (cannon.cannontype == Cannon.CannonType.Semi) {
			if (controls.Fire("down") && !cannon.reloading && oldShots < cannon.shotsFired) {
				oldShots = cannon.shotsFired;
				cameraShake = cannon.cameraShakeAmt;
			} else if (controls.Boost("hold")) {
				cameraShake = ship.turboCamShake;
			}
			if (cannon.shotsFired == 0) {
				oldShots = 0;
			}
			if (cameraShake > 0) {
				if (gsm.inGunshipMode) {
					transform.localPosition = Random.insideUnitSphere * (cameraShake / 2);
				} else {
					transform.localPosition = Random.insideUnitSphere * cameraShake;
				}
				if (counter > shakeDuration) {
					counter = 0;
					cameraShake = 0;
				} else {
					counter += Time.deltaTime;
				}
			} else {
				transform.localPosition = new Vector3(0, 0, 0);
			}

		} else if (cannon.cannontype == Cannon.CannonType.Shotgun) {
			if (controls.Fire("down") && !cannon.reloading) {
				cameraShake = cannon.cameraShakeAmt;
			} else if (controls.Boost("hold")) {
				cameraShake = ship.turboCamShake;
			}
			if (cameraShake > 0) {
				if (gsm.inGunshipMode) {
					transform.localPosition = Random.insideUnitSphere * (cameraShake / 2);
				} else {
					transform.localPosition = Random.insideUnitSphere * cameraShake;
				}
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
			if (controls.Fire("down") && !cannon.reloading) {
				cameraShake = cannon.cameraShakeAmt;
			} else if (controls.Boost("hold")) {
				cameraShake = ship.turboCamShake;
			} else {
				cameraShake = 0;
			}

			if (cameraShake > 0) {
				if (gsm.inGunshipMode) {
					transform.localPosition = Random.insideUnitSphere * (cameraShake / 2);
				} else {
					transform.localPosition = Random.insideUnitSphere * cameraShake;
				}
			} else {
				transform.localPosition = new Vector3(0, 0, 0);
			}
		}
	}
}
