using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public int health;
	public float damage;
	public long damageduration;
	public float speed;
	public long speedduration;

	// Use this for initialization
	void Start () {
		//System.DateTime.Now.Ticks
		damage = 1;
		speed = 1;
		damageduration = -1;
		speedduration = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (damageduration != -1) {
			if (System.DateTime.Now.Ticks >= damageduration) {
				damageduration = -1;
				damage = 1;
			}
		}
		if (speedduration != -1) {
			if (System.DateTime.Now.Ticks >= speedduration) {
				speedduration = -1;
				speed = 1;
			}
		}
	}
	
	public void takeDamage(int damage) {
		health -= damage;
		if (health <= 0)
			die();
	}
	
	public void reduceDamage(float factor, long duration) {
		damage = factor;
		damageduration = (System.DateTime.Now.Ticks + (1000L * 10000L)) * duration;
	}
	
	public void reduceSpeed(float factor, long duration) {
		speed = factor;
		speedduration = (System.DateTime.Now.Ticks + (1000L * 10000L)) * duration;
	}
	
	void die() {
		print("DEAD");
		GameObject.Destroy(this.gameObject);
	}
}
