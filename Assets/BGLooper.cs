using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {
	int numBGPanels = 2;
	float numForWood = 8.48f;

	public GameObject bigJewel;
	public Sprite[] bigSprites;
	public Sprite[] litSprites;
	public GameObject litJewel;

	SpriteRenderer bigSpriteRenderer;
	SpriteRenderer litSpriteRenderer;

	void Start(){
		//ruby = (GameObject)Resources.Load("prefabs/ruby");
		bigSpriteRenderer = bigJewel.GetComponent<SpriteRenderer> ();
		litSpriteRenderer = litJewel.GetComponent<SpriteRenderer> ();

	}
	void OnTriggerEnter2D(Collider2D collider) {


		float widthOfBGObject = ((BoxCollider2D)collider).size.x;
		Vector3 pos = collider.transform.position;
		if (collider.name == "wood") {
			pos.x += widthOfBGObject * numForWood;
			pos.y = Random.Range (-2, 1);
			if(pos.y < -3f)
				pos.y = -3f;
			if(pos.y > 2)
				pos.y = 2;

			Quaternion rot =  collider.transform.rotation;
			rot.z = Random.Range (-0.15f, 0.15f);

			collider.transform.rotation = rot;

		} else {
			pos.x += widthOfBGObject * numBGPanels;
		}

		if (collider.name == "town") {
			int count = (int) Random.Range(1,4);
			for( int i=0 ; i < count; i++ ){
				bigSpriteRenderer.sprite = bigSprites[Random.Range(0, bigSprites.Length-1)];
				Instantiate(bigJewel, new Vector3(pos.x+Random.Range (-20,20), Random.Range (2, 6), 0), Quaternion.identity); // as Transform;
			}
			count = (int) Random.Range(1,12);
			for( int i=0 ; i < count; i++ ){
				litSpriteRenderer.sprite = litSprites[Random.Range(0, litSprites.Length-1)];
				Instantiate(litJewel, new Vector3(pos.x+Random.Range (-20,20), Random.Range (2, 6), 0), Quaternion.identity); // as Transform;
			}

		}


		collider.transform.position = pos;
	}
}
