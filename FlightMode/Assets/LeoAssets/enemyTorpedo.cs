using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTorpedo : MonoBehaviour {
	public float torque;
	public GameObject particle;
	public int damage;
	ShipManager sm;

	private void Update() {
		transform.Rotate(torque, 0, torque);
		Destroy(gameObject, 10);
	}

	private void OnCollisionEnter(Collision collision) {
		Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
		if (collision.transform.CompareTag("Player")) {
			sm = collision.transform.GetComponent<ShipManager>();
			sm.TakeDamage(damage);
		}
		Destroy(gameObject);
	}
}
