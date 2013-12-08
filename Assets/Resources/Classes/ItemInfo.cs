using UnityEngine;
using System.Collections;

// Generic class on which to build different game items
public class ItemInfo {
	
	// Item name
	public string itemName;
	
	// Item ID
	public int id;
	
	// Item icon
	public Texture2D icon;
	
	// Item description 
	public string description;
	
	// Item amount
	private int amount;
	
	// Game object this info is attached to
	public GameObject gObject;
	
	// Is this item a weapon
	public bool isWeapon;
	
	
	// Add other info here, weight etc

	public ItemInfo (string itemName, Texture2D icon, string description, int amount, GameObject gObject, bool isWeapon) {
		this.itemName = itemName;
		this.icon = icon;
		this.description = description;
		this.amount = amount;
		this.gObject = gObject;
		this.isWeapon = isWeapon;
	}

	public bool increaseAmountBy (int inc) {
		Debug.Log ("amount to increase in item " + inc);
		this.amount += inc;
		return true;
	}
	
	public bool decreaseAmountBy (int dec) {
		Debug.Log ("amount to decrease in item " + dec);
		if (this.amount < dec) {
			return false;
		} 
		this.amount -= dec;
		return true;
	}
		
	public int getAmount () {
		return this.amount;
	}
	
	public bool setAmount (int amount) {
		this.amount = amount;
		return true;
	}
	
	public override bool Equals (object obj) {
		if (obj == null)
			return false;
		if (ReferenceEquals (this, obj))
			return true;
		if (obj.GetType () != typeof(ItemInfo))
			return false;
		ItemInfo other = (ItemInfo)obj;
		return itemName == other.itemName;
	}

	public override int GetHashCode () {
		unchecked {
			return (itemName != null ? itemName.GetHashCode () : 0);
		}
	}

}