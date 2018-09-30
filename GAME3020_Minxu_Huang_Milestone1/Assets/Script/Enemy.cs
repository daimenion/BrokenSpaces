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
	public int dmg;
	public int magicDmg;
	public GameObject clone;
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
			playerScrip.levelUp ();
			Destroy (this.gameObject);
			playerScrip.reSet ();
			clone.SetActive (true);
			playerScrip.enemies += 1;
		}
	}
	public void attack(){
		playerScrip.dealDmg (dmg-playerScrip.defends);
	}
	public void Magic(){
		playerScrip.dealDmg (magicDmg-playerScrip.defends);
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			transform.LookAt (target);
		}
	}
}
