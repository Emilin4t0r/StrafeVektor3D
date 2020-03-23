using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torpedo : MonoBehaviour {
	public Rigidbody rb;
	public float torque;
	public GameObject particle;

	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	private void Update() {
		transform.Rotate(torque, 0, torque);
	}
	private void OnCollisionEnter(Collision collision) {
		Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
		Destroy(gameObject);
	}



}
