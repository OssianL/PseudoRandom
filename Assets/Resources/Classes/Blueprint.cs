using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Blueprint {
	private Dictionary<string, int> materials;
	
	public Blueprint () {
		this.materials = new Dictionary<string, int> ();
	}
	
	public Dictionary<string, int> getMaterials() {
		return this.materials;
	}
	
 	public void addMaterial(string mat, int amount) {
		this.materials.Add(mat, amount);
	}

	


}

