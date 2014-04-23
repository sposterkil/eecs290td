using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public int value;
	public int health;
	public int defaultDamage;
	public int defaultSpeed;

	public GameObject emitter; // an invisible object which will emit the death animation
 
	float damage;
	long damageduration;
	float speed;
	long speedduration;

	// this objects target, node or itself (as in not moving)
	Vector3 target;

	void Start () {
		damage = defaultDamage;
		speed = defaultSpeed;
		damageduration = -1;
		speedduration = -1;
		target = this.transform.position;
	}

	void Update () {
		//Move to the target
		transform.position =  Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

		//Update debuffs
		if (damageduration != -1) {
			if (System.DateTime.Now.Ticks >= damageduration) {
				damageduration = -1;
				damage = defaultDamage;
			}
		}
		if (speedduration != -1) {
			if (System.DateTime.Now.Ticks >= speedduration) {
				speedduration = -1;
				speed = defaultSpeed;
			}
		}
	}
	
	//Apply damage
	public void takeDamage(int damage, int resources) {
		health -= damage;
		if (health <=0) {
			die();
			GameObject.Find("MainTower").GetComponent<MasterTower>().addRAM(value + resources);
		}
	}
	
	public void reduceDamage(float factor, long duration) {
		damage = (1 - factor) * defaultDamage;
		damageduration = System.DateTime.Now.Ticks + (10000L * duration);
	}
	
	public void reduceSpeed(float factor, long duration) {
		if ((1 - factor) < speed) {
			speed = (1 - factor) * defaultSpeed;
			speedduration = System.DateTime.Now.Ticks + (10000L * duration);
		}
	}

	// death things
	void die() {
		GameObject clone;
		clone = Instantiate (emitter, transform.position, Quaternion.identity) as GameObject;
		GameObject.Destroy(this.gameObject);
	}

	// set the target, can be called from elsewhere
	public void setTarget(Vector3 newTarget) {
		target = newTarget;
	}
}
