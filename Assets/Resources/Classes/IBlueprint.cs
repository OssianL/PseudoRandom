using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IBlueprint {


	string getObjectLocation ();
	Dictionary<string, int> getMaterials();
	string getName();

}

