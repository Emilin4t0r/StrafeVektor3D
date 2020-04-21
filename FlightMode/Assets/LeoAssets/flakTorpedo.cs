using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flakTorpedo : MonoBehaviour {
	public float torque;
	public GameObject particle;
	public Rigidbody rb;
	public float damageMultip; // multiplier of damage done
	public float explosionRadius;
	float timer;
	float counter;
	GameObject ship;
	ShipManager sm;

	private void Start() {
		rb = transform.GetComponent<Rigidbody>();
		ship = GameObject.Find("Ship");
		sm = ship.transform.GetComponent<ShipManager>();
	}

	private void Update() {
		transform.Rotate(torque, 0, torque);
		if (timer <= 0 || timer >= 100 /*to avoid false timer values*/) {
			rb = transform.GetComponent<Rigidbody>();
			timer = (Vector3.Distance(transform.position, GameObject.Find("AALeadPoint").transform.position) / rb.velocity.magnitude) + Random.Range(-0.3f, 0.3f);
		}

		if (counter >= timer) {
			Explode();
		} else {
			counter += Time.deltaTime;
		}
		Destroy(gameObject, 10);
	}
	private void OnCollisionEnter(Collision collision) {
		Explode();
	}

	void Explode() {
		Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
		float hitDist = Vector3.Distance(ship.transform.position, transform.position);
		if (hitDist <= explosionRadius) {
			float damage = (explosionRadius - hitDist) * damageMultip;
			sm.TakeDamage(damage);
		}
		Destroy(gameObject);
	}
}
