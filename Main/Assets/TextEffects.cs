using UnityEngine;
using System.Collections;


// small script that adds on the blinking underscore to the end of the line
public class TextEffects : MonoBehaviour {

	public TextMesh text;
	
	float timer = 1f;

	// Update is called once per frame
	void Update () {

				timer -= Time.deltaTime; // clock
				if (timer < 0.0f) {
						if (text.text[text.text.Length - 1].Equals ('_'))
								text.text = text.text.Substring (0, text.text.Length - 1);
						else // add on the underscore
								text.text += "_";

			timer = 1f; //reset clock
			Debug.Log (text.text[text.text.Length - 1].Equals ('_'));
				}
		}
	
}
