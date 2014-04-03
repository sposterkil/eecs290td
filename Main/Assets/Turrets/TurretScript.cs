using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
	Transform turret;

	// Use this for initialization
	void Start () {
		turret = transform.FindChild("Turret").FindChild("TurretBody").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Look at target
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemies.Length == 1) {
			turret.LookAt(enemies[0].transform.position);
		}
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
			turret.LookAt(enemies[indexOfLowest].transform.position);
		}
	}
}
