using UnityEngine;
using System.Collections;

public class NodeScripts : MonoBehaviour {

	public GameObject node;
	public float rotSpeed;
	public float moveSpeed = 4;
	public Transform nextNode1;
	public Transform nextNode2;
	public Transform nextNode3;

	// Update is called once per frame
	void Update () {
		node.transform.Rotate (0, rotSpeed * Time.deltaTime, 0, Space.World);
	}

	// when a virus hits this node
	void OnTriggerEnter(Collider other) {
		Debug.Log ("Triggered!");	
		int nodeChoice = Random.Range (1, 4); // pick a random next node
		switch (nodeChoice) {
			case 1:
			other.gameObject.GetComponent<EnemyScript>().setTarget (nextNode1.position);
			Debug.Log ("Move => 1");	
			break;
			case 2:
			other.gameObject.GetComponent<EnemyScript>().setTarget (nextNode2.position);
			Debug.Log ("Move => 2");	
			break;
			case 3:
			other.gameObject.GetComponent<EnemyScript>().setTarget (nextNode3.position);
			Debug.Log ("Move => 3");
				break;
			default :
				Debug.LogError("fell off random switch to move to next node");
				break;
		}
	}
}
