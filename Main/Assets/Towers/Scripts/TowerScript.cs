using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {
	TowerManager manager;
	Transform turret;
	Transform targetSingle;
	Transform[] targetsAOE;
	Vector3 targetArea;

	long cooldownTimer;
	
	public enum Targeting {
		SingleTarget, SingleTargetByProxy, SingleTargetByHighestHealth, SingleTargetByLowestHealth, AOE
	};
	public Targeting targeting;

	public Color color;
	public int behaviourSet;
	public int damage;
	public int cooldown;
	public float rangeMin;
	public float rangeMax;
	public float rangeAOE;
	public float reduxDamage;
	public int reduxDamageDuration;
	public float reduxSpeed;
	public int reduxSpeedDuration;

	// Use this for initialization
	void Start () {
		transform.parent = GameObject.Find("Towers").transform;
		manager = transform.parent.GetComponent<TowerManager>();
		turret = transform.FindChild("Turret").FindChild("Turret1").transform;
		transform.FindChild("Model1").FindChild("Base").renderer.material.color = color;
		transform.FindChild("Turret").FindChild("Turret1").FindChild("Turret1").renderer.material.color = color;
		targetSingle = null;
		targetsAOE = null;
		targetArea = Vector3.zero;
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
		}
		switch (behaviourSet) {
			case 1: //Single Target, Single Shot
				if (targetSingle != null) {
					turret.LookAt(targetSingle.position);
					if (System.DateTime.Now.Ticks >= cooldownTimer) {
						attack(targetSingle, false);
						Debug.DrawLine(turret.position, targetSingle.position, color);
						cooldownTimer = System.DateTime.Now.Ticks + (10000 * cooldown);
					}
				}
				else
					turret.LookAt(turret.position + new Vector3(0, 0, -1));
				break;
			case 2: //Single Target, Single Shot, Resource
				if (targetSingle != null) {
					turret.LookAt(targetSingle.position);
					if (System.DateTime.Now.Ticks >= cooldownTimer) {
						attack(targetSingle, true);
						Debug.DrawLine(turret.position, targetSingle.position, color);
						cooldownTimer = System.DateTime.Now.Ticks + (10000 * cooldown);
					}
				}
				else
					turret.LookAt(turret.position + new Vector3(0, 0, -1));
				break;
			case 3: //AOE
				if (targetsAOE.Length > 0) {
					turret.LookAt(targetArea);
					if (System.DateTime.Now.Ticks >= cooldownTimer) {
						for (int i = 0; i < targetsAOE.Length; i++) {
							if (targetsAOE[i] != null) {
								attack(targetsAOE[i], false);
							}
						}
						Debug.DrawLine(turret.position, targetArea, color);
						cooldownTimer = System.DateTime.Now.Ticks + (10000 * cooldown);
					}
				}
				else
					turret.LookAt(turret.position + new Vector3(0, 0, -1));
				break;
			case 4:
				;
				break;
			case 5:
				;
				break;
			case 6:
				;
				break;
			case 7:
				;
				break;
			case 8:
				;
				break;
			case 9:
				;
				break;
			case 10:
				;
				break;
		}
	}
	
	public void attack(Transform target, bool forResource) {
		//Apply damage
		if (forResource)
			target.GetComponent<EnemyScript>().takeDamage(damage);
		else
			target.GetComponent<EnemyScript>().takeDamage(damage);
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
