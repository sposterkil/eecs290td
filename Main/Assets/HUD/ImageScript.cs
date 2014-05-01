using UnityEngine;
using System.Collections;

public class ImageScript : MonoBehaviour {

	public GameObject pane; // the image pane
	public TextMesh   text; // 
	public MasterTower masterTowerScript;

	public void Update () {
		setTower (masterTowerScript.activeTower);
	}

	public void setTower(GameObject tower) {
		switch (tower.ToString ()) {
		case "ThreadTower (UnityEngine.GameObject)":
			text.text = "Thread - Simple Single Target";
			break;
		case "GlitchTower (UnityEngine.GameObject)":
			text.text = "Glitch - Lower Damage + Stun";
			break;
		case "GarbageCollectionTower (UnityEngine.GameObject)":
			text.text = "Garbage Collection - Bonus RAM";
			break;
		case "ProcessModeratorTower (UnityEngine.GameObject)":
			text.text = "Process Mod - Targets Highest Health";
			break;
		case "ProcessTerminatorTower (UnityEngine.GameObject)":
			text.text = "Process Terminator - Targets Lowest Health";
			break;
		case "BreakTower (UnityEngine.GameObject)":
			text.text = "Break - Single shot, High Range, High Damage";
			break;
		case "WipeTower (UnityEngine.GameObject)":
			text.text = "Wipe - Deals Area Damage";
			break;
		case "LagTower (UnityEngine.GameObject)":
			text.text = "Lag - Slow Area Around Tower";
			break;
		case "MemoryTower (UnityEngine.GameObject)":
			text.text = "Memory - Increasing Fire Rate";
			break;
		case "LoadTower (UnityEngine.GameObject)":
			text.text = "Load - Area Damage Devided Amoung Targets";
			break;
		}

	}
}
