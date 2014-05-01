using UnityEngine;
using System.Collections;

public class HudScriptDemo : MonoBehaviour {

	public TextMesh healthText;
	public TextMesh coinText;
	public TextMesh timerText;
	public TextMesh messageText;
	public TextMesh introText;
	public AudioSource notification;
	public MasterTower script;

	private int maxHealth;
	float timer = 60; // 5 minutes
	bool activeTimer;

	public GameObject platform;

	void Start () {
		activeTimer = true;
		messageText.text = "Standby.";
		InvokeRepeating ("Spawn1", 44f, 1.5f); // spawn norm 
		InvokeRepeating ("Spawn3", 50f, 0.5f); // spawn faster
		Invoke ("Spawn2", 52f); // two green
		Invoke ("Spawn2", 52f); 
		Invoke ("installRAM", 35f);

	}
	 
	// Update is called once per frame
	void Update () {
		if (activeTimer == true) {
			timer -= Time.deltaTime;
		}
		if (60 > timer && timer > 58)
			introText.text = "Welcome to";
		if (58 > timer && timer > 57.5)
			introText.text = "your Server";
		if (57.5 > timer && timer > 57)
			introText.text = "your Server_";
		if (57 > timer && timer > 56.5)
			introText.text = "your Server";
		if (56.5 > timer && timer > 56)
			introText.text = "your Server_";
		if (56 > timer && timer > 55.5)
			introText.text = "your Server";
		if (55.5 > timer && timer > 55)
			introText.text = "your Server_";
		if (55 > timer && timer > 54) 
			introText.text = "Move the mouse";
		if (54 > timer && timer > 53)
			introText.text = "to the left and";
		if (53 > timer && timer > 52)
			introText.text = "right sides of";
		if (52 > timer && timer > 51)
			introText.text = "the screen to";
		if (51 > timer && timer > 50)
			introText.text = "rotate left and";
		if (50 > timer && timer > 49)
			introText.text = "rotate right";
		if (49 > timer && timer > 48.5)
			introText.text = "rotate right_";
		if (48.5 > timer && timer > 48)
			introText.text = "rotate right";
		if (48 > timer && timer > 47.5)
			introText.text = "rotate right_";
		if (47.5 > timer && timer > 47)
			introText.text = "rotate right";
		if (47 > timer && timer > 46)
			introText.text = "rotate right_";
		if (46 > timer && timer > 45)
			introText.text = "Keep your ";
		if (45 > timer && timer > 44)
			introText.text = "system from";
		if (44 > timer && timer > 43)
			introText.text = "being clogged";
		if (43 > timer && timer > 42)
			introText.text = "from infection by";
		if (42 > timer && timer > 41)
			introText.text = "installing anti-";
		if (41 > timer && timer > 40)
			introText.text = "virus subroutines";
		if (40 > timer && timer > 39.5)
			introText.text = "on the white panels";
		if (39.5 > timer && timer > 39)
			introText.text = "on the white panels_";
		if (39 > timer && timer > 38.5)
			introText.text = "on the white panels";
		if (38.5 > timer && timer > 38)
			introText.text = "on the white panels_";
		if (38 > timer && timer > 37.5)
			introText.text = "on the white panels";
		if (37.5 > timer && timer > 37)
			introText.text = "the white panels_";
		if (37 > timer && timer > 36)
			introText.text = "deleting viruses";
		if (36 > timer && timer > 35)
			introText.text = "opens up memory";
		if (35 > timer && timer > 34)
			introText.text = "to be used on";
		if (34 > timer && timer > 33)
			introText.text = "installing more";
		if (33 > timer && timer > 32)
			introText.text = "Anti-virus";
		if (32 > timer && timer > 31.5)
			introText.text = "subroutines";
		if (31.5 > timer && timer > 31)
			introText.text = "subroutines_";
		if (31 > timer && timer > 30.5)
			introText.text = "subroutines";
		if (30.5 > timer && timer > 30)
			introText.text = "subroutines_";
		if (30 > timer && timer > 29)
			introText.text = "Various anti-virus";
		if (29 > timer && timer > 28)
			introText.text = "subroutines are";
		if (28 > timer && timer > 27)
			introText.text = "selectable using";
		if (27 > timer && timer > 26.5)
			introText.text = "number keys 1 - 0";
		if (26.5 > timer && timer > 26)
			introText.text = "number keys 1 - 0_";
		if (26 > timer && timer > 25.5)
			introText.text = "number keys 1 - 0";
		if (25.5 > timer && timer > 25)
			introText.text = "number keys 1 - 0_";
		if (25 > timer && timer > 24)
			introText.text = "600MB of Memory";
		if (24 > timer && timer > 23)
			introText.text = "have been installed";
		if (23 > timer && timer > 22)
			introText.text = "in this testing";
		if (22 > timer && timer > 21.5)
			introText.text = "environment";
		if (21.5 > timer && timer > 21)
			introText.text = "environment_";
		if (21 > timer && timer > 20.5)
			introText.text = "environment";
		if (20.5 > timer && timer > 20)
			introText.text = "environment_";
		if (20 > timer && timer > 19) {
			introText.text = "Install antivirus";
			messageText.text = "Test Viruses...3";
		}
		if (19 > timer && timer > 18) {
			introText.text = "subroutines and";
			messageText.text = "Test Viruses...2";
		}
		if (18 > timer && timer > 17) {
			introText.text = "Defend.";
			messageText.text = "Test Viruses...1";
		}
		if (17 > timer && timer > 6) {
			introText.text = "Defend.";
			messageText.text = "Spawning Viruses";
		}
		if (6 > timer && timer > 5)
			introText.text = "changing ENV...5";
		if (5 > timer && timer > 4)
			introText.text = "changing ENV...4";
		if (4 > timer && timer > 3)
			introText.text = "changing ENV...3";
		if (3 > timer && timer > 2)
			introText.text = "changing ENV...2";
		if (2 > timer && timer > 1)
			introText.text = "changing ENV...1";
		if (timer < 1)
			introText.text = "Loading Production ENV";
		if (timer <= 0)
						Application.LoadLevel (2);



		timerText.text = timer.ToString();  // updates the timer
	}

	public void updateHealth (int number){
		healthText.text = "Infection: " + (100-number).ToString() + "%";
		//if ((100 - number) >= 100) {
		//	gameOverMessage ();
		//}
	}

	public void installRAM() {
		script.addRAM (600);
	}

	public void updateRAM (int number){
		coinText.text = "RAM Remaining: " + number.ToString() + "MB";
	}

	public void gameOverMessage() {
		CancelInvoke ();
		string Score = timer.ToString ();
		activeTimer = false;
		timer = 99999f;
		messageText.text = "Game Over - Score " + Score;
	}

	void Spawn1() {
		platform.GetComponent<MapSpawnerDemo> ().spawnVirus1 ();
	}
	void Spawn2() {
		platform.GetComponent<MapSpawnerDemo> ().spawnVirus2 ();
	}
	void Spawn3() {
		platform.GetComponent<MapSpawnerDemo> ().spawnVirus3 ();
	}
}
