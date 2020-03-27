using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshipCamera : MonoBehaviour {

	public GameObject aim;
	public GameObject cube;
	public Camera gunCam;
	public float range;


	// Start is called before the first frame update
	void Start() {
		gunCam = transform.GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update() {
		Vector3 v3 = Input.mousePosition;
		v3.z = 50.0f;
		v3 = gunCam.ScreenToWorldPoint(v3);
		aim.transform.position = v3;

		RaycastHit hit;
		Vector3 fwd = aim.transform.position - transform.position;
		Debug.DrawRay(transform.position, fwd * range, Color.red, 0.01f);
		if (Physics.Raycast(transform.position, fwd, out hit, range) && hit.transform.CompareTag("Ground")) {
			cube.transform.position = hit.point;
		}

		//transform.LookAt(cube.transform.position);
	}
}
