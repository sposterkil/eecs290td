using UnityEngine;
using System.Collections;

public class PredatorTower : MonoBehaviour {
	TowerManager manager;
	Transform turret;
	Transform target;

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
		manager = GameObject.Find("Towers").GetComponent<TowerManager>();
		turret = transform.FindChild("Turret").FindChild("Turret1").transform;
		target = null;
	}
	
	// Update is called once per frame
	void Update () {
		target = manager.findTargetByHealth(transform, range, false);		
		if (target != null) {
			turret.LookAt(target.transform.position);
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
				Debug.DrawLine(turret.position, target.position, Color.green);
			}
		}
		else
			turret.LookAt(turret.position + new Vector3(0, 0, -1));
	}
}
