using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

	public TextMesh healthText;
	public TextMesh coinText;
	public TextMesh timerText;
	public TextMesh messageText;

	private int maxHealth;
	float timer = 300; // 5 minutes
	float period = 0.1f;

	public GameObject platform;

	void Start () {
		messageText.text = "Initializing";
		InvokeRepeating ("Spawn1", 22.2f, 1);
	}
	 
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		timerText.text = timer.ToString ();		

		if (290 > timer && timer > 287) {
			messageText.text = "Port 8023 Opening";
				}
		if (287 > timer && timer > 284) {
			messageText.text = "Port 8023 Opening.";
		}
		if (284 > timer && timer > 281) {
			messageText.text = "Port 8023 Opening..";
		}
		if (281 > timer && timer > 278) {
			messageText.text = "Port 8023 Opening...";
		}
		if (278 > timer && timer > 277) {
			messageText.text = "Incoming Traffic: Port 8023!";
		}
	}

	public void updateHealth (int number){
		healthText.text = "Infection: " + (100-number).ToString() + "%";
	}

	public void updateRAM (int number){
		coinText.text = "RAM Remaining: " + number.ToString() + "MB";
	}

	void Spawn1() {
		platform.GetComponent<MapSpawner> ().spawnVirus1 ();
	}
}
