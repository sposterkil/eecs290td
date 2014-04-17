using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

	public TextMesh healthText;
	public TextMesh coinText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void updateHealth (int number){
		healthText.text = number.ToString ();
	}

	public void updateCoins (int number){
		coinText.text = number.ToString ();
	}
}
