using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AALeadPoint : MonoBehaviour {

	ShipMovement ship;

	void Start() {
		ship = GameObject.Find("Ship").GetComponent<ShipMovement>();
	}

	void Update() {
		transform.localPosition = new Vector3(0, -1, ship.moveSpeed);
	}
}
