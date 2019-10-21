using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
	public ParticleSystem fir;
	public ParticleSystem lights;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Fire") {
			Instantiate (fir.gameObject, this.transform.position, this.transform.rotation);

			fir.Play ();
		}
		 if (other.tag == "lighting") {
			Instantiate (lights.gameObject, this.transform.position, this.transform.rotation);

			lights.Play ();
		}
	}
}
