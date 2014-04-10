using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public int health;
	public int damage;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void takeDamage(int damage) {
		health -= damage;
		if (health <= 0)
			die();
	}
	
	void die() {
		print("DEAD");
		GameObject.Destroy(this.gameObject);
	}
}
