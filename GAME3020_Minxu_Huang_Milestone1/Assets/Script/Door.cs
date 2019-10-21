using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	public bool safeDoor;
	public bool enemyDoor;
	public bool repeat;
	public int chance; 
	public Player player;
	//int doorChance;
	// Use this for initialization
	void Start () {
		//doorChance = Random.Range (1,4);
		//chance = doorChance;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
				if (chance == 1) {
				player.transform.position = player.tp [0 + player.num].gameObject.transform.position;
				}
				if (chance == 2) {
				player.transform.position = player.tp [3].gameObject.transform.position;
				}
				if (chance == 3) {
				player.transform.position = player.tp [4].gameObject.transform.position;
				}
		}
	}
}
