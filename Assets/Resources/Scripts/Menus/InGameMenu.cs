using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {
	
	private bool on = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) on = !on;
	}
	
	public void OnGUI() {
		if(on) {
			GUI.Box(new Rect(Screen.width * 0.45f - 80f, Screen.height * 0.5f - 40f, Screen.width * 0.3f + 160f, Screen.height * 0.3f + 50f), "");
			if(GUI.Button(new Rect((0.5f * Screen.width) - 40f, 0.4f * Screen.height, 80f, 40f), "Resume")) {
				on = false;
			}
			if(GUI.Button(new Rect((0.5f * Screen.width) - 30f, 0.7f * Screen.height, 60f, 30f), "Back to main menu")) {
				Application.LoadLevel(0);
			}
		}
	}
}
