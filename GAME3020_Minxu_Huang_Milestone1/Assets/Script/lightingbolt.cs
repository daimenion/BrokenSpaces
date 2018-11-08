using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightingbolt : MonoBehaviour {
	public Player playerScrip;
	public GameObject player;
	public Transform target;
	public BattleSystem battle;
	public GameObject batle;
	public Rigidbody fall;
	// Use this for initialization
	float speed=20;
	void Start () {
		GameObject player = GameObject.Find("FPSController");
		playerScrip = player.GetComponent<Player>();

		GameObject batl = GameObject.Find("battlesystem");
		battle = batl.GetComponent<BattleSystem>();

		GameObject tar = GameObject.FindGameObjectWithTag("Target");
		target = tar.transform;
	
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Target")
		{
			Destroy(this.gameObject);
			playerScrip.lightingBolt();
			battle.playerTurn = false;
		}
	}
}
