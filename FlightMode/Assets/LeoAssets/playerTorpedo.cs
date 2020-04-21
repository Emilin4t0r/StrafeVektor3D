using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTorpedo : MonoBehaviour {
	public float torque;
	public GameObject particle;
	TurretAI tAI;
	GameObject enemy;
	Cannon cannon;

	public float damageMultip;
	public float explosionRadius;

	private void Start() {
		cannon = GameObject.Find("PAC-Howitzer").GetComponent<Cannon>();
		damageMultip = cannon.damageMultiplier;
		explosionRadius = cannon.explosionRadius;
	}

	private void OnCollisionEnter(Collision collision) {
		GameObject explosion = Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);

		Collider[] colliders = Physics.OverlapSphere(explosion.transform.position, explosionRadius);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject.transform.CompareTag("Enemy")) { // Find a random enemy within the radius
				enemy = colliders[i].gameObject;
			}
		}
		if (enemy != null) {
			tAI = enemy.transform.GetChild(0).GetComponent<TurretAI>();
			float hitDist = Vector3.Distance(enemy.transform.position, transform.position);
			if (hitDist <= explosionRadius) {
				float damage = (explosionRadius - hitDist) * damageMultip;
				tAI.TakeDamage(Mathf.RoundToInt(damage));
			}
		}
		Destroy(gameObject);
	}
}

