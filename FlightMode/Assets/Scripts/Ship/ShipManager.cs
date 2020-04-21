using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour {
	int health;

	ShipArmor armor;

	void Start() {
		armor = transform.GetComponent<ShipArmor>();
		health = armor.strength;
	}

	public void TakeDamage(float damage) {
		int intdamage = Mathf.RoundToInt(damage / armor.damageResistance);
		health -= intdamage;
		//print("Player took " + damage + " damage, HP now " + health);
	}

	private void OnGUI() {
		GUI.Label(new Rect(10, 50, 100, 40), "Health: " + health);
	}
}
