﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
	public GameObject torpedo;
	public GameObject gun;
	public GameObject crosshairs;
	public GameObject baseCrosshairPos;
	public float castRange;

	public float counter;
	public bool reloading;
	private float counter2;
	public int shotsFired;

	public float fireRate;
	public float accuracy;
	public float reload;
	public int magazine;
	public float cameraShakeAmt;

	public float thrust;

	public enum CannonType { CnnSemi, CnnBurst, CnnAuto, };
	public CannonType cannontype;

	void Start() {
		if (cannontype == CannonType.CnnBurst) {
			fireRate = 0.05f;
			accuracy = 0.01f;
			reload = 0.5f;
			magazine = 3;
			cameraShakeAmt = 0.2f;
		} else if (cannontype == CannonType.CnnSemi) {
			fireRate = 0.25f;
			accuracy = 0.005f;
			reload = 1f;
			magazine = 8;
			cameraShakeAmt = 0.4f;
		} else if (cannontype == CannonType.CnnAuto) {
			fireRate = 0.02f;
			accuracy = 0.025f;
			reload = 3f;
			magazine = 30;
			cameraShakeAmt = 0.3f;
		}
	}

	void Update() {

		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, fwd * 100, Color.green, 1f);
		if (Physics.Raycast(transform.position, fwd, out hit, castRange) && !hit.transform.CompareTag("Torpedo")) {
			crosshairs.transform.position = hit.point;
		} else {
			crosshairs.transform.position = baseCrosshairPos.transform.position;
		}

		if (shotsFired >= magazine)
			reloading = true;

		if (!reloading) {
			if (counter > fireRate) {
				if (cannontype == CannonType.CnnSemi) {
					if (Input.GetKeyDown(KeyCode.Mouse0)) {
						Shoot();
					}
				} else {
					if (Input.GetKey(KeyCode.Mouse0)) {
						Shoot();
					}
				}
			} else {
				counter += Time.deltaTime;
			}
		} else {
			if (counter2 > reload) {
				counter2 = 0;
				shotsFired = 0;
				reloading = false;
			} else {
				counter2 += Time.deltaTime;
			}
		}
	}

	private void OnGUI() {
		GUI.Label(new Rect(10, 70, 100, 20), "Shots Left: " + (magazine - shotsFired));
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

}