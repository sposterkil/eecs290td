using UnityEngine;
using System.Collections;

public class TowerManager : MonoBehaviour {
	GameObject[] beacons;
	GameObject[] enemies;

	// Use this for initialization
	void Start () {
		beacons = GameObject.FindGameObjectsWithTag("Beacon");
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
		beacons = GameObject.FindGameObjectsWithTag("Beacon");
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
	}

	public Transform findTarget(Transform tower, float range) {
		Transform target = null;

		//If only a single enemy exists, only one potential target exists.
		if (enemies.Length == 1) {
			if (enemies[0] != null){
				Vector3 dist = enemies[0].transform.position - tower.position;
				if (dist.magnitude <= range)
					target = enemies[0].transform;
			}
		}
		else if (enemies.Length != 0) {
			//Target via distance from beacon for the closest beacon.
			if (beacons.Length >= 1) {
				Transform beacon = null;
				Vector3 distB;
				Vector3 distT;
				int indexOfLowest = -1;
				float distOfLowest = 0f;
				if (beacons.Length > 1) {
					for (int i = 0; i < beacons.Length; i++) {
						beacon = beacons[i].transform;
						distB = beacon.position - tower.position;
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
					if (enemies[i] != null) {
						enemy = enemies[i].transform;
						distB = enemy.position - beacon.position;
						distT = enemy.position - tower.position;
						if (((indexOfLowest == -1)||(distB.magnitude < distOfLowest))&&(distT.magnitude <= range)) {
							indexOfLowest = i;
							distOfLowest = distB.magnitude;
						}
					}
				}
				if (indexOfLowest != -1)
					target = enemies[indexOfLowest].transform;
				else
					target = null;
			}
			//Otherwise, if no beacons exist, revert to targeting via proxy to tower.
			else {
				Transform enemy;
				Vector3 distT;
				int indexOfLowest = -1;
				float distOfLowest = 0f;
				for (int i = 0; i < enemies.Length; i++) {
					if (enemies[i] != null) {
						enemy = enemies[i].transform;
						distT = enemy.position - tower.position;
						if (((indexOfLowest == -1)||(distT.magnitude < distOfLowest))&&(distT.magnitude <= range)) {
							indexOfLowest = i;
							distOfLowest = distT.magnitude;
						}
					}
				}
				if (indexOfLowest != -1)
					target = enemies[indexOfLowest].transform;
				else
					target = null;
			}
		}
		return target;
	}
}
