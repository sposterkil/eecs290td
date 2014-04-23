﻿using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {
	TowerManager manager;
	Transform turret;
	Transform laser;
	Transform targetSingle;
	Transform[] targetsAOE;
	Vector3 targetArea;

	long cooldownTimer;

	public int cost;

	public enum Targeting {
		SingleTarget, SingleTargetByProxy, SingleTargetByHighestHealth, SingleTargetByLowestHealth, AOE, AOEFromTower
	};
	public Targeting targeting;

	public Color color;
	public int behaviourSet;
	public int damage;
	public int cooldown;
	public float rangeMin;
	public float rangeMax;
	public float rangeAOE;
	public int collection;
	public float reduxDamage;
	public int reduxDamageDuration;
	public float reduxSpeed;
	public int reduxSpeedDuration;

	// Use this for initialization
	void Start () {
		transform.parent = GameObject.Find("Towers").transform;
		manager = transform.parent.GetComponent<TowerManager>();
		turret = transform.FindChild("Turret").FindChild("Turret1").transform;
		laser = transform.transform.FindChild("Turret").FindChild("Turret1").FindChild("Turret1").FindChild("Laser");
		laser.gameObject.SetActive(false);
		transform.FindChild("Model1").FindChild("Base").renderer.material.color = color;
		transform.FindChild("Turret").FindChild("Turret1").FindChild("Turret1").renderer.material.color = color;
		targetSingle = null;
		targetsAOE = null;
		targetArea = Vector3.zero;
		if (behaviourSet == 3)
			turret.LookAt(turret.position + new Vector3(0, 1, 0));
	}
	
	// Update is called once per frame
	void Update () {
		switch (targeting) {
			case Targeting.SingleTarget:
				targetSingle = manager.findTarget(transform, rangeMin, rangeMax);
				break;
			case Targeting.SingleTargetByProxy:
				targetSingle = manager.findTargetByProxy(transform, rangeMin, rangeMax);
				break;
			case Targeting.SingleTargetByHighestHealth:
				targetSingle = manager.findTargetByHealth(transform, rangeMin, rangeMax, true);
				break;
			case Targeting.SingleTargetByLowestHealth:
				targetSingle = manager.findTargetByHealth(transform, rangeMin, rangeMax, false);
				break;
			case Targeting.AOE:
				targetArea = manager.findGroupTarget(transform, rangeMin, rangeMax);
				targetsAOE = manager.findAOETargets(targetArea, rangeAOE);
				break;
			case Targeting.AOEFromTower:
				targetsAOE = manager.findAOETargets(transform.position, rangeAOE);
				break;
		}
		switch (behaviourSet) {
			case 1: //Single Target, Single Shot
				if (targetSingle != null) {
					turret.LookAt(targetSingle.position);
					if (System.DateTime.Now.Ticks >= cooldownTimer) {
						attack(targetSingle);
						cooldownTimer = System.DateTime.Now.Ticks + (10000 * cooldown);
						laser.gameObject.SetActive(true);
					}
					else if (System.DateTime.Now.Ticks >= cooldownTimer - (10000 * cooldown) + 500000)
						laser.gameObject.SetActive(false);
				}
				else if (System.DateTime.Now.Ticks >= cooldownTimer - (10000 * cooldown) + 500000) {
					turret.LookAt(turret.position + new Vector3(0, 0, -1));
					laser.gameObject.SetActive(false);
				}
				break;
			case 2: //AOE
				if (targetsAOE.Length > 0) {
					turret.LookAt(targetArea);
					if (System.DateTime.Now.Ticks >= cooldownTimer) {
						for (int i = 0; i < targetsAOE.Length; i++) {
							if (targetsAOE[i] != null) {
								attack(targetsAOE[i]);
							}
						}
						cooldownTimer = System.DateTime.Now.Ticks + (10000 * cooldown);
						laser.gameObject.SetActive(true);
					}
					else if (System.DateTime.Now.Ticks >= cooldownTimer - (10000 * cooldown) + 500000)
						laser.gameObject.SetActive(false);
				}
				else if (System.DateTime.Now.Ticks >= cooldownTimer - (10000 * cooldown) + 500000) {
					turret.LookAt(turret.position + new Vector3(0, 0, -1));
					laser.gameObject.SetActive(false);
				}
				break;
			case 3: //AOEFromTower
				if (System.DateTime.Now.Ticks >= cooldownTimer) {
					for (int i = 0; i < targetsAOE.Length; i++) {
						if (targetsAOE[i] != null) {
							attack(targetsAOE[i]);
						}
					}
					cooldownTimer = System.DateTime.Now.Ticks + (10000 * cooldown);
					laser.gameObject.SetActive(true);
				}
				else if (System.DateTime.Now.Ticks >= cooldownTimer - (10000 * cooldown) + 500000) {
					laser.gameObject.SetActive(false);
				}
				break;
			case 4:
				;
				break;
		}
	}
	
	public void attack(Transform target) {
		//Apply damage
		target.GetComponent<EnemyScript>().takeDamage(damage, collection);
		//Apply damage reduction if applicable
		if (reduxDamage != 0) {
			target.GetComponent<EnemyScript>().reduceDamage(reduxDamage, reduxDamageDuration);
		}
		//Apply movement speed reduction if applicable
		if (reduxSpeed != 0) {
			target.GetComponent<EnemyScript>().reduceSpeed(reduxSpeed, reduxSpeedDuration);
		}
	}
}
