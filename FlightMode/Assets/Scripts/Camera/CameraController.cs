﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3f;
	private float origSmoothTime;
	private Vector3 velocity = Vector3.zero;
	Controls controls;

	void Start() {
		origSmoothTime = smoothTime;
		controls = FindObjectOfType<Controls>();
	}


	void Update() {
		transform.rotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);

		// Define a target position above and behind the target transform
		Vector3 targetPosition = target.TransformPoint(new Vector3(0, 4f, -75));

		// Smoothly move the camera towards that target position
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

		if (controls.Back("hold")) {
			smoothTime = 0.1f;
		}
		if (controls.Back("up")) {
			smoothTime = origSmoothTime;
		}
	}
}
