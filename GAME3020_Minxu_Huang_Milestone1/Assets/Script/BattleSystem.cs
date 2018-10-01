using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour {
	public float whoIsFirst;
	public bool playerTurn;
	public bool enemyTurn;

	public Player player;
	public Enemy[] enemy;
	public int enemies = 0;

	private bool attackClick;
	//magic clicked
	private bool magicClick;
	private bool spellClick;
	private bool spellTwoClick;
	//poition
	private bool potionClick;
	private bool hpClick;
	private bool manaClick;
	//run away
	private bool runAwayClick;
	float runawayChance;
	// Use this for initialization
	private float enemyAttackChance;

	public GameObject battleCanvas;
	public GameObject magicCanvas;
	public GameObject PotionCanvas;

	public Text log;

	void Start () {
		

		whoIsFirst = Random.Range (0, 1);
		attackClick = false ;
		magicClick=false ;
		potionClick=false ;
		runAwayClick=false ;
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void battle(){
		if (whoIsFirst < 0.5) {
			playerTrun ();
			wait ();
			Invoke ("enemyTrun", 2);
		} else {
			enemyTrun ();
			wait ();
			Invoke ("playerTrun", 2);
		}
		enemyAttackChance = Random.Range (0, 10);

	
	}

	public void playerTrun(){
		if (attackClick == true && playerTurn == true) {	
			player.attack ();
			attackClick = false;
			playerTurn = false;
			enemyTurn = true;
		}


		//magic
		else if (playerTurn == true && player.currentMana > 0 && spellClick == true ) {
			spellClick = false;
			playerTurn = false;
			enemyTurn = true;

		} else if (playerTurn == true && player.currentMana > 0 && spellTwoClick == true) {
			spellTwoClick = false;
			playerTurn = false;
			enemyTurn = true;
		}


		//potion
		else if (hpClick == true&&playerTurn == true&&player.hpPotions >0){
			//player potion attack
			player.drinkHPPotion();
			hpClick = false;
			playerTurn = false;
			enemyTurn = true;
		}else if (manaClick == true&&playerTurn == true&&player.manaPotions >0){
			//player potion attack
			player.drinkManaPotion();
			manaClick = false;
			playerTurn = false;
			enemyTurn = true;
		}
		//player runaway 
		else if (runAwayClick == true&&playerTurn == true){
			runawayChance= Random.Range(0,10);
			if (runawayChance > 1) {
				runAwayClick = false;
				playerTurn = false;
				enemyTurn = true;
			}
			if (runawayChance< 1) {
				runAwayClick = false;
				battleCanvas.SetActive(false);
				player.reSet ();
			}
		}
	}

	public void enemyTrun(){
		if (enemyAttackChance > 1.5 && enemyTurn==true) {
			enemy[enemies].attack ();
			enemyTurn = false;
			playerTurn = true;
		} else if (enemyAttackChance < 1.5 && enemyTurn==true){
			enemy[enemies].Magic ();
			enemyTurn = false;
			playerTurn = true;
		}
	}

	public void attackClicked(){
		attackClick = true;
		battle ();

	}
	//magic buttons
	public void magicClicked(){
		if (enemyTurn == true) {
			magicClick = false;
			battleCanvas.SetActive(true);
			magicCanvas.SetActive (false);
		} else {
			magicClick = true;
			battleCanvas.SetActive(false);
			magicCanvas.SetActive (true);
		}

	}
	public void spellClicked(){
		spellClick = true;
		battle ();
	}
	public void spellTwoClicked(){
		spellTwoClick = true;
		battle ();
	}
	//poitions

	public void potionClicked(){
		
		if (enemyTurn == true) {
			potionClick = false;
			battleCanvas.SetActive(true);
			PotionCanvas.SetActive (false);
		} else {
			potionClick = true;
			battleCanvas.SetActive(false);
			PotionCanvas.SetActive (true);
		}

	}
	public void hpClicked(){
		hpClick = true;
		if (player.hpPotions <= 0) {
			battleCanvas.SetActive (false);
			PotionCanvas.SetActive (true);
		} else {
			battleCanvas.SetActive(true);
			PotionCanvas.SetActive (false);
			battle ();
		}
	}
	public void manaClicked(){
		manaClick = true;
		if (player.manaPotions <= 0) {
			battleCanvas.SetActive (false);
			PotionCanvas.SetActive (true);
		} else {
			battleCanvas.SetActive(true);
			PotionCanvas.SetActive (false);
			battle ();
		}

	}


	public void runAwayClicked(){
		runAwayClick = true;
		battle ();

	}
	IEnumerator wait(){
		yield return new WaitForSeconds (1.0f);
	}

}
