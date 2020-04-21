using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	[SerializeField]
	KeyCode left_;
	[SerializeField]
	KeyCode right_;
	[SerializeField]
	KeyCode forward_;
	[SerializeField]
	KeyCode back_;
	[SerializeField]
	KeyCode up_;
	[SerializeField]
	KeyCode down_;
	[SerializeField]
	KeyCode fire_;
	[SerializeField]
	KeyCode boost_;
	[SerializeField]
	KeyCode toggleMode_;

	Controls controls;

	private void Start() {
		controls = FindObjectOfType<Controls>();
	}

	bool GetKey(KeyCode key) {
		if (Input.GetKey(key))
			return true;
		else
			return false;
	}
	bool GetKeyUp(KeyCode key) {
		if (Input.GetKeyUp(key))
			return true;
		else
			return false;
	}
	bool GetKeyDown(KeyCode key) {
		if (Input.GetKeyDown(key))
			return true;
		else
			return false;
	}

	#region keycode methods
	public bool Left(string input) {
		switch (input) {
			case "hold":
				return GetKey(left_);
			case "up":
				return GetKeyUp(left_);
			case "down":
				return GetKeyDown(left_);
			default:
				return false;
		}
	}

	public bool Right(string input) {
		switch (input) {
			case "hold":
				return GetKey(right_);
			case "up":
				return GetKeyUp(right_);
			case "down":
				return GetKeyDown(right_);
			default:
				return false;
		}
	}

	public bool Forward(string input) {
		switch (input) {
			case "hold":
				return GetKey(forward_);
			case "up":
				return GetKeyUp(forward_);
			case "down":
				return GetKeyDown(forward_);
			default:
				return false;
		}
	}

	public bool Back(string input) {
		switch (input) {
			case "hold":
				return GetKey(back_);
			case "up":
				return GetKeyUp(back_);
			case "down":
				return GetKeyDown(back_);
			default:
				return false;
		}
	}

	public bool Up(string input) {
		switch (input) {
			case "hold":
				return GetKey(up_);
			case "up":
				return GetKeyUp(up_);
			case "down":
				return GetKeyDown(up_);
			default:
				return false;
		}
	}

	public bool Down(string input) {
		switch (input) {
			case "hold":
				return GetKey(down_);
			case "up":
				return GetKeyUp(down_);
			case "down":
				return GetKeyDown(down_);
			default:
				return false;
		}
	}

	public bool Fire(string input) {
		switch (input) {
			case "hold":
				return GetKey(fire_);
			case "up":
				return GetKeyUp(fire_);
			case "down":
				return GetKeyDown(fire_);
			default:
				return false;
		}
	}

	public bool Boost(string input) {
		switch (input) {
			case "hold":
				return GetKey(boost_);
			case "up":
				return GetKeyUp(boost_);
			case "down":
				return GetKeyDown(boost_);
			default:
				return false;
		}
	}

	public bool ToggleMode(string input) {
		switch (input) {
			case "hold":
				return GetKey(toggleMode_);
			case "up":
				return GetKeyUp(toggleMode_);
			case "down":
				return GetKeyDown(toggleMode_);
			default:
				return false;
		}
	}
	#endregion
}
