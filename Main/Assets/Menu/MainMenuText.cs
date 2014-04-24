using UnityEngine;
using System.Collections;

public class MainMenuText: MonoBehaviour 
{
	public bool isQuit;
	public bool isStart;
	
	void OnMouseEnter()
	{
		renderer.material.color = Color.gray;
	}

	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
	

	void OnMouseDown() {
		renderer.material.color = Color.red;

		if(isStart) {
			Application.LoadLevel(1);
		}
		else if(isQuit) {
			Application.Quit();
		}
		else {
		}
	}
}