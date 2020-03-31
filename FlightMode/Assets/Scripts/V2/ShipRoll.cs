using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRoll : MonoBehaviour {
	public float rollAmt;
	public float rollMultip;
	public GameObject player;
	GunshipMode gsm;
	ShipMovement sm;

	private void Start() {
		gsm = player.GetComponent<GunshipMode>();
		sm = player.GetComponent<ShipMovement>();
	}

	void Update() {
		if (!gsm.inGunshipMode) {
			rollAmt = sm.Xcoord + rollMultip;
			transform.localEulerAngles = new Vector3(0, 0, -rollAmt);
		}
	}
}
