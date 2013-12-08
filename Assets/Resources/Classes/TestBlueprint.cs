using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestBlueprint : Blueprint, IBlueprint {
	private string location = "Prefabs/Buildings/TeslaCoil";
	
	public TestBlueprint (){
		base.addMaterial("MEAT", 2);
		base.addMaterial("DUCT TAPE", 2);
				
	}
	
	public string getObjectLocation() {
		return location;
	}
	
	public Dictionary<string, int> getMaterials() {
		return base.getMaterials();
	}
	
}


