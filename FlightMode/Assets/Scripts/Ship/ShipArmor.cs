using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipArmor : MonoBehaviour {

	public enum Armor { None, Light, Medium, Heavy };
	public Armor armor;

	public float damageResistance; // affects incoming damage
	public int strength; // maximum ship hitpoints
	public float armorWeight; // affects acceleration

	void Start() {
		if (armor == Armor.None) {
			strength = 200;
			damageResistance = 1;
			armorWeight = 1;
		} else if (armor == Armor.Light) {
			strength = 225;
			damageResistance = 1.25f; // +25% protection
			armorWeight = 1.25f; // -25% acceleration
		} else if (armor == Armor.Medium) {
			strength = 250;
			damageResistance = 1.5f; // +50% protection
			armorWeight = 1.5f; // -50% acceleration
		} else if (armor == Armor.Heavy) {
			strength = 300;
			damageResistance = 2; // +100% protection
			armorWeight = 2; // -100% acceleration
		}
	}

	void Update() {

	}
}
