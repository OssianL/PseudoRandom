﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private bool buildTime = true;
	private WaveController waveController;
	
	// Use this for initialization
	void Start () {
		waveController = GetComponent<WaveController>();
	}
	
	// Update is called once per frame
	void Update () {
		//game over if all treasures are destroyed
		if(TreasureCount() <= 0) {
			GameOver();
		}
	}
	
	public void OnWaveStart() {
		buildTime = false;
	}
	
	public void OnWaveEnd() {
		buildTime = true;
	}
	
	public void GameOver() {
		Application.LoadLevel(2);
	}
	
	public void OnGUI() {
		//build time
		if(buildTime) {
			GUI.Label(new Rect(10f, 10f, 200f, 30f), "next wave in: " + waveController.TimeToNextWave() + " seconds!");
		}
		//wave time
		else {
			GUI.Label(new Rect(10f, 10f, 200f, 30f), "wave complete: " + waveController.EnemiesKilled() + "/" + waveController.EnemiesInWave());
		}
	}
	
	private int TreasureCount() {
		return GameObject.FindGameObjectsWithTag("Treasure").Length;
	}
}
