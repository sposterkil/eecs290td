using UnityEngine;
using System.Collections;

public class MapSpawner : MonoBehaviour {

	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;

	public GameObject virus1;
	public GameObject virus2;

	public AudioSource spawnSound;

	void Update() {

		// spawn a random virus
		if (Input.GetKeyDown (KeyCode.F2)){
			spawnSound.Play ();
			spawnVirus1();
		}
		if (Input.GetKeyDown (KeyCode.F3)){
			spawnSound.Play ();
			spawnVirus2();
		}
	}


	// spawns a virus at a random spawn
	public void spawnVirus1(){
		GameObject clone;
		int random = Random.Range(1, 4);
		switch (random) {
			case 1:
				Debug.Log ("spawn1 @ 1");
				clone = Instantiate(virus1, spawn1.position , Quaternion.identity) as GameObject;
			break;
			case 2:
				Debug.Log ("spawn1 @ 1");
				clone = Instantiate(virus1, spawn2.position , Quaternion.identity) as GameObject;
			break;
			case 3:
				Debug.Log ("spawn1 @ 3");
				clone = Instantiate(virus1, spawn3.position , Quaternion.identity) as GameObject;
			break;
			default:
				Debug.Log ("defualt spawn, broken");
			break;
		}

	}

	// spawns a virus at a random spawn
	public void spawnVirus2(){
		GameObject clone;
		int random = Random.Range(1, 4);
		switch (random) {
		case 1:
			Debug.Log ("spawn2 @ 1");
			clone = Instantiate(virus2, spawn1.position , Quaternion.identity) as GameObject;
			break;
		case 2:
			Debug.Log ("spawn2 @ 1");
			clone = Instantiate(virus2, spawn2.position , Quaternion.identity) as GameObject;
			break;
		case 3:
			Debug.Log ("spawn2 @ 3");
			clone = Instantiate(virus2, spawn3.position , Quaternion.identity) as GameObject;
			break;
		default:
			Debug.Log ("defualt spawn, broken");
			break;
		}
		
	}


}
