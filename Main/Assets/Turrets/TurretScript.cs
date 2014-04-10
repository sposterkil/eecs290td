using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
	Transform turret;
	GameObject target;
	
	public int damage;

	// Use this for initialization
	void Start () {
		turret = transform.FindChild("Turret").FindChild("TurretBody").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Look at target
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject[] beacons = GameObject.FindGameObjectsWithTag("Beacon");
		if (enemies.Length == 1) {
			target = enemies[0];
		}
		else if (enemies.Length != 0) {
			//Have tower aim via distance from beacon for the closest beacon.
			if (beacons.Length >= 1) {
				Transform beacon = null;
				Vector3 dist;
				int indexOfLowest = -1;
				float distOfLowest = 0f;
				if (beacons.Length > 1) {
					for (int i = 0; i < beacons.Length; i++) {
						beacon = beacons[i].transform;
						dist = beacon.position - transform.position;
						if ((indexOfLowest == -1)||(dist.magnitude < distOfLowest)) {
							indexOfLowest = i;
							distOfLowest = dist.magnitude;
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
					dist = enemy.position - beacon.position;
					if ((indexOfLowest == -1)||(dist.magnitude < distOfLowest)) {
						indexOfLowest = i;
						distOfLowest = dist.magnitude;
					}
				}
				target = enemies[indexOfLowest];
			}
			//Otherwise, if no beacons exist, revert the tower to aim via proxy.
			else {
				Transform enemy;
				Vector3 dist;
				int indexOfLowest = -1;
				float distOfLowest = 0f;
				for (int i = 0; i < enemies.Length; i++) {
					enemy = enemies[i].transform;
					dist = enemy.position - transform.position;
					if ((indexOfLowest == -1)||(dist.magnitude < distOfLowest)) {
						indexOfLowest = i;
						distOfLowest = dist.magnitude;
					}
				}
				target = enemies[indexOfLowest];
			}
		}
		if (target != null) {
			turret.LookAt(target.transform.position);
			target.GetComponent<EnemyScript>().takeDamage(damage);
		}
	}
}
