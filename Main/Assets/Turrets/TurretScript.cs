using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
	Transform turret;
	Transform target;
	GameObject[] beacons;

	public long cooldownTimer;

	public int damage;
	public int cooldown;
	public float range;
	public float reduxDamage;
	public int reduxDamageDuration;
	public float reduxSpeed;
	public int reduxSpeedDuration;

	// Use this for initialization
	void Start () {
		turret = transform.FindChild("Turret").FindChild("Turret1").transform;
		beacons = GameObject.FindGameObjectsWithTag("Beacon");
	}
	
	// Update is called once per frame
	void Update () {
		//Look at target
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemies.Length == 1) {
			target = enemies[0].transform;
		}
		else if (enemies.Length != 0) {
			//Have tower aim via distance from beacon for the closest beacon.
			if (beacons.Length >= 1) {
				Transform beacon = null;
				Vector3 distB;
				Vector3 distT;
				int indexOfLowest = -1;
				float distOfLowest = 0f;
				if (beacons.Length > 1) {
					for (int i = 0; i < beacons.Length; i++) {
						beacon = beacons[i].transform;
						distB = beacon.position - transform.position;
						if ((indexOfLowest == -1)||(distB.magnitude < distOfLowest)) {
							indexOfLowest = i;
							distOfLowest = distB.magnitude;
						}
					}
				}
				else
					beacon = beacons[0].transform;
				Transform enemy;
				indexOfLowest = -1;
				distOfLowest = 0f;
				for (int i = 0; i < enemies.Length; i++) {
					enemy = enemies[i].transform;
					distB = enemy.position - beacon.position;
					distT = enemy.position - transform.position;
					if (((indexOfLowest == -1)||(distB.magnitude < distOfLowest))&&(distT.magnitude <= range)) {
						indexOfLowest = i;
						distOfLowest = distB.magnitude;
					}
				}
				if (indexOfLowest != -1)
					target = enemies[indexOfLowest].transform;
				else
					target = null;
			}
			//Otherwise, if no beacons exist, revert the tower to aim via proxy.
			else {
				Transform enemy;
				Vector3 distT;
				int indexOfLowest = -1;
				float distOfLowest = 0f;
				for (int i = 0; i < enemies.Length; i++) {
					enemy = enemies[i].transform;
					distT = enemy.position - transform.position;
					if (((indexOfLowest == -1)||(distT.magnitude < distOfLowest))&&(distT.magnitude <= range)) {
						indexOfLowest = i;
						distOfLowest = distT.magnitude;
					}
				}
				target = enemies[indexOfLowest].transform;
			}
		}
		if (target != null) {
			turret.LookAt(target.transform.position);
			Debug.DrawLine(turret.position, target.position);
			if (System.DateTime.Now.Ticks >= cooldownTimer) {
				//Apply damage
				target.GetComponent<EnemyScript>().takeDamage(damage);
				//Apply damage reduction if applicable
				if (reduxDamage != 0) {
					target.GetComponent<EnemyScript>().reduceDamage(reduxDamage, reduxDamageDuration);
				}
				//Apply movement speed reduction if applicable
				if (reduxSpeed != 0) {
					target.GetComponent<EnemyScript>().reduceSpeed(reduxSpeed, reduxSpeedDuration);
				}
				cooldownTimer = System.DateTime.Now.Ticks + (10000 * cooldown);
			}
		}
		else
			turret.LookAt(turret.position + new Vector3(0, 0, 1));
	}
}
