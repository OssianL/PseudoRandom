using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	
	public float continueDelay = 4f;
	
	private float startTime;
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey && Time.time - startTime > continueDelay) {
			Application.LoadLevel(0);
		}
	}
	
	public void OnGUI() {
		GUI.Label(new Rect(0.5f * Screen.width - 100f, 0.5f * Screen.height - 20f, 200f, 40f), "Game Over lulzis pulzis!");
		if(Time.time - startTime > continueDelay) {
			GUI.Label(new Rect(0.5f * Screen.width - 100f, 0.8f * Screen.height - 20f, 200f, 40f), "Press any key to continue...");
		}
	}
}
