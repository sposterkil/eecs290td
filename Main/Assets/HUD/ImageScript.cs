using UnityEngine;
using System.Collections;

public class ImageScript : MonoBehaviour {

	public GameObject pane;
	public TextMesh   text;
	public MasterTower masterTowerScript;

	public void Update () {
		setTower (masterTowerScript.activeTower);
	}

	public void setTower(GameObject tower) {

		switch (tower.ToString ()) {
		case "ThreadTower":
			text.text = "Thread - Simple Single Target";
			break;
		case "GlitchTower":
			text.text = "Glitch - Lower Damage + Stun";
			break;
		case "GarbageCollectionTower":
			text.text = "Garbage Collection - Bonus RAM";
			break;
		case "ProcessModeratorTower":
			text.text = "Process Mod - Targets Highest Health";
			break;
		case "BreakTower":
			text.text = "Break - Single shot, High Range, High Damage";
			break;
		case "WipeTower":
			text.text = "Wipe - Deals Area Damage";
			break;
		case "LagTower":
			text.text = "Lag - Slow Area Around Tower";
			break;
		case "MemoryTower":
			text.text = "Memory - Fires Faster with Succsessive Shots";
			break;
		case "LoadTower":
			text.text = "Load - Area Damage Devided Amoung Targets";
			break;
		}

	}
}
