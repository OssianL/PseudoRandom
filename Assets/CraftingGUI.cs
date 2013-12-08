using UnityEngine;
using System.Collections;

public class CraftingGUI : MonoBehaviour {
	private bool craftngOn = false;

	
	
	void Start () {
	
	}
	
	void Update () {
		toggleCraftingCheck ();
	}

	void OnGUI () {
		createCraftingGUI ();
	}
	
	private void toggleCraftingCheck () {
		if (Input.GetKeyUp (KeyCode.E)) {
			if (craftngOn) {
				craftngOn = false;
			} else if (!craftngOn) {
				craftngOn = true;
			}
		}
	}
	
	private void createCraftingGUI () {
		if (craftngOn) {
			testButton ();	
		}


	}
	
	private void testButton () {
		if (GUI.Button (new Rect (10, 10, 100, 100), "Test crafting")) {
			SendMessage ("Craft", new TestBlueprint ());
		}
	}
	
}
				