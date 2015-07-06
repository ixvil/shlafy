using UnityEngine;
using System.Collections;

public class BGmove : MonoBehaviour {



	float paralaxSpeed = 1.5f;
	// Update is called once per frame
	void FixedUpdate () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		movement movm = player_go.GetComponent<movement> ();
		if (movm.started) {
			Vector3 pos = transform.position;
			pos.x += paralaxSpeed * Time.deltaTime;
			transform.position = pos;
		}
	}
}
