using UnityEngine;
using System.Collections;

public class WipeTower : MonoBehaviour {
	TowerManager manager;
	Transform turret;
	Vector3 target;

	public long cooldownTimer;

	public int damage;
	public int cooldown;
	public float range;
	public float rangeAOE;
	public float reduxDamage;
	public int reduxDamageDuration;
	public float reduxSpeed;
	public int reduxSpeedDuration;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("Towers").GetComponent<TowerManager>();
		turret = transform.FindChild("Turret").FindChild("Turret1").transform;
		target = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		target = manager.findGroupTarget(transform, range);
		if (target != transform.position) {
			Transform[] targets = manager.findAOETargets(target, rangeAOE);
			turret.LookAt(target);
			if (System.DateTime.Now.Ticks >= cooldownTimer) {
				Transform subTarget;
				for (int i = 0; i < targets.Length; i++) {
					if (targets[i] != null) {
						subTarget = targets[i];
						//Apply damage
						subTarget.GetComponent<EnemyScript>().takeDamage(damage);
						//Apply damage reduction if applicable
						if (reduxDamage != 0) {
							subTarget.GetComponent<EnemyScript>().reduceDamage(reduxDamage, reduxDamageDuration);
						}
						//Apply movement speed reduction if applicable
						if (reduxSpeed != 0) {
							subTarget.GetComponent<EnemyScript>().reduceSpeed(reduxSpeed, reduxSpeedDuration);
						}
					}
				}
				cooldownTimer = System.DateTime.Now.Ticks + (10000 * cooldown);
				Debug.DrawLine(turret.position, target, new Color(200, 120, 0));
			}
		}
		else
			turret.LookAt(turret.position + new Vector3(0, 0, -1));
	}
}
