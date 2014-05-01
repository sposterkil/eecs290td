using UnityEngine;
using System.Collections;

public class ImageScript : MonoBehaviour {
	
	public TextMesh text; // the tower name and desc
	public TextMesh money; // the tower cost
	public MasterTower masterTowerScript;

	public void Update () {
		setTower (masterTowerScript.activeTower);
	}

	public void setTower(GameObject tower) {
		switch (tower.ToString ()) {
		case "ThreadTower (UnityEngine.GameObject)":
			text.text = "Thread - Simple Single Target";
			text.color = Color.blue;
			money.text = "250MB";
			break;
		case "GlitchTower (UnityEngine.GameObject)":
			text.text = "Glitch - Lower Damage + Stun";
			text.color = Color.white;
			money.text = "250MB";
			break;
		case "GarbageCollectionTower (UnityEngine.GameObject)":
			text.text = "Garbage Collection - Bonus RAM";
			text.color = Color.yellow;
			money.text = "400MB";
			break;
		case "ProcessModeratorTower (UnityEngine.GameObject)":
			text.text = "Process Mod - Targets Highest Health";
			text.color = Color.green;
			money.text = "400MB";
			break;
		case "ProcessTerminatorTower (UnityEngine.GameObject)":
			text.text = "Process Terminator - Targets Lowest Health";
			text.color = Color.red;
			money.text = "400MB";
			break;
		case "BreakTower (UnityEngine.GameObject)":
			text.text = "Break - Single Shot, High Range, High Damage";
			text.color = Color.grey;
			money.text = "500MB";
			break;
		case "WipeTower (UnityEngine.GameObject)":
			text.text = "Wipe - Deals Area Damage";
			text.color = new Color(1, 0.5f, 0f);
			money.text = "750MB";
			break;
		case "LagTower (UnityEngine.GameObject)":
			text.text = "Lag - Slow Area Around Tower";
			text.color = Color.cyan;
			money.text = "750MB";
			break;
		case "MemoryTower (UnityEngine.GameObject)":
			text.text = "Memory - Increasing Fire Rate";
			text.color = Color.magenta;
			money.text = "1000MB";
			break;
		case "LoadTower (UnityEngine.GameObject)":
			text.text = "Load - Area Damage Devided Amoung Targets";
			text.color = new Color( 0f, 0f, 0.55f);
			money.text = "1000MB";
			break;
		}

	}
}
