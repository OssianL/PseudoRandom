using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeslaCoilBlueprint : Blueprint, IBlueprint {
	private string location = "Prefabs/Buildings/TeslaCoil";
	
	public TeslaCoilBlueprint ()
	{
		base.addMaterial ("METAL SCRAPS", 10);
		base.addMaterial ("ELECTRONICS", 5);
		base.addMaterial ("DUCT TAPE", 5);
				
	}
	
	public string getObjectLocation () {
		return location;
	}
	
	public Dictionary<string, int> getMaterials () {
		return base.getMaterials ();
	}
	
}

