﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
	public GameObject torpedo;
	public GameObject gun;
	public GameObject crosshairs;
	public GameObject baseCrosshairPos;
	public float castRange;
	public float origCastRange;
	LayerMask layerMask;
	Controls controls;

	public float counter;
	public bool reloading;
	private float counter2;
	public int shotsFired;

	public float fireRate;
	public float accuracy;
	public float reload;
	public int magazine;
	public float cameraShakeAmt;
	public float damageMultiplier;
	public float explosionRadius;
	public int shotsInShotgun;

	public float thrust;

	public enum CannonType { Semi, Burst, Auto, Shotgun };
	public CannonType cannontype;

	void Start() {
		if (cannontype == CannonType.Burst) {
			fireRate = 0.05f;
			accuracy = 0.01f;
			reload = 0.5f;
			magazine = 3;
			cameraShakeAmt = 0.2f;
			damageMultiplier = 1.25f;
			explosionRadius = 15f;
		} else if (cannontype == CannonType.Semi) {
			fireRate = 0.25f;
			accuracy = 0.005f;
			reload = 1f;
			magazine = 8;
			cameraShakeAmt = 0.4f;
			damageMultiplier = 1.5f;
			explosionRadius = 20;
		} else if (cannontype == CannonType.Auto) {
			fireRate = 0.03f;
			accuracy = 0.03f;
			reload = 3f;
			magazine = 45;
			cameraShakeAmt = 0.3f;
			damageMultiplier = 1;
			explosionRadius = 10;
		} else if (cannontype == CannonType.Shotgun) {
			fireRate = 0.05f;
			accuracy = 0.06f;
			reload = 1f;
			cameraShakeAmt = 1f;
			damageMultiplier = 1;
			explosionRadius = 15f;
			shotsInShotgun = 10;
			magazine = 2;
		}
		layerMask = LayerMask.GetMask("Default");
		controls = FindObjectOfType<Controls>();
	}

	void Update() {

		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, fwd * 100, Color.green, 0.1f);
		if (Physics.Raycast(transform.position, fwd, out hit, castRange, layerMask)) {
			crosshairs.transform.position = hit.point;
			crosshairs.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
		} else {
			crosshairs.transform.position = baseCrosshairPos.transform.position;
			crosshairs.transform.localEulerAngles = new Vector3(0, 0, 0);
		}

		if (shotsFired >= magazine)
			reloading = true;

		if (!reloading) {
			if (counter > fireRate) {
				if (cannontype == CannonType.Semi) {
					if (controls.Fire("down")) {
						Shoot();
					}
				} else if (cannontype == CannonType.Shotgun) {
					if (controls.Fire("down")) {
						ShootShotgun(shotsInShotgun);
					}
				} else {
					if (controls.Fire("hold")) {
						Shoot();
					}
				}
			} else {
				counter += Time.deltaTime;
			}
		} else {
			if (counter2 >= reload) {
				counter2 = 0;
				shotsFired = 0;
				reloading = false;
			} else {
				counter2 += Time.deltaTime;
			}
		}
	}

	private void OnGUI() {
		GUI.Label(new Rect(10, 130, 100, 20), "Shots Left: " + (magazine - shotsFired));
	}

	void Shoot() {

		Vector3 deviation3D = Random.insideUnitCircle * accuracy;
		Quaternion rot = Quaternion.LookRotation(Vector3.forward + deviation3D);
		Vector3 fwd = transform.rotation * rot * Vector3.forward;

		GameObject torp = Instantiate(torpedo, gun.transform.position, gun.transform.rotation);
		Rigidbody tRb = torp.GetComponent<Rigidbody>();
		tRb.AddForce(fwd * thrust, ForceMode.Impulse);

		shotsFired++;
		counter = 0;
	}

	void ShootShotgun(int shots) {
		for (int i = 0; i < shots; i++) {
			Vector3 deviation3D = Random.insideUnitCircle * accuracy;
			Quaternion rot = Quaternion.LookRotation(Vector3.forward + deviation3D);
			Vector3 fwd = transform.rotation * rot * Vector3.forward;

			GameObject torp = Instantiate(torpedo, gun.transform.position, gun.transform.rotation);
			Rigidbody tRb = torp.GetComponent<Rigidbody>();
			tRb.AddForce(fwd * thrust, ForceMode.Impulse);
		}
		shotsFired++;
		counter = 0;
	}
}
