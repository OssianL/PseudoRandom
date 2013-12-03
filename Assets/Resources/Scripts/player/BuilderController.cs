using UnityEngine;
using System.Collections;

public class BuilderController : MonoBehaviour {
	
	private bool active;
	private GameObject building;
	private float unit = 1.6f;
	private ItemInfo placableItmInf;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (active)
			BuildProgress ();
	}
	
	public void Build (ItemInfo itmInf) {
		this.placableItmInf = itmInf;
		active = true;
		building = (GameObject)Instantiate (placableItmInf.gObject);
		building.collider.isTrigger = true;
		itemSpecificOptionsWhenPlacing ();

	}
	
	private void BuildProgress () {
		Vector3 position = transform.position + (transform.forward * unit);
		building.SetActive (true);
		position = Utils.Snap (position, unit);
		position.x += unit / 2;
		position.z += unit / 2;
		position.y = 0;
		building.transform.position = position;
		if (Input.GetButtonDown ("Fire1"))
			PlaceBuilding ();
	}
	
	private void PlaceBuilding () {
		active = false;
		building.collider.isTrigger = false;

		itemSpecificOptionsAfterPlacing ();
		
		this.placableItmInf = null;
		SendMessage ("BuildComplete");
	}
	
	private void itemSpecificOptionsWhenPlacing () {
		if (placableItmInf.itemName == "Tower") {
			Tower tower = building.GetComponent<Tower> ();
			if (tower != null)
				tower.enabled = false;
		}
	}

	private void itemSpecificOptionsAfterPlacing () {
		if (placableItmInf.itemName == "Tower") {
			Tower tower = building.GetComponent<Tower> ();
			if (tower != null)
				tower.enabled = true;
		} else if (placableItmInf.itemName == "MEAT") {
			building.collider.isTrigger = true;
		} else if (placableItmInf.itemName == "DUCTTAPE") {
			building.collider.isTrigger = true;
		}
	
	}
	
}
