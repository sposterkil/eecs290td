using UnityEngine;
using System.Collections;

public class TowerColorScript : MonoBehaviour {
	public Color color;

	//Set color at the start.
	void Start () {
		transform.FindChild("Model1").FindChild("Base").renderer.material.color = color;
		transform.FindChild("Turret").FindChild("Turret1").FindChild("Turret1").renderer.material.color = color;
	}
}
