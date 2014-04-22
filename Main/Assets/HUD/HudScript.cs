using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

	public TextMesh healthText;
	public TextMesh coinText;

	private int maxHealth;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void updateHealth (int number){
		healthText.text = "Infection: " + (100-number).ToString() + "%";
	}

	public void updateCoins (int number){
		coinText.text = "RAM Remaining: " + number.ToString() + "MB";
	}
}
