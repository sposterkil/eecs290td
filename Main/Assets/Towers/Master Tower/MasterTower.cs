using UnityEngine;
using System.Collections;

public class MasterTower : MonoBehaviour {

    public GameObject activeTower;
	public GameObject[] towers;
    public int maxHealth;
    public int coins;
    public GameObject Hud;
    public Material platform;

	private int health;
	// Use this for initialization
	void Start () {
		health = maxHealth;
		// set the color back to bright blue at the start of the game
		platform.SetColor ("_Color", new Color (0, 1, 1));
		activeTower = towers[0];
		if (maxHealth != 0)
			Hud.GetComponent<HudScript>().updateHealth(health*100/maxHealth);
	}

	// Update is called once per frame
	void Update () {
        // Update Health and RAM counters
		if (maxHealth != 0)
			Hud.GetComponent<HudScript>().updateHealth (health*100/maxHealth);
        Hud.GetComponent<HudScript>().updateCoins(coins);

        GameObject targetLoc = PlatformUnderCursor();
        if(targetLoc != null){
            if (coins > 0) {
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

	public void addCoins(int num) {
		coins += num;
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
        coins--;
        return Instantiate(tower, towerBase.transform.position - new Vector3(0, .5f, 0), Quaternion.identity) as GameObject;
    }

	void OnTriggerEnter (Collider other) {
		health--;
        Debug.Log ("Main Base Damaged!!!");
        Destroy (other.gameObject); // delete the virus

        // update grid color based on remaining health
        float colorUpdate = ((float)health / maxHealth);
        Debug.Log (colorUpdate);
        platform.color = new Color((1 - colorUpdate), colorUpdate,colorUpdate);
	}

	void gameOver(){

	}
}
