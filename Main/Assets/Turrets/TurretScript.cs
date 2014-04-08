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
			//Have tower aim via distance from beacon for a single beacon.
			if (beacons.Length == 1) {
				Transform enemy;
				Transform beacon = beacons[0].transform;
				Vector3 dist;
				int indexOfLowest = -1;
				float distOfLowest = 0f;
				for (int i = 0; i < enemies.Length; i++) {
					enemy = enemies[i].transform;
					dist = new Vector3(enemy.position.x - beacon.position.x, enemy.position.y - beacon.position.y, enemy.position.z - beacon.position.z);
					if (i == 0) {
						indexOfLowest = 0;
						distOfLowest = dist.magnitude;
					}
					else if (dist.magnitude < distOfLowest) {
						indexOfLowest = i;
						distOfLowest = dist.magnitude;
					}
				}
				target = enemies[indexOfLowest];
			}
			//Otherwise, if no beacons or more than one beacon exist, revert the tower to aim via proxy.
			else {
				Transform enemy;
				Vector3 dist;
				int indexOfLowest = -1;
				float distOfLowest = 0f;
				for (int i = 0; i < enemies.Length; i++) {
					enemy = enemies[i].transform;
					dist = new Vector3(enemy.position.x - transform.position.x, enemy.position.y - transform.position.y, enemy.position.z - transform.position.z);
					if (i == 0) {
						indexOfLowest = 0;
						distOfLowest = dist.magnitude;
					}
					else if (dist.magnitude < distOfLowest) {
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
