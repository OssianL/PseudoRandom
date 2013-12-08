using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class CraftingGUI : MonoBehaviour
{
	private bool craftngOn = false;
	public Crafting crafting;
	public int crftW;
	public int crftH;
	public int locHor;
	public int locVer;
	private List<IBlueprint>  blueprints;
	
	void Start ()
	{
		blueprints = crafting.getBlueprints ();
	
	}
	
	void Awake ()
	{
		blueprints = crafting.getBlueprints ();
	
	}
	
	void Update ()
	{
		toggleCraftingCheck ();
	}

	void OnGUI ()
	{
		createCraftingGUI ();
	}
	
	private void toggleCraftingCheck ()
	{
		if (Input.GetKeyUp (KeyCode.E)) {
			if (craftngOn) {
				craftngOn = false;
			} else if (!craftngOn) {
				craftngOn = true;
			}
		}
	}
	
	private void createCraftingGUI ()
	{
		if (craftngOn) {
			
			GUI.BeginGroup (new Rect (locHor, locVer, crftW, crftH));

			// Main inventory frame
			GUI.Box (new Rect (0, 0, crftW, crftH), "");
			drawCraftingMenu ();

			GUI.EndGroup ();
			
			
			
			
		}
		

	}
	
	private void testButton ()
	{
		if (GUI.Button (new Rect (10, 10, 100, 100), "Test crafting")) {
			SendMessage ("Craft", new TestBlueprint ());
		}
	}
	
	private void drawCraftingMenu ()
	{
		float menuTextH = 50f;
		GUI.Box (new Rect (0, 0, crftW, menuTextH), "Crafting");
		
		float buttonH = (crftH - menuTextH) / 2;
		
		for (int i = 0; i< blueprints.Count; i++) {
			IBlueprint bp = blueprints [i];
			Dictionary<string, int> mats = bp.getMaterials ();
			string name = bp.getName ();
			
			string textForButton = formCraftableMaterialString (name, mats);
			
			if (GUI.Button (new Rect (0, (i * buttonH) + menuTextH, crftW, buttonH), textForButton)) {
				SendMessage ("Craft", bp);
			}
		}
	}
	
	public string formCraftableMaterialString (string name, Dictionary<string,int> mats)
	{
		StringBuilder sb = new StringBuilder ();
		sb.Append (name + "\n" +
			"-------------\n");
		
		foreach(string mat in mats.Keys){
			int amount;
			mats.TryGetValue(mat, out amount);
			sb.Append(mat + " x " + amount + "\n");
		}
		
		
		return sb.ToString ();
	}
}
				