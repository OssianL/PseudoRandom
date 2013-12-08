		using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

// Encapsulated GUI representation of the inventory, press TAB to open
public class InventoryGUI : MonoBehaviour {
	private bool inventoryOn = false;
	public Inventory inventory;
	public int inventoryWidthDeduction;
	public int inventoryHeightDeduction;
	public int padding;
	public int titleH = 20;
	
	public int locHor;
	public int locVer;
	
	private int invW;
	private int invH;
	private int rows;
	private int cols;
	public GUIStyle slotStyle;
	
	void Start () {
		initInventoryDimensions ();
	}
	
	void Update () {
		toggleInventoryCheck ();
	}

	void OnGUI () {
		createInventoryGUI ();
	}
	
	private void initInventoryDimensions () {
		this.rows = inventory.inventoryRows;
		this.cols = inventory.inventoryColums;
		this.invW = Screen.width - inventoryWidthDeduction;
		this.invH = Screen.height - inventoryHeightDeduction;
	}
	
	private void toggleInventoryCheck () {
		if (Input.GetKeyUp (KeyCode.Tab)) {
			if (inventoryOn) {
				inventoryOn = false;
				GameObject.FindWithTag("Player").GetComponent<PlayerController>().SetMouseControll(true);
			} else if (!inventoryOn) {
				inventoryOn = true;
				GameObject.FindWithTag("Player").GetComponent<PlayerController>().SetMouseControll(false);
			}
		}
	}
	
	private void createInventoryGUI () {
		slotStyle = new GUIStyle (GUI.skin.button);
		if (inventoryOn) {
			GUI.BeginGroup (new Rect (locHor, locVer, invW, invH));

			// Main inventory frame
			GUI.Box (new Rect (0, 0, invW, invH), "");
			

			invH -= (int) titleH;
			
			GUI.Box (new Rect(0, 0, invW, titleH), "Inventory");
			

			
			drawInventorySlots ();
			

			invH += (int) titleH;
			GUI.EndGroup ();
		}
	}

	private void drawInventorySlots () {
		int slotW = (invW - padding) / cols;
		int slotH = (invH - padding) / rows;
		
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < cols; j++) {

				if (inventory.getItems () [slotInd (i, j)] != null) {
					drawSlotWithItem (i, j, slotW, slotH);	
				} else {
					// Draw an empty slot
					GUI.Box (new Rect (j * slotW + padding, i * slotH + padding, slotW - padding, slotH - padding), "");
				}
				
			}
		}
	}
	
	private void drawSlotWithItem (int row, int col, int slotW, int slotH) {
		ItemInfo itmInf = inventory.getItems () [slotInd (row, col)];
		GUIContent itemContent = new GUIContent ("x " + itmInf.getAmount (), itmInf.description);
		
		GUI.BeginGroup(createSlotRect (row, col, slotW, slotH));
		float textRatio = 0.3f;
		float textH = slotH*textRatio;
		GUI.Box(new Rect(0,0,slotW,textH), itemContent);
		
		setStyle (itmInf);	// Edit inventory slot text colors etc.
		if (GUI.Button (new Rect(0, textH, slotW, slotH*(1-textRatio)), "",slotStyle)) {
			itemButtonLogic(itmInf);
		}
		GUI.EndGroup();
	}
	
	private void setStyle (ItemInfo itemI) {
		slotStyle.normal.background = itemI.icon;
		slotStyle.hover.background = itemI.icon;
		slotStyle.active.background = itemI.icon;
					
		slotStyle.normal.textColor = new Color (0.2F, 0.2F, 0.2F, 1F);
		slotStyle.hover.textColor = new Color (0.1F, 0.1F, 0.1F, 1F);
		slotStyle.active.textColor = Color.black;
	}
		
	private int slotInd (int row, int col) {
		return (row * rows) + col;
	}
	
	private Rect createSlotRect (int row, int col, int slotW, int slotH) {
		return new Rect (col * slotW + padding, row * slotH + padding, slotW - padding, slotH - padding);
	}
	
	private void itemButtonLogic(ItemInfo clickedItem) {
		Debug.Log(clickedItem.itemName);
		this.gameObject.SendMessage("Build", clickedItem);
	}
	

}
