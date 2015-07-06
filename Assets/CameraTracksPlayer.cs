using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour {

	Transform player;
	//float offsetX;
	//float forwardSpeed = 150f;
	float prevSpeed = 0.1f;
	//float maxSpeed = 9.8f;
	// Use this for initialization
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		if (player_go == null) {
			Debug.LogError ("no player object");
			return;
		}
		player = player_go.transform;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate(){
		if(player != null){
			GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
			movement movm = player_go.GetComponent<movement> ();
			if (movm.isStarted()) {
				Vector3 pos = transform.position;
				pos.x += prevSpeed * Time.deltaTime;
				transform.position = pos;

				if(prevSpeed < player.GetComponent<Rigidbody2D>().velocity.x+2f){
					prevSpeed = player.GetComponent<Rigidbody2D>().velocity.x-1f;
					if(prevSpeed < 2f)
						prevSpeed = 2f;
				}
				if( player.GetComponent<Rigidbody2D>().position.x - transform.position.x > -1 ){
					prevSpeed += 50f * Time.deltaTime;

				}



			} else {
				prevSpeed = 0;
			}
		}
	}
}
