using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {

    public float damage = 2.0f;
    public Animation attack_animation;

    public Weapon(string name, float damage) : base(name) {
        this.damage = damage;

        this.attack_animation = null;
    }

    public void stopAllAnimations() {
        if (this.attack_animation != null) {
            this.attack_animation.Stop(
                this.attack_animation.clip.name
            );
        }
    }

    public void attack(Character target) {
        if (this.attack_animation != null) {
            this.stopAllAnimations();
            this.attack_animation.Play(
                this.attack_animation.clip.name
            );
        }
        target.getHit(this.damage);
    }

}
