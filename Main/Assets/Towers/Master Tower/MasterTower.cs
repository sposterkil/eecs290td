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
        GameObject targetLoc = hitPlatform();
        if(targetLoc != null){
            PlaceTower(TestTower, targetLoc);
        }
	}

    GameObject hitPlatform(){
        Ray toCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(toCursor, out hit)){
            if (hit.transform.gameObject.tag == "TowerBase"){
                return hit.transform.gameObject;
            }
        }
        return null;
    }

    void PlaceTower(GameObject tower, GameObject towerBase){
        GameObject wireframe = Instantiate(tower, towerBase.transform.position, Quaternion.identity) as GameObject;
        wireframe.renderer.material.shader = wireframeShader;
        wireframe.GetComponent<MonoBehaviour>().enabled = false;

        if(Input.GetMouseButtonDown(0)){
            wireframe.GetComponent<MonoBehaviour>().enabled = true;
        }
    }
}
