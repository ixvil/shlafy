using UnityEngine;
using System.Collections;

public class disapear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
			Vector3 pos = transform.position;
			pos.x = -100;
			pos.y = -100;
			transform.position = pos;
		}
	}
}
