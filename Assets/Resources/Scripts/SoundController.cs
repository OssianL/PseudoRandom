using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip onHit;
	public AudioClip onAttack;
	public AudioClip repeatingClip;
	public float repeatRate = 5f;
	public bool loop = false;
	
	private float lastRepeatPlayTime = float.MinValue;
	
	// Use this for initialization
	void Start () {
		if(loop) repeatRate = repeatingClip.length;
	}
	
	// Update is called once per frame
	void Update () {
		if(repeatingClip != null && Time.time - lastRepeatPlayTime > repeatRate) {
			lastRepeatPlayTime = Time.time;
			AudioSource.PlayClipAtPoint(repeatingClip, transform.position, 1f);
		}
	}
	
	public void OnHit() {
		if(onHit != null) AudioSource.PlayClipAtPoint(onHit, transform.position);
	}
	
	public void OnAttack() {
		if(onAttack != null) AudioSource.PlayClipAtPoint(onAttack, transform.position);
	}
	
}
