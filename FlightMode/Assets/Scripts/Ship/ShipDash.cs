﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDash : MonoBehaviour {

	float doubleTapTimer;
	bool useTapTimerLeft;
	bool useTapTimerRight;
	bool dashUsed;
	float counter;
	public float doubleTapTime;
	public float dashForce;
	ShipStrafe ss;
	GunshipMode gsm;
	Controls controls;

	private void Start() {
		ss = transform.GetComponent<ShipStrafe>();
		gsm = transform.GetComponent<GunshipMode>();
		controls = FindObjectOfType<Controls>();
	}

	void Update() {

		if (!gsm.inGunshipMode) {
			DashRight();
			DashLeft();
		}

	}

	#region Dash_Functions
	void DashLeft() {
		if (useTapTimerLeft) {
			if (doubleTapTimer <= doubleTapTime && controls.Left("down") && !dashUsed) { // Second tap
				ss.Dash(-dashForce);
				dashUsed = true;
				useTapTimerLeft = false;
				doubleTapTimer = 0;
			} else if (doubleTapTimer > 0.5f) { // No tap after first one
				useTapTimerLeft = false;
				doubleTapTimer = 0;
			} else {
				doubleTapTimer += Time.deltaTime;
			}
		}

		if (controls.Left("down") && !useTapTimerLeft) { // First tap
			useTapTimerLeft = true;
		}

		if (dashUsed) { // Cooldown after dashing
			if (counter >= 3) {
				dashUsed = false;
				counter = 0;
			} else {
				counter += Time.deltaTime;
			}
		}
	}

	void DashRight() {
		if (useTapTimerRight) {
			if (doubleTapTimer <= doubleTapTime && controls.Right("down") && !dashUsed) { // Second tap
				ss.Dash(dashForce);
				dashUsed = true;
				useTapTimerRight = false;
				doubleTapTimer = 0;
			} else if (doubleTapTimer > 0.5f) { // No tap after first one
				useTapTimerRight = false;
				doubleTapTimer = 0;
			} else {
				doubleTapTimer += Time.deltaTime;
			}
		}

		if (controls.Right("down") && !useTapTimerRight) { // First tap
			useTapTimerRight = true;
		}

		if (dashUsed) { // Cooldown after dashing
			if (counter >= 3) {
				dashUsed = false;
				counter = 0;
			} else {
				counter += Time.deltaTime;
			}
		}
	}
	#endregion
}
