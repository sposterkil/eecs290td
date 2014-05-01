using UnityEngine;
using System.Collections;

public class ImageScript : MonoBehaviour {
	
	public TextMesh   text; // 
	public MasterTower masterTowerScript;

	public void Update () {
		setTower (masterTowerScript.activeTower);
	}

	public void setTower(GameObject tower) {
		switch (tower.ToString ()) {
		case "ThreadTower (UnityEngine.GameObject)":
			text.text = "Thread - Simple Single Target";
			text.color = Color.blue;
			break;
		case "GlitchTower (UnityEngine.GameObject)":
			text.text = "Glitch - Lower Damage + Stun";
			text.color = Color.white;
			break;
		case "GarbageCollectionTower (UnityEngine.GameObject)":
			text.text = "Garbage Collection - Bonus RAM";
			text.color = Color.yellow;
			break;
		case "ProcessModeratorTower (UnityEngine.GameObject)":
			text.text = "Process Mod - Targets Highest Health";
			text.color = Color.green;
			break;
		case "ProcessTerminatorTower (UnityEngine.GameObject)":
			text.text = "Process Terminator - Targets Lowest Health";
			text.color = Color.red;
			break;
		case "BreakTower (UnityEngine.GameObject)":
			text.text = "Break - Single shot, High Range, High Damage";
			text.color = Color.grey;
			break;
		case "WipeTower (UnityEngine.GameObject)":
			text.text = "Wipe - Deals Area Damage";
			text.color = new Color(1, 0.5f, 0f);
			break;
		case "LagTower (UnityEngine.GameObject)":
			text.text = "Lag - Slow Area Around Tower";
			text.color = Color.cyan;
			break;
		case "MemoryTower (UnityEngine.GameObject)":
			text.text = "Memory - Increasing Fire Rate";
			text.color = Color.magenta;
			break;
		case "LoadTower (UnityEngine.GameObject)":
			text.text = "Load - Area Damage Devided Amoung Targets";
			text.color = new Color( 0f, 0f, 0.55f);
			break;
		}

	}
}
