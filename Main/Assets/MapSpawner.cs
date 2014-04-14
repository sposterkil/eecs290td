using UnityEngine;
using System.Collections;

public class MapSpawner : MonoBehaviour {

	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;

	public GameObject virus;

	void Update() {

		// spawn a random virus
		if (Input.GetKeyDown (KeyCode.F2)){
			spawnVirus();
		}
	}


	// spawns a virus at a random spawn
	public void spawnVirus(){
		GameObject clone;
		int random = Random.Range(0, 4);
		switch (random) {
			case 1:
				Debug.Log ("spawn @ 1");
				clone = Instantiate(virus, spawn1.position, Quaternion.identity) as GameObject;
				break;
			case 2:
				Debug.Log ("spawn @ 1");
				 clone = Instantiate(virus, spawn2.position, Quaternion.identity) as GameObject;
				break;
			case 3:
				Debug.Log ("spawn @ 3");
				clone = Instantiate(virus, spawn3.position, Quaternion.identity) as GameObject;
				break;
			default:
				Debug.Log ("defualt spawn, broken");
				break;
		}
	}

	// spawns a virus at a specific spawn place
	public void spawnVirus(int position){
		}


}
