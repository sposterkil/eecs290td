using UnityEngine;
using System.Collections;

public class NodeScripts : MonoBehaviour {

	public GameObject node;
	public float rotSpeed;

	public void spawn() {

	}
	
	// Update is called once per frame
	void Update () {
		node.transform.Rotate (0, rotSpeed * Time.deltaTime, 0, Space.World);
	}
}
