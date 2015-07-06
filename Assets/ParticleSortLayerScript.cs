using UnityEngine;
using System.Collections;

public class ParticleSortLayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystemRenderer>().sortingLayerName = "Ball";

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
