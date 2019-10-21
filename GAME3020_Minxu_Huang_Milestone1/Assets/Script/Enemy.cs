using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	public Player playerScrip;
	public Slider enemyhpBar;
	public float enemyCurrentHealth ;
	public float enemyMaxHealth ;

	public Transform target;
	public int dmg;
	public int magicDmg;
    public Shop sho;
	public GameObject clone;

	public Text log;

	public float speed;

	public BattleSystem battle;
	public Animator enemyAnim;
	// Use this for initialization
	void Start () {
		enemyCurrentHealth = enemyMaxHealth;
		battle.enemyTurn = false;
	}
	
	// Update is called once per frame
	void Update () {

		enemyhpBar.maxValue = enemyMaxHealth;
		enemyhpBar.value = enemyCurrentHealth;

		float step = speed * Time.deltaTime;

		// Move our position a step closer to the target.
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);

	}
	public void dealDmg(float damage){
		enemyCurrentHealth -= damage;
		enemyAnim.Play ("Damage");
		log.text = "enemy take "+damage+" damage";
		if (enemyCurrentHealth <= 0) {
			log.text= "enemy destroy";
			playerScrip.levelUp ();
			this.gameObject.SetActive (false);
			enemyMaxHealth = 0;
			playerScrip.reSet ();
            sho.money += 30;
			playerScrip.enemies ++;
			battle.enemies++;
			playerScrip.inbattle = false;
			battle.Reset ();
		}
	}
	public void attack(){
		playerScrip.dealDmg (dmg-playerScrip.defends);
		float dmgs = dmg -playerScrip.defends;
		log.text = "Enemy attacked player and deals "+ dmgs+" damage";
	}
	public void Magic(){
		playerScrip.dealDmg (magicDmg-playerScrip.defends);
		float dmgs = magicDmg -playerScrip.defends;
		log.text = "Enemy used magic against player and deals " + dmgs+" damage";
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			transform.LookAt (target);
			speed = 0;
		}
	}
	public void levelup(){
		dmg = 20;
		magicDmg = 25;
		enemyMaxHealth += 30;
	}
}
