using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour {
	public float whoIsFirst;
	public bool playerTurn;
	public bool enemyTurn;

	public Player player;
	public Enemy enemy;

	private bool attackClick;
	//magic clicked
	private bool magicClick;
	private bool spellClick;
	private bool spellTwoClick;
	//poition
	private bool poitionClick;
	private bool runAwayClick;
	// Use this for initialization
	private float enemyAttackChance;

	public GameObject battleCanvas;
	public GameObject magicCanvas;
	void Start () {
		

		whoIsFirst = Random.Range (0, 1);
		attackClick = false ;
		magicClick=false ;
		poitionClick=false ;
		runAwayClick=false ;
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void battle(){
		if (whoIsFirst < 0.5) {
			playerTurn = true;
			playerTrun ();
			wait ();
			Invoke ("enemyTrun", 2);
		} else {
			enemyTurn = true;
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
		else if (playerTurn == true && player.currentMana > 0 && spellClick == true ) {
			spellClick = false;
			playerTurn = false;
			enemyTurn = true;
			battleCanvas.SetActive(false);

		} else if (playerTurn == true && player.currentMana > 0 && spellTwoClick == true) {
			spellTwoClick = false;
			playerTurn = false;
			enemyTurn = true;
			battleCanvas.SetActive(false);
		}
		else if (poitionClick == true&&playerTurn == true){
			//player potion attack
			poitionClick = false;
			playerTurn = false;
			enemyTurn = true;
		}else if (runAwayClick == true&&playerTurn == true){
			//player runaway 
			runAwayClick = false;
			playerTurn = false;
			enemyTurn = true;
		}
	}

	public void enemyTrun(){
		if (enemyAttackChance > 1.5 && enemyTurn==true) {
			enemy.attack ();
			enemyTurn = false;
			playerTurn = true;
		} else if (enemyAttackChance < 1.5 && enemyTurn==true){
			enemy.Magic ();
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
	public void poitionClicked(){
		poitionClick = true;
		battle ();

	}
	public void runAwayClicked(){
		runAwayClick = true;
		battle ();

	}
	IEnumerator wait(){
		yield return new WaitForSeconds (1.0f);
	}

}
