using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RustyFenceBlueprint : Blueprint, IBlueprint
{
	private string location = "Prefabs/Buildings/RustyFence";
	private string name;
	
	public RustyFenceBlueprint ()
	{
		name = "RUSTY FENCE";
		base.addMaterial ("METAL SCRAPS", 5);
		base.addMaterial ("DUCT TAPE", 1);
				
	}
	
	public string getObjectLocation ()
	{
		return location;
	}
	
	public Dictionary<string, int> getMaterials ()
	{
		return base.getMaterials ();
	}
	
	public string getName ()
	{
		return name;
	}
	
}

