using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Boss : MonoBehaviour {
	public Player playerScrip;
	public Slider enemyhpBar;
	public float enemyCurrentHealth;
	public float enemyMaxHealth;

	public Transform target;
	public int dmg;
	public int magicDmg;
	public Shop sho;
	public GameObject clone;

	public Text log;

	public float speed;

	public BattleSystem battle;
	public Animator enemyAnim;

	public Canvas victory;

	// Use this for initialization
	void Start () {
		battle.enemyTurn = false;
		enemyMaxHealth = 100;
		dmg = 7;
		magicDmg = 10;
		enemyCurrentHealth = enemyMaxHealth;
		enemyMaxHealth = enemyCurrentHealth;
	}

	// Update is called once per frame
	void Update () {
		if (enemyCurrentHealth > enemyMaxHealth) {
			enemyCurrentHealth = enemyMaxHealth;
		}
		enemyhpBar.maxValue = enemyMaxHealth;
		enemyhpBar.value = enemyCurrentHealth;
		float step = speed * Time.deltaTime;

		// Move our position a step closer to the target.
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		if (enemyCurrentHealth > 500) {
			enemyCurrentHealth = 500;
		}

	}
	public void dealDmg(float damage){
		enemyCurrentHealth -= damage;
		enemyAnim.Play ("damage_001");
		log.text = "enemy take "+damage+" damage";
		if (enemyCurrentHealth <= 0) {
			log.text= "enemy destroy";
			playerScrip.levelUp ();
			battle.Reset ();
			Destroy (this.gameObject);
			playerScrip.reSet ();
			clone.SetActive (true);
			sho.money += 30;
			playerScrip.enemies ++;
			battle.enemies++;
			playerScrip.inbattle = false;
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
	public void heal(){
		enemyCurrentHealth += magicDmg;
		float dmgs = magicDmg;
		log.text = "Enemy used magic and heals " + dmgs+"  hp";
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			transform.LookAt (target);
			speed = 0;
			if (playerScrip.lvl < 6) {
				enemyMaxHealth = 100;
				enemyCurrentHealth = enemyMaxHealth;
				dmg = 15;
				magicDmg = 20;
			}			
			if (playerScrip.lvl >=6 ) {
				enemyMaxHealth = 200;
				enemyCurrentHealth = enemyMaxHealth;
				dmg = 25;
				magicDmg = 35;
			}
		}
	}
}
