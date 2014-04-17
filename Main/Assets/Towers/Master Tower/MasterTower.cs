using UnityEngine;
using System.Collections;

public class MasterTower : MonoBehaviour {

    public Shader wireframeShader;
    public GameObject TestTower;
	public int health;
	public int coins;
	public GameObject Hud;
	public AudioSource damageSound;
	public AudioSource towerPlaceSound;
	public AudioSource cannotPlaceSound;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        GameObject targetLoc = PlatformUnderCursor();
        if(targetLoc != null){
            StartCoroutine(DrawTower(TestTower, targetLoc));
          	  if(Input.GetMouseButtonDown(0)){
				if (coins > 0) {
					PlaceTower(TestTower, targetLoc);
					coins--;
					towerPlaceSound.Play ();
				}
				else {
					cannotPlaceSound.Play ();
				}
            }
        }
		// update health
		Hud.GetComponent<HudScript> ().updateHealth (health);
		Hud.GetComponent<HudScript> ().updateCoins (coins);

		// trigger for losing the game
		if (health <= 0) 
			gameOver ();
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
        GameObject instTower = Instantiate(tower, towerBase.transform.position, Quaternion.identity) as GameObject;
        Component[] towerComponents = instTower.GetComponents(typeof(Component));
        MonoBehaviour[] towerScripts = instTower.GetComponents<MonoBehaviour>();
        foreach(Component component in towerComponents){
            component.renderer.material.shader = wireframeShader;
        }
        foreach (MonoBehaviour script in towerScripts){
            script.enabled = false;
        }
        yield return new WaitForSeconds(.01f);
        Destroy(instTower);
    }


    GameObject PlaceTower(GameObject tower, GameObject towerBase){
        towerBase.tag = "TowerBase_occupied";
        return Instantiate(tower, towerBase.transform.position, Quaternion.identity) as GameObject;
    }

	void OnTriggerEnter (Collider other) {
		health--;
		Debug.Log ("Main Base Damaged!!!");
		Destroy (other.gameObject); // delete the virus
	}

	void gameOver(){

	}
}
