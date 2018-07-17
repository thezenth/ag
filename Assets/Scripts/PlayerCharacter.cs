using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character {

	public PlayerCharacter(string name, float health, float base_damage, List<Item> items, Weapon primary_weapon = null)
		: base(name, health, base_damage, items, primary_weapon) {

	}

}
