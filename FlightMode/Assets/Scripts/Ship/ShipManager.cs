using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour {
	public int health;

	public void TakeDamage(int damage) {
		health -= damage;
		//print("Player took " + damage + " damage, HP now " + health);
	}

	private void OnGUI() {
		GUI.Label(new Rect(10, 50, 100, 40), "Health: " + health);
	}
}
