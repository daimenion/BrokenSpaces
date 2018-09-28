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
	private bool magicClick;
	private bool poitionClick;
	private bool runAwayClick;
	// Use this for initialization
	private float enemyAttackChance;
	void Start () {
		playerTurn = true;
		enemyTurn = true;
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
		if (attackClick == true&&playerTurn == true) {	
			player.attack ();
			attackClick = false;
			playerTurn = false;
			enemyTurn = true;
		} else if (magicClick == true&&playerTurn == true){
			player.Magic();
			magicClick = false;
			playerTurn = false;
			enemyTurn = true;
		}else if (poitionClick == true&&playerTurn == true){
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
	public void magicClicked(){
		magicClick = true;
		battle ();

	}
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
