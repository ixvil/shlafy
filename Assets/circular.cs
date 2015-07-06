using UnityEngine;
using System.Collections;

public class circular : MonoBehaviour {
	public AudioClip loopClip;
	public AudioClip actionClip;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().angularVelocity = -530;


	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collider) {
		AudioSource audioSource = GetComponent<AudioSource> ();
		if (audioSource.clip != actionClip) {
			audioSource.clip = actionClip;
			audioSource.Play ();
		}
	}
	/*void OnTriggerExit2D(Collider2D collider){
		Debug.Log (collider);
		AudioSource audioSource = GetComponent<AudioSource> ();
		if (audioSource.clip != loopClip) {
			audioSource.clip = loopClip;
			audioSource.Play ();
		}
	}*/
	
}
