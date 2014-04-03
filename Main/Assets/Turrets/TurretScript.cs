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
		Transform enemy = GameObject.Find("TestEnemy").transform;
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemies.Length == 1) {
			turret.LookAt(enemies[0].transform.position);
		}
	}
}
