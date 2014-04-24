using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

	public TextMesh healthText;
	public TextMesh coinText;
	public TextMesh timerText;
	public TextMesh messageText;

	private int maxHealth;
	float timer = 300; // 5 minutes
	bool activeTimer;

	public GameObject platform;

	void Start () {
		activeTimer = true;
		messageText.text = "_Initializing";
		InvokeRepeating ("Spawn1", 15.2f, 1.5f); // spawn for a bit 
		InvokeRepeating ("Spawn3", 50.0f, 0.5f);
		InvokeRepeating ("Spawn2", 74.0f, 5.0f);

	}
	 
	// Update is called once per frame
	void Update () {
		if (activeTimer == true) {
			timer -= Time.deltaTime;
		}
		timerText.text = "_"+timer.ToString ();		

		if (294 > timer && timer > 292) //@6-8
			messageText.text = "Port 8023 Opening";
		if (292 > timer && timer > 290) //@8-10
			messageText.text = "Port 8023 Opening.";
		if (290 > timer && timer > 288) //@10-12
			messageText.text = "Port 8023 Opening..";
		if (288 > timer && timer > 286) //@12-14
			messageText.text = "Port 8023 Opening...";	
		if (285 > timer && timer > 255) //@15-45 open port for 30
			messageText.text = "Traffic: Port 8023";
		if (255 > timer && timer > 254) //@45-46 
			messageText.text = "Incoming DDOS";
		if (254 > timer && timer > 253) //@46-47
			messageText.text = "Incoming DDOS...3";
		if (253 > timer && timer > 252) //@47-48
			messageText.text = "Incoming DDOS...2";
		if (252 > timer && timer > 251) //@48-49
			messageText.text = "Incoming DDOS...1";
		if (251 > timer && timer > 230) //@49-70 fast movers for 21
			messageText.text = "High Traffic";
		if (230 > timer && timer > 231) //@70-71
			messageText.text = "Resource Hogs";
		if (231 > timer && timer > 232) //@71-72
			messageText.text = "Resource Hogs...3";
		if (232 > timer && timer > 233) //@72-73
			messageText.text = "Resource Hogs...2";
		if (233 > timer && timer > 234) //@73-74
			messageText.text = "Resource Hogs...1";
		if (234 > timer ) //@74 forever
			messageText.text = "_end of line";

	}

	public void updateHealth (int number){
		healthText.text = "_Infection: " + (100-number).ToString() + "%";
		if ((100 - number) >= 100) {
			gameOverMessage ();
		}
	}

	public void updateRAM (int number){
		coinText.text = "_RAM Remaining: " + number.ToString() + "MB";
	}

	public void gameOverMessage() {
		CancelInvoke ();
		string Score = timer.ToString ();
		activeTimer = false;
		messageText.text = "_Game Over - Score " + Score;
	}

	void Spawn1() {
		platform.GetComponent<MapSpawner> ().spawnVirus1 ();
	}
	void Spawn2() {
		platform.GetComponent<MapSpawner> ().spawnVirus2 ();
	}
	void Spawn3() {
		platform.GetComponent<MapSpawner> ().spawnVirus3 ();
	}
}
