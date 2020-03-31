using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torpedo : MonoBehaviour {
	public float torque;
	public GameObject particle;
	public bool flak;
	public Rigidbody rb;
	float timer;
	float counter;

	private void Start() {
		if (flak) {
			rb = transform.GetComponent<Rigidbody>();
		}
	}

	private void Update() {
		transform.Rotate(torque, 0, torque);
		if (flak && (timer <= 0 || timer >= Mathf.Infinity)) {
			rb = transform.GetComponent<Rigidbody>();
			timer = Vector3.Distance(transform.position, GameObject.Find("AALeadPoint").transform.position) / rb.velocity.magnitude;
		}
		if (flak) {
			if (counter >= timer) {
				Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
				Destroy(gameObject);
			} else {
				counter += Time.deltaTime;
			}
		}
		Destroy(gameObject, 10);
	}
	private void OnCollisionEnter(Collision collision) {
		Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
		Destroy(gameObject);
	}
}
