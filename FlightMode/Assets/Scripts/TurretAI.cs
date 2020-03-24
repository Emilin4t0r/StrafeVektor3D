using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {

	public GameObject bullet;
	public GameObject barrel;
	public GameObject ammoSpawn;
	public GameObject target;
	public GameObject player;
	public float accuracy;
	public float shootForce;
	public float range;
	public bool targetInSight;
	public float smallestTargetSpeed;

	float counter;
	public float fireRate;

	void Start() {
		target = GameObject.Find("AALeadPoint");
		player = GameObject.Find("Ship");
	}

	void Update() {

		transform.LookAt(target.transform, Vector3.forward);
		float y = transform.eulerAngles.y;
		transform.eulerAngles = new Vector3(0, y, 0);

		barrel.transform.LookAt(target.transform, Vector3.forward);
		float x = barrel.transform.eulerAngles.x;
		barrel.transform.eulerAngles = new Vector3(x, y, 0);

		RaycastHit hit;
		Vector3 fwd = barrel.transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, fwd * range, Color.red, 0.01f);
		if (Physics.Raycast(transform.position, fwd, out hit, range) && hit.transform.CompareTag("Player")) {
			targetInSight = true;
		} else {
			targetInSight = false;
		}

		if (player.GetComponent<ShipMovement>().moveSpeed > smallestTargetSpeed)
			shootForce = player.GetComponent<ShipMovement>().moveSpeed;
		if (counter >= fireRate && Vector3.Distance(transform.position, target.transform.position) < range && targetInSight) {
			Shoot();
			counter = 0;
		} else {
			counter += Time.deltaTime;
		}
	}

	void Shoot() {
		Vector3 deviation3D = Random.insideUnitCircle * accuracy;
		Quaternion rot = Quaternion.LookRotation(Vector3.forward + deviation3D);
		Vector3 fwd = barrel.transform.rotation * rot * Vector3.forward;
		GameObject torp = Instantiate(bullet, ammoSpawn.transform.position, ammoSpawn.transform.rotation);
		Rigidbody tRb = torp.GetComponent<Rigidbody>();
		tRb.AddForce(fwd * shootForce, ForceMode.Impulse);
	}
}