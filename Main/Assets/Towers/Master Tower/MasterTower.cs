using UnityEngine;
using System.Collections;

public class MasterTower : MonoBehaviour {

    public Shader wireframeShader;
    public GameObject TestTower;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        GameObject targetLoc = PlatformUnderCursor();
        if(targetLoc != null){
            StartCoroutine(DrawTower(TestTower, targetLoc));
            if(Input.GetMouseButtonDown(0)){
                PlaceTower(TestTower, targetLoc);
            }
        }

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
        return Instantiate(tower, towerBase.transform.position, Quaternion.identity) as GameObject;
    }
}
