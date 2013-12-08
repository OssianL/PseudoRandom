using UnityEngine;
using System.Collections;

public class BuilderController : MonoBehaviour {
	
	private bool buildingInProgress;
	private GameObject building;
	private float unit = 1.6f;
	private ItemInfo placableItmInf;
	private float groundHeight;
	
	public GameObject roadPartOnGroundLevel;


	
	void Start () {
<<<<<<< HEAD
		this.groundHeight = roadPartOnGroundLevel.transform.position.y;
=======
		//SendMessage("Build", testObject);
>>>>>>> ossian/master
	}
	

	void Update () {
		if (buildingInProgress)
			BuildProgress ();
	}
	
	public void Build (ItemInfo itmInf) {
		buildingInProgress = true;
		
		this.placableItmInf = itmInf;

		building = (GameObject)Instantiate (placableItmInf.gObject);
		ItemInfoScript s = (ItemInfoScript)building.GetComponent(typeof(ItemInfoScript));
		s.amount = 1;	

		building.collider.isTrigger = true;
		itemSpecificOptionsWhenPlacing ();
		if (buildingInProgress)
			BuildProgress ();
	}
	
	private void BuildProgress () {
		Vector3 position = transform.position + (transform.forward * unit);
		building.SetActive (true);
		position = Utils.Snap (position, unit);
		position.x += unit / 2;
		position.z += unit / 2;
		position.y = groundHeight;
		building.transform.position = position;

		if (Input.GetButtonDown ("Fire1"))
			PlaceBuilding ();
	}
	
	private void PlaceBuilding () {
		buildingInProgress = false;
		building.collider.isTrigger = false;

		itemSpecificOptionsAfterPlacing ();
		
		SendMessage ("PlacementComplete", this.placableItmInf);
		this.placableItmInf = null;
	}
	
	private void itemSpecificOptionsWhenPlacing () {
		if (placableItmInf.itemName == "Tower") {
			Tower tower = building.GetComponent<Tower> ();
			if (tower != null)
				tower.enabled = false;
		}
	}

	private void itemSpecificOptionsAfterPlacing () {
		if (placableItmInf.itemName == "TOWER") {
			Tower tower = building.GetComponent<Tower> ();
			if (tower != null)
				tower.enabled = true;
		} else if (placableItmInf.itemName == "MEAT") {
			building.collider.isTrigger = true;
		} else if (placableItmInf.itemName == "DUCT TAPE") {
			building.collider.isTrigger = true;
		}
	
	}
	
}
