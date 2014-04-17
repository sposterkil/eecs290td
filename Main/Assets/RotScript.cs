using UnityEngine;
using System.Collections;

public class RotScript : MonoBehaviour {

	public GameObject thing;
	public float rotSpeed;
	
	// Update is called once per frame
	void Update () {
		thing.transform.Rotate (0, rotSpeed * Time.deltaTime, 0, Space.World);
	}
}
