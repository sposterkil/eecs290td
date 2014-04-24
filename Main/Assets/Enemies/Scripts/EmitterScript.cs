using UnityEngine;
using System.Collections;
public class EmitterScript : MonoBehaviour {

	public AudioSource deathSound;
	public float lifespan = 10f;

	void Start () {
		deathSound.Play ();
		}

	void Update () {

		lifespan -= Time.deltaTime;

		if (lifespan < 0){
			GameObject.Destroy (this.gameObject);
		}
	}
}
