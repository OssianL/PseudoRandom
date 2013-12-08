using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Crafting : MonoBehaviour {
	public List<IBlueprint> blueprints;
	public Inventory inventory;
	private bool waitingForInstantiate = false;
	private GameObject waitingObject;
	
	
	void Start () {
		
	}
	
	void Update () {

	}
	
	public bool Craft (IBlueprint bp) {
		Dictionary<string, int> mats = bp.getMaterials ();
		List<ItemInfo> items = inventory.getItems ();
		foreach (string mat in mats.Keys) {
			ItemInfo inventoryItem = items.Find (x => x.itemName == mat);
			
			if (inventoryItem == null)
				return false;
			
			int neededAmount;
			mats.TryGetValue (mat, out neededAmount);
			
			if (!enoughMats (inventoryItem.getAmount (), neededAmount)) {
				return false;
			}
			
			inventory.decreaseItemCountInInventory (inventoryItem, neededAmount);
		}
		addCraftedToInventory (bp);
		return true;

	}
	
	private bool enoughMats (int invAmount, int neededAmount) {
		if (invAmount < neededAmount)
			return false;
		return true;
	}
	
	private void addCraftedToInventory (IBlueprint bp) {
		string loc = bp.getObjectLocation();
		
		Debug.Log("Loading crafted item from location " + loc);
		GameObject crafted = (GameObject) Instantiate((GameObject) Resources.Load(loc));

		ItemInfo crfItmInf= getItemInfo(crafted);
		
		Debug.Log("ItemInfo of Crafted: " + crfItmInf.itemName);
		
		if(!inventory.addItem(crfItmInf)) Debug.LogError("Crafted item wasnt added to inventory");
		crafted.SetActive(false);
	
	}
	
	private ItemInfo getItemInfo(GameObject item) {
		ItemInfoScript s = (ItemInfoScript)item.GetComponent<ItemInfoScript>();
		return s.getItemInfo();
	}
	
}
