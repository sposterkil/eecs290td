using UnityEngine;
using System.Collections;

public class MasterTower : MonoBehaviour {

    public GameObject activeTower;
	public GameObject[] towers;
    public int maxHealth;
    public int RAM;
    public GameObject Hud;
    public Material platform;
	public int      Level;
	public AudioSource hurtSound;

	private int health;
	// Use this for initialization
	void Start () {
		health = maxHealth;
		// set the color back to bright blue at the start of the game
		platform.SetColor ("_Color", new Color (0, 1, 1));
		activeTower = towers[0];
		// if we are at level 1
		if (maxHealth != 0 && Level == 1) 
			Hud.GetComponent<HudScript>().updateHealth(health*100/maxHealth);
		// if we are at level 2
		if (maxHealth != 0 && Level == 2) 
			Hud.GetComponent<HudScript2>().updateHealth(health*100/maxHealth);
		// if we are at the demo, which is level 3
		if (maxHealth != 0 && Level == 3)
			Hud.GetComponent<HudScriptDemo>().updateHealth(health*100/maxHealth);
	}

	// Update is called once per frame
	void Update () {
    
		// Update Health and RAM counters for level 1
		if (Level == 1) {
			Hud.GetComponent<HudScript> ().updateRAM (RAM);
		}

		// Update Health and RAM counters for level 1
		if (Level == 2) {
			Hud.GetComponent<HudScript2> ().updateRAM (RAM);
		}

		if (Level == 3) {
			Hud.GetComponent<HudScriptDemo> ().updateRAM (RAM);
		}

        GameObject targetLoc = PlatformUnderCursor();
        if(targetLoc != null){
            if (RAM >= activeTower.GetComponent<TowerScript>().cost) {
                StartCoroutine(DrawTower(activeTower, targetLoc));
          		if(Input.GetMouseButtonDown(0)){
					PlaceTower(activeTower, targetLoc);
				}
            }
        }
		if (Input.GetKeyDown("1"))
			activeTower = towers[0];
		else if (Input.GetKeyDown("2"))
			activeTower = towers[1];
		else if (Input.GetKeyDown("3"))
			activeTower = towers[2];
		else if (Input.GetKeyDown("4"))
			activeTower = towers[3];
		else if (Input.GetKeyDown("5"))
			activeTower = towers[4];
		else if (Input.GetKeyDown("6"))
			activeTower = towers[5];
		else if (Input.GetKeyDown("7"))
			activeTower = towers[6];
		else if (Input.GetKeyDown("8"))
			activeTower = towers[7];
		else if (Input.GetKeyDown("9"))
			activeTower = towers[8];
		else if (Input.GetKeyDown("0"))
			activeTower = towers[9];
		
		//trigger for losing the game
		if (health <= 0)
			gameOver ();
	}

	public void addRAM(int num) {
		RAM += num;
	}

    GameObject PlatformUnderCursor(){
        Ray toCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(toCursor, out hit)){
            if (hit.transform.gameObject.tag == "TowerBase"){
                return hit.transform.gameObject;
            }
        }
        return null;
    }

    IEnumerator DrawTower(GameObject tower, GameObject towerBase){
		GameObject instTower = Instantiate(tower, towerBase.transform.position - new Vector3(0, .5f, 0), Quaternion.identity) as GameObject;
        Component[] towerComponents = instTower.GetComponents(typeof(Component));
        MonoBehaviour[] towerScripts = instTower.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in towerScripts){
            script.enabled = false;
        }
        yield return new WaitForSeconds(.01f);
        Destroy(instTower);
    }


    GameObject PlaceTower(GameObject tower, GameObject towerBase){
        towerBase.tag = "TowerBase_occupied";
        RAM -= activeTower.GetComponent<TowerScript>().cost;
        return Instantiate(tower, towerBase.transform.position - new Vector3(0, .5f, 0), Quaternion.identity) as GameObject;
    }

	void OnTriggerEnter (Collider other) {
		health--;
		hurtSound.Play ();
        Debug.Log ("Main Base Damaged!!!");
        Destroy (other.gameObject); // delete the virus

        // update grid color based on remaining health
        float colorUpdate = ((float)health / maxHealth);
        Debug.Log (colorUpdate);
        platform.color = new Color((1 - colorUpdate), colorUpdate,colorUpdate);

		// do the health update here
		
		// Update Health and RAM counters for level 1
		if (Level == 1) {
			if (maxHealth != 0)
				Hud.GetComponent<HudScript> ().updateHealth (health * 100 / maxHealth);
		}
		
		// Update Health and RAM counters for level 1
		if (Level == 2) {
			if (maxHealth != 0)
				Hud.GetComponent<HudScript2> ().updateHealth (health * 100 / maxHealth);
		}
		if (Level == 3) {
			if (maxHealth != 0)
				Hud.GetComponent<HudScriptDemo> ().updateHealth (health * 100 / maxHealth);
		}
	}

	void gameOver(){
		GameObject[] remainingEnemies = GameObject.FindGameObjectsWithTag ("enemy");
		for (int i = 0; i < remainingEnemies.Length; i++) { // destroy all
			Destroy(remainingEnemies[i]);
		}
	}
}
