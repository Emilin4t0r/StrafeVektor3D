using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AALeadPoint : MonoBehaviour {

	ShipMovement shipM;
	ShipStrafe shipS;
	ShipHover shipH;

	void Start() {
		shipM = GameObject.Find("Ship").GetComponent<ShipMovement>();
		shipS = GameObject.Find("Ship").GetComponent<ShipStrafe>();
		shipH = GameObject.Find("Ship").GetComponent<ShipHover>();
	}

	void Update() {
		transform.localPosition = new Vector3(shipS.moveSpeed, shipH.moveSpeed, shipM.moveSpeed + 4);
	}
}
