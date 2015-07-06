using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
	float jumpSpeed = 700f;
	float forwardSpeed = 500f;
	bool doJump = false;
	bool doBoost = false;
	bool isTapped;
	public bool started = false;
	public bool finished = false;
	Rigidbody2D rigidbody2D;
	ScoreScript scoreScript;
	public Sprite plus100Sprite;
	public Sprite plus30Sprite;
	public Sprite deadSprite;
	public Sprite aliveSprite;
	SpriteRenderer childSpriteRenderer;
	int maxClicks;

	public bool isStarted ()
	{
		return started;
	}

	void doStop ()
	{
		started = false;
		finished = true;
		childSpriteRenderer.sprite = deadSprite;
		rigidbody2D.velocity = new Vector3 (0, 0, 0);
		rigidbody2D.gravityScale = 0;
		Rigidbody2D circularRigid = GameObject.FindGameObjectWithTag ("circular").GetComponent<Rigidbody2D> ();
		circularRigid.angularVelocity = 0;

	}

	void doContinue ()
	{
		GetComponentInChildren<SpriteRenderer> ().sprite = aliveSprite;
		childSpriteRenderer.sprite = aliveSprite;
		Vector3 pos = rigidbody2D.position;
		pos.x += 5f;
		pos.y = 5f;
		rigidbody2D.position = pos;

		Score.getInstance ().updateBaseMeters ();
		Score.getInstance ().setStartPoint (pos.x);
		Score.getInstance ().setCurrentScoreF (0);


		Rigidbody2D circularRigid = GameObject.FindGameObjectWithTag ("circular").GetComponent<Rigidbody2D> ();
		circularRigid.angularVelocity = -530;

		finished = false;

	}

	void Start ()
	{
		childSpriteRenderer = GetComponentInChildren<SpriteRenderer> ();
		childSpriteRenderer.sprite = aliveSprite;
		rigidbody2D = GetComponent<Rigidbody2D> ();

		GameObject scoreValObj = GameObject.FindGameObjectWithTag ("ScoreVal");
		if (scoreValObj == null) {
			Debug.LogError ("no scoreValObj");
			return;
		}
		
		//scoreScript = scoreValObj.GetComponent<ScoreScript> ();
		Score.getInstance ().setStartPoint (transform.position.x);
		maxClicks = 3;
	}

	void Update ()
	{

		if(Input.touchCount > 0){
			foreach (var touch in Input.touches) 
			{ 
				if (touch.phase == TouchPhase.Began) 
					isTapped = true;
			}
		}

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0) || isTapped) {
			if (started){
				if(maxClicks > 0){
					doJump = true;
					maxClicks -= 1;
				}
			} else {
				if (!finished) {
					started = true;
					rigidbody2D.gravityScale = 1;
				} else {
					this.doContinue ();
				}
			}
			isTapped = false;
		}
		if (started) {
			Score.getInstance ().updateScore (Time.deltaTime * rigidbody2D.velocity.x);

		}


	}

	void FixedUpdate ()
	{
	
		if (started == true) {
			float k = 1f * (((float)Score.getInstance ().getCurrentMeters ())/1000 + 1);
			rigidbody2D.AddForce (Vector2.right * forwardSpeed * Time.deltaTime * k);
				
		}

		if (doJump == true) {
			doJump = false;

			rigidbody2D.AddForce (Vector2.up * jumpSpeed);
		}

		if (doBoost == true) {
			doBoost = false;
			rigidbody2D.AddForce (Vector2.right * forwardSpeed * 1f);
		}

		GetComponent<Rigidbody2D> ().angularVelocity = - rigidbody2D.velocity.x * 150f;

		Score.getInstance ().updateCurrentMeters (transform.position.x);
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.name == "bigJewel(Clone)") {
			Score.getInstance ().updateScore (100);
			collider.gameObject.GetComponent<SpriteRenderer> ().sprite = plus100Sprite;
			collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 30f));
		} else
		if (collider.name == "litJewel(Clone)") {
			Score.getInstance ().updateScore (30);
			collider.gameObject.GetComponent<SpriteRenderer> ().sprite = plus30Sprite;
			collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 30f));
		} else
		if (collider.name == "circ") {
			this.doStop ();
		} else {
			maxClicks = 3;

		}
	}



}
