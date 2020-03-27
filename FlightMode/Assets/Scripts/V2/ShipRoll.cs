using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRoll : MonoBehaviour {
	public float rollAmt;
	public float rollMultip;
	public GameObject player;
	ShipMovement sm;

	private void Start() {
		sm = player.GetComponent<ShipMovement>();
	}

	void Update() {
		if (!sm.inGunshipMode) {
			rollAmt = sm.Xcoord + rollMultip;
			transform.localEulerAngles = new Vector3(0, 0, -rollAmt);
		}
	}
}
