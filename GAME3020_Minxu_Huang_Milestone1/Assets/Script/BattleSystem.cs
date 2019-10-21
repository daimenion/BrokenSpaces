using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour {
	public float whoIsFirst;
	public bool playerTurn;
	public bool enemyTurn;
	public bool bossTurn;
	public Player player;
	public Enemy enemy;
	public int enemies;
	public Boss bos;

	private bool attackClick;
	//magic clicked
	private bool magicClick;
	private bool spellClick;
	private bool spellTwoClick;
    private bool spellThreeClick;
    //poition
    private bool potionClick;
	private bool hpClick;
	private bool manaClick;
	//run away
	private bool runAwayClick;
	public bool runaway;
	float runawayChance;
	// Use this for initialization
	private float enemyAttackChance;

	public GameObject battleCanvas;
	public GameObject magicCanvas;
	public GameObject PotionCanvas;
    public GameObject fire;
    public GameObject spawpoint;
    public GameObject lighting;
    public GameObject spawpointEnemy;
	public GameObject spawpointbos;
    public Text log;
	public Text mana;
	public Text heath;

	public Animator enemyAnim;
	public Animator bossAnim;
	public Animator playerAnim;
	public ParticleSystem boost;

	void Start () {
		

		whoIsFirst = Random.Range (0, 1);
		attackClick = false ;
		magicClick=false ;
		potionClick=false ;
		runAwayClick=false ;
	}
	
	// Update is called once per frame
	void Update () {
		heath.text = ": " + player.hpPotions;
		mana.text = ": " + player.manaPotions;
	}
	public void battle(){
		if (whoIsFirst < 0.5) {
			playerTrun ();
			wait ();
			if (player.boss) {
				if (runaway)
					bossTurn = false;
				else 
					bossTurn = true;
				if (bossTurn == true) {
					Invoke ("bossTrun", 2.5f);
				}
			} else {
				if (runaway)
					enemyTurn = false;
				else 
					enemyTurn = true;
				if (enemyTurn == true) {
					Invoke ("enemyTrun", 2.5f);
				}
			}
				
		} else {
			if (player.boss) {
				bossTrun ();
			} else {
				enemyTrun ();
			}
			wait ();
			Invoke ("playerTrun", 2);
		}
		enemyAttackChance = Random.Range (0, 10);
	}
	public void Abattle(){
		if (whoIsFirst < 0.5) {
			playerTrun ();
			wait ();
			if (player.boss) {
				if (runaway)
					bossTurn = false;
				else 
					bossTurn = true;
				if (bossTurn == true) {
					Invoke ("bossTrun", 1.0f);
				}
			} else {
				if (runaway)
					enemyTurn = false;
				else 
					enemyTurn = true;
				if (enemyTurn == true) {
					Invoke ("enemyTrun", 1.0f);
				}
			}

		} else {
			if (player.boss) {
				bossTrun ();
			} else {
				enemyTrun ();
			}
			wait ();
			Invoke ("playerTrun", 2);
		}
		enemyAttackChance = Random.Range (0, 10);
	}

	public void playerTrun(){
		if (attackClick == true && playerTurn == true) {
            playerAnim.Play("attack");
            player.attack ();
			attackClick = false;
			playerTurn = false;
		}


		//magic
		else if (playerTurn == true && player.currentMana > 0 && spellClick == true ) {
				player.increaseStrength ();
				spellClick = false;
				playerTurn = false;

		} else if (playerTurn == true && player.currentMana >= 2 && spellTwoClick == true) {
			if (player.boss) {
				Instantiate (fire.gameObject, spawpoint.transform.position, spawpoint.transform.rotation);
				spellTwoClick = false;
			} else {
				Instantiate (fire.gameObject, spawpoint.transform.position, spawpoint.transform.rotation);
				spellTwoClick = false;
			}
	
		}
        else if (playerTurn == true && player.currentMana >= 4 && spellThreeClick == true)
        {
			if (player.boss) {
				Instantiate (lighting.gameObject, spawpointbos.transform.position, spawpointbos.transform.rotation);
				spellThreeClick = false;
			} else {
				Instantiate (lighting.gameObject, spawpointEnemy.transform.position, spawpointEnemy.transform.rotation);
				spellThreeClick = false;
			}

        }


        //potion
        else if (hpClick == true&&playerTurn == true&&player.hpPotions >0){
			//player potion attack
			player.drinkHPPotion();
			hpClick = false;
			playerTurn = false;
		}else if (manaClick == true&&playerTurn == true&&player.manaPotions >0){
			//player potion attack
			player.drinkManaPotion();
			manaClick = false;
			playerTurn = false;
		}
		//player runaway 
		else if (runAwayClick == true&&playerTurn == true){
			runawayChance= Random.Range(0,10);
			if (runawayChance > 5) {
				runaway = false;
				runAwayClick = false;
				playerTurn = false;

			}
			if (runawayChance< 5) {
				runaway = true;
				runAwayClick = false;
				battleCanvas.SetActive(false);
				player.reSet ();
				Reset ();
				player.inbattle = false;
			}
		}
	}

	public void enemyTrun(){
		if (enemyAttackChance > 1.5 && enemyTurn==true) {
			enemyAnim.Play ("attack2");
			enemy.attack ();
			enemyTurn = false;
			playerTurn = true;
		} else if (enemyAttackChance < 1.5 && enemyTurn==true){
			enemyAnim.Play("attack");
            enemy.Magic ();
			enemyTurn = false;
			playerTurn = true;
		}
	}
	public void bossTrun(){
		if (enemyAttackChance > 4.5 && bossTurn==true) {
			bossAnim.Play ("attack_short_001");
			bos.attack ();
			bossTurn = false;
			playerTurn = true;
		} else if (enemyAttackChance < 4.5 &&enemyAttackChance > 1.5 && bossTurn==true){
			bossAnim.Play("attack_short_001");
			bos.Magic ();
			bossTurn = false;
			playerTurn = true;
		}else if (enemyAttackChance < 1.5 && bossTurn==true){
			bossAnim.Play("attack_short_001");
			bos.heal();
			bossTurn = false;
			playerTurn = true;
		}
	}

	public void attackClicked(){
		attackClick = true;
		Abattle ();

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
		if (player.currentMana>0) {
			battleCanvas.SetActive(true);
			magicCanvas.SetActive (false);
			boost.Play ();
			battle ();
		} else if (player.currentMana <=0){
			battleCanvas.SetActive(false);
			magicCanvas.SetActive (true);
		}


	}
	public void spellTwoClicked(){
		spellTwoClick = true;
		if (player.currentMana >= 2) {
			battleCanvas.SetActive(true);
			magicCanvas.SetActive (false);
			battle ();
			
		} else if (player.currentMana <2){
			battleCanvas.SetActive(false);
			magicCanvas.SetActive (true);
		}
			
	}
    public void spellThreeClicked()
    {
        spellThreeClick = true;
		if (player.currentMana >= 4 && player.lvl >= 3) {
			battleCanvas.SetActive (true);
			magicCanvas.SetActive (false);
				battle ();
			
		} else if (player.currentMana < 4) {
			battleCanvas.SetActive (false);
			magicCanvas.SetActive (true);
		}
		if (player.lvl < 3) {
			log.text = "Not learned yet requrie Level 3";
			spellThreeClick = false;
		}

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
			spellClick = false;
			spellTwoClick = false;
			spellThreeClick = false;
			Abattle ();
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
			spellClick = false;
			spellTwoClick = false;
			spellThreeClick = false;
			Abattle ();
		}

	}


	public void runAwayClicked(){
		runAwayClick = true;
		Abattle ();

	}
	IEnumerator wait(){
		yield return new WaitForSeconds (1.0f);
	}
	public void Reset(){
		playerTurn = false;
		enemyTurn = false;
		bossTurn = false;
		attackClick = false ;
		magicClick=false ;
		potionClick=false ;
		runAwayClick=false ;
	}

}
