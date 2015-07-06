using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	int currentScore;
	int fullScore;

	Text text;
	Text mtext;
	Text ftext;
	Text fdtext;
	Text btext;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		mtext = GameObject.FindGameObjectWithTag ("multiplier").GetComponent<Text> ();
		ftext = GameObject.FindGameObjectWithTag ("fullScore").GetComponent<Text> ();
		btext = GameObject.FindGameObjectWithTag ("bestScore").GetComponent<Text> ();
		fdtext = GameObject.FindGameObjectWithTag ("fullDistance").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		text.text = Score.getInstance().getCurrentScoreF().ToString()+" ("+Score.getInstance().getCurrentMeters().ToString()+"m)";
		mtext.text = "x" + Score.getInstance().getMult().ToString();
		ftext.text = "Full score: " + Score.getInstance ().getFullScoreF ().ToString();
		fdtext.text = "Full distance: " + Score.getInstance ().getFullMeters ().ToString()+"m";
		if (Score.getInstance ().getBestScore () > 0) {
			btext.text = "Best: " + Score.getInstance ().getBestScore ().ToString ();
			if( Score.getInstance ().getBestScore () == Score.getInstance ().getCurrentScoreF ()){
				btext.color = Color.cyan;
				btext.fontSize = 18;
			} else {
				btext.color = Color.white;
				btext.fontSize = 12;
			}
		}

	}
}
