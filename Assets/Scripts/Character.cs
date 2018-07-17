using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	public string name = "Unnamed Character";
	public float health = 10.0f;

	public float base_damage = 1.0f;

	public float speed = 1.0f;

	public List<Item> items;

	public Weapon primary_weapon;

	public Animation idle_animation;

	public Animation attack_animation;
	public Animation recieved_hit_animation;
	public Animation death_animation;

	public Character(string name, float health, float base_damage, List<Item> items, Weapon primary_weapon = null) {
		this.name = name;
		this.health = health;

		this.base_damage = base_damage;

		this.items = items;

		this.primary_weapon = primary_weapon;

		this.attack_animation = null;
		this.recieved_hit_animation = null;
		this.death_animation = null;
	}

	public void stopAllAnimations() {
		if (this.idle_animation != null) {
			this.idle_animation.Stop(
				this.idle_animation.clip.name
			);
		}

		if (this.attack_animation != null) {
			this.attack_animation.Stop(
				this.attack_animation.clip.name
			);
		}

		if (this.recieved_hit_animation != null) {
			this.recieved_hit_animation.Stop(
				this.recieved_hit_animation.clip.name
			);
		}

		if (this.death_animation != null) {
			this.death_animation.Stop(
				this.death_animation.clip.name
			);
		}
	}

	// ===== Basic Methods =====
	public void getHit(float damage) {
		if (this.recieved_hit_animation != null) {
			this.stopAllAnimations();
			this.recieved_hit_animation.Play(
				this.recieved_hit_animation.clip.name
			);
		}
		this.health -= damage;

		if (this.health <= 0) {
			if (this.death_animation != null) {
				this.stopAllAnimations();
				this.death_animation.Play(
					this.death_animation.clip.name
				);
			}
			Destroy(this.gameObject);
		}
	}

	public void attack(Character target) {
		if (this.primary_weapon != null) {
			this.primary_weapon.attack(target);
		} else {
			if (this.attack_animation != null) {
				this.stopAllAnimations();
				this.attack_animation.Play(
					this.attack_animation.clip.name
				);
			}
			target.getHit(this.base_damage);
		}
	}

	public IEnumerator speak(string message, float time) {
		GameObject ui_obj = GameObject.Find("UI");
		RectTransform canvas_rect_transform = ui_obj.GetComponent<RectTransform>();

		GameObject dialogue_obj = new GameObject();
		dialogue_obj.transform.parent = ui_obj.transform;
		dialogue_obj.name = "dialogue_obj";

		Text dialogue = dialogue_obj.AddComponent<Text>();
		dialogue.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
		dialogue.text = this.name + " : " + message;
		dialogue.fontSize = 12;

		RectTransform rectTransform = dialogue.GetComponent<RectTransform>();
		float width = canvas_rect_transform.sizeDelta.x;
		float height = canvas_rect_transform.sizeDelta.y;
		rectTransform.localPosition = new Vector3(0, (-(height/2.0f) + 40.0f), 0);
		rectTransform.sizeDelta = new Vector2(200, 30);
		rectTransform.eulerAngles = new Vector3(0, 0, 0);

		yield return new WaitForSeconds(time);

		Destroy(dialogue_obj);
	}

	void Start() {
		if (this.idle_animation != null) {
			this.idle_animation.Play(
				this.idle_animation.clip.name
			);
		}
	}

}
