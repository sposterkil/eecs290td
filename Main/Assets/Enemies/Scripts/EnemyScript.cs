﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public int health;
	public int defaultDamage;
	public int defaultSpeed;
	
	GameObject[] stepnodes;
	// an invisible object which will emit the death animation
	public GameObject emitter;

	float damage;
	long damageduration;
	float speed;
	long speedduration;

	void Start () {
		//System.DateTime.Now.Ticks
		damage = defaultDamage;
		speed = defaultSpeed;
		damageduration = -1;
		speedduration = -1;

	}

	void Update () {
		//Update poisition
		transform.position += new Vector3(0, 0, .005f * speed);

		//Update debuffs
		if (damageduration != -1) {
			if (System.DateTime.Now.Ticks >= damageduration) {
				damageduration = -1;
				damage = defaultDamage;
			}
		}
		if (speedduration != -1) {
			if (System.DateTime.Now.Ticks >= speedduration) {
				speedduration = -1;
				speed = defaultSpeed;
			}
		}
	}
	
	public void takeDamage(int damage) {
		health -= damage;
		if (health <= 0)
			die();
	}
	
	public void reduceDamage(float factor, long duration) {
		damage = (1 - factor) * defaultDamage;
		damageduration = System.DateTime.Now.Ticks + (10000L * duration);
	}
	
	public void reduceSpeed(float factor, long duration) {
		speed = (1 - factor) * defaultSpeed;
		speedduration = System.DateTime.Now.Ticks + (10000L * duration);
	}
	
	void die() {
		GameObject clone;
		clone = Instantiate (emitter, transform.position, Quaternion.identity) as GameObject;
		GameObject.Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("hit node");
	}

	public Transform getNextNode() {



		return null;
	}
}
