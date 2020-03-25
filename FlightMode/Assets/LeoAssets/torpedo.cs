using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torpedo : MonoBehaviour {
	public Rigidbody rb;
	public float torque;
	public GameObject particle;
	public bool flak;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	private void Update() {
		transform.Rotate(torque, 0, torque);
		if (flak) {
			if (Vector3.Distance(transform.position, GameObject.Find("Ship").transform.position) < 30) {
				Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
				Destroy(gameObject);
			}

		}
		Destroy(gameObject, 10);
	}
	private void OnCollisionEnter(Collision collision) {
		Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
		Destroy(gameObject);
	}
}
