using UnityEngine;
using System.Collections;
/**
 * This is for level 2, the 2nd heavy virus at position 3 only and the 
 * other two at positions 1 and 2.
 */
public class MapSpawner2 : MonoBehaviour {

	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	
	public GameObject virus1;
	public GameObject virus2;
	public GameObject virus3;
	
	void Update() {
		
		// spawn a random virus
		if (Input.GetKeyDown (KeyCode.F2)){
			spawnVirus1 ();
		}
		
		if (Input.GetKeyDown (KeyCode.F3)){
			spawnVirus2 ();
		}
		
		if (Input.GetKeyDown (KeyCode.F4)) {
			spawnVirus3 ();
		}
	}
	
	
	// spawns a virus at a one of the first two nodes
	public void spawnVirus1(){
		GameObject clone;
		int random = Random.Range(1, 3);
		switch (random) {
		case 1:
			//	Debug.Log ("spawn @ 1");
			clone = Instantiate(virus1, spawn1.position , Quaternion.identity) as GameObject;
			break;
		case 2:
			//	Debug.Log ("spawn @ 1");
			clone = Instantiate(virus1, spawn2.position , Quaternion.identity) as GameObject;
			break;
		default:
			Debug.Log ("defualt spawn, broken");
			break;
		}
	}
	
	// spawns the heavy virus at the 3rd node.
	public void spawnVirus2(){
		GameObject clone;
		//Debug.Log ("spawn @ 1");
		clone = Instantiate(virus2, spawn3.position , Quaternion.identity) as GameObject;
	}
	
	public void spawnVirus3(){
		GameObject clone;
		int random = Random.Range(1, 3);
		switch (random) {
		case 1:
			//Debug.Log ("spawn @ 1");
			clone = Instantiate(virus3, spawn1.position , Quaternion.identity) as GameObject;
			break;
		case 2:
			//Debug.Log ("spawn @ 1");
			clone = Instantiate(virus3, spawn2.position , Quaternion.identity) as GameObject;
			break;
		default:
			Debug.Log ("defualt spawn, broken");
			break;
		}
	}
}
