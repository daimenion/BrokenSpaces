using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	public Player playerScrip;
	public Slider enemyhpBar;
	public float enemyCurrentHealth = 20;
	private float enemyMaxHealth = 20;

	public Transform target;

	// Use this for initialization
	void Start () {
	 enemyCurrentHealth = 20;
	}
	
	// Update is called once per frame
	void Update () {

		enemyhpBar.maxValue = enemyMaxHealth;
		enemyhpBar.value = enemyCurrentHealth;
	}
	public void dealDmg(float damage){
		enemyCurrentHealth -= damage;
		if (enemyCurrentHealth <= 0) {
			Destroy (this.gameObject);
			playerScrip.levelUp ();
			playerScrip.reSet ();
		}
	}
	public void attack(){
		playerScrip.dealDmg (3-playerScrip.defends);
	}
	public void Magic(){
		playerScrip.dealDmg (5-playerScrip.defends);
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			transform.LookAt (target);
		}
	}
}
