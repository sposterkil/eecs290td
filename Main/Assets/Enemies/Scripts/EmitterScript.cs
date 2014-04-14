using UnityEngine;
using System.Collections;

public class EmitterScript : MonoBehaviour {

	public float lifespan = 10f;
	// Update is called once per frame
	void Update () {

		lifespan -= Time.deltaTime;

		if (lifespan < 0){
			GameObject.Destroy (this.gameObject);
		}
	}
}
