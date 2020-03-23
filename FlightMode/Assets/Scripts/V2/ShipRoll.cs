using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRoll : MonoBehaviour {
	public float rollAmt;
	public float rollMultip;
	public GameObject player;

	void Update() {

		rollAmt = player.GetComponent<ShipMovement>().Xcoord + rollMultip;
		transform.localEulerAngles = new Vector3(0, 0, -rollAmt);
	}
}
