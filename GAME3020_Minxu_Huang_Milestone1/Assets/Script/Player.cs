using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {
	public FirstPersonController firstPerson;
	public Enemy enemy;
	public Boss bos;
	public int enemies = 0;
	public GameObject battleCanvas;
    public Animator shop;
    public Canvas shopcan;
	//hp
	public Slider hpBar;
	public Slider manaBar;
	private float sliderHp;
	public  float currentHealth ;
	private float maxHealth = 100;
	public float currentMana;
	private float maxMana=50;

	public float strength;
    public float maxStrength=2;
	public float weapStrength;
	public float magicPower= 1;
	public float defends=2; 


	public int hpPotions = 2;
	public int manaPotions = 2;
    public int lvl=1;

	public BattleSystem battle;

	public Text log;
	public Text mana;
	public Text HP;

	public bool inbattle;
	public bool boss;
	int scene;
	public float tim;
	public Text time;

	public Canvas victory;

	public int doorChance;
	public GameObject[] tp;
	public int round =0;
	public int num;
	//public GameObject[] bo = new GameObject[3];
	public Door[] box = new Door[3];
	public Door[] box2 = new Door[3];
	public Door[] box3 = new Door[3];
	bool end;
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		currentMana= maxMana;
		Time.timeScale = 1;
		doors ();
	}
	
	// Update is called once per frame
	void Update () {
		tim+=Time.deltaTime;
		float minutes = Mathf.Floor(tim / 60.0f);
		float seconds = Mathf.Floor(tim % 60.0f);
		if (bos.enemyCurrentHealth <= 0) {
			reSet ();
		}
		if (end) {
			victory.gameObject.SetActive (true);
			encounter ();
			Time.timeScale = 0;
		}
		if (seconds < 10)
			time.text = "Timer - " + minutes + " : 0" + Mathf.RoundToInt(seconds);
		else
			time.text = "Timer - " + minutes + " : " + Mathf.RoundToInt(seconds);
        manaBar.maxValue = maxMana;
        hpBar.maxValue = maxHealth;
        strength = maxStrength;

        hpBar.value = currentHealth;

		manaBar.value = currentMana;
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
		if (currentMana > maxMana)
			currentMana = maxMana;

		mana.text = " " + currentMana;
		HP.text = " " + currentHealth;
		death ();
		if (maxStrength < 0) {
			maxStrength = 0;
		}
		if (!enemy.isActiveAndEnabled) {
			battle.Reset ();
		}
			
	}
	public void dealDmg(float damage){
		currentHealth -= damage;
		log.text = "player take : " + damage+" damage";
		if (currentHealth<=0) {
			//daelth scren;
		}
	
	}

    public void encounter() {
        firstPerson.m_WalkSpeed = (0);
        firstPerson.m_JumpSpeed = (0);
        firstPerson.m_MouseLook.lockCursor = false;
        Cursor.visible = true;
        Screen.lockCursor = false;
        firstPerson.enabled = false;
    }
	public void reSet(){
		firstPerson.m_WalkSpeed = (5);
		firstPerson.m_JumpSpeed = (10);
		firstPerson.m_MouseLook.lockCursor = true;
		Cursor.visible = false;
		Screen.lockCursor = true;
		firstPerson.enabled = true;
		battleCanvas.SetActive(false);
		battle.playerTurn = false;
		battle.enemyTurn = false;
        strength = maxStrength;


	}
	public void attack(){
		if (boss) {
			bos.dealDmg (1 + strength + weapStrength);
			float dmg = 1 + strength + weapStrength;
			log.text = "Player attack and deals " + dmg + " to boss";
		} else {
			enemy .dealDmg (1 + strength + weapStrength);
			float dmg = 1 + strength + weapStrength;
			log.text = "Player attack and deals " + dmg + " to enemy";
		}
	}
	public void fireBall(){
		if (boss) {
			if (currentMana >= 2) {
				bos.dealDmg (4 + magicPower);
				float dmg = 4 + magicPower;
				log.text = "Player uses fire ball and deals " + dmg + " to bos";
				currentMana -= 8;
			} else {
				log.text = "not enough mana";
			}
		} else {
			if (currentMana >= 2) {
				enemy.dealDmg (4 + magicPower);
				float dmg = 4 + magicPower;
				log.text = "Player uses fire ball and deals " + dmg + " to enemy";
				currentMana -= 8;
			} else {
				log.text = "not enough mana";
			}
		}

	}
	public void lightingBolt(){
		if (boss) {
			if (currentMana >= 4) {
				bos.dealDmg (7 + magicPower);
				float dmg = 7 + magicPower;
				log.text = "Player uses lighting bolt and deals " + dmg + " to boss";
				currentMana -= 12;
			} else {
				log.text = "not enough mana";
			}
		} else {
			if (currentMana >= 4) {
				enemy.dealDmg (7 + magicPower);
				float dmg = 7 + magicPower;
				log.text = "Player uses lighting bolt and deals " + dmg + " to enemy";
				currentMana -=12;
			} else {
				log.text = "not enough mana";
			}
		}

	}
	public void increaseStrength(){
		if (currentMana > 0) {
			strength += 2;
			log.text = "Player strength increase by " + 2;
			currentMana -= 5;
		} else {
			log.text = "not enough mana";
		}
	}
	public void levelUp(){
		maxStrength += 5;
		magicPower += 5;
		defends += 2;
        maxHealth += 10;
        currentHealth += 10;
        maxMana += 10;
        currentMana += 10;
        lvl++;
	}
	public void drinkHPPotion(){
		if (hpPotions > 0) {
			currentHealth += 20;
			log.text = "Player used hp potion and heals " + 20 + " hp";
			hpPotions--;
		} else if (hpPotions <= 0) {
			log.text= "No more hp potion ";
		}
	}
	public void drinkManaPotion(){
		if (manaPotions > 0) {
			currentMana += 20;
			log.text="Player used mana potion and heals " + 20+" mana";
			manaPotions--;
		}
		else if (manaPotions <= 0) {
			log.text= "No more mana potion ";
		}
	}
	public void death(){
		if (currentHealth <= 0) {
			scene = 2;
			Invoke ("screenChange", 1);
		}

	}
	public void screenChange(){
		SceneManager.LoadScene (scene);
	}
	public void equip(int weapo){
		maxStrength += weapo;
	}
	void OnTriggerEnter(Collider other){

		if (other.tag == "Enemy") {
			encounter ();
			battleCanvas.SetActive (true);
			battle.playerTurn = true;
			log.text = "Encounter enemy!!";
			inbattle = true;
			battle.runaway = false;
		}
		if (other.tag == "boss") {
			encounter ();
			battleCanvas.SetActive (true);
			battle.playerTurn = true;
			log.text = "Encounter enemy!!";
			inbattle = true;
			battle.runaway = false;
			boss = true;
		} else if (other.tag == "Shop") {
			shop.Play ("shopanim");
			log.text = "Welcome to the shop.";
			shopcan.gameObject.SetActive (true);
			encounter ();
		}
		if (other.tag == "heal") {
			log.text = "Heal!";
			currentHealth = maxHealth;
			currentMana = maxMana;
		}
		if (other.tag == "SafeDoor") {
			num++;
			transform.position = tp[0+num].gameObject.transform.position;
			doors ();
			if (num == 3) {
				round++;
				if (round == 2)
					transform.position = tp [5].gameObject.transform.position;
				else {
					transform.position = tp [0].gameObject.transform.position;
					num = 0;
				}
				
			}

		}
		if (other.tag == "EnemyDoor") {
			transform.position = tp[0+num].gameObject.transform.position;
			doors ();
			enemy.gameObject.SetActive (true);
			if (enemy.isActiveAndEnabled) {
				enemy.levelup();
				enemy .enemyCurrentHealth = enemy.enemyMaxHealth;
			}

		}	
		if (other.tag == "BossDoor") {
			end = true;
		}

	}
	public void doors(){
		doorChance = Random.Range (1,4);
		for (int i = 0; i < box.Length; i++) {
			doorChance = Random.Range (1,4);
			box [0].chance = doorChance;
			if (box [0].chance == 3) {
				doorChance = Random.Range (1,2);
				box [1].chance = doorChance;
				if (box [1].chance == 2) {
					box [2].chance =1;
				}
				if (box [1].chance == 1) {
					box [2].chance =2;
				}
			}
			if (box [0].chance == 2) {
				doorChance = Random.Range (1,2);
				box [1].chance = doorChance;
				if (doorChance == 1) {
					box [1].chance = 3;
					box [2].chance = 1;
				}
				if (doorChance == 2) {
					box [1].chance = 1;
					box [2].chance = 3;
				}
			}
			if (box [0].chance == 1) {
				doorChance = Random.Range (2,3);
				box [1].chance = doorChance;
				if (box [1].chance == 2) {
					box [2].chance =3;
				}
				if (box [1].chance == 3) {
					box [2].chance =2;
				}
			}
		}
		//second
		for (int i = 0; i < box2.Length; i++) {
			doorChance = Random.Range (1,4);
			box2 [0].chance = doorChance;
			if (box2 [0].chance == 3) {
				doorChance = Random.Range (1,2);
				box2 [1].chance = doorChance;
				if (box2 [1].chance == 2) {
					box2 [2].chance =1;
				}
				if (box2 [1].chance == 1) {
					box2 [2].chance =2;
				}
			}
			if (box2 [0].chance == 2) {
				doorChance = Random.Range (1,2);
				box2 [1].chance = doorChance;
				if (doorChance == 1) {
					box2 [1].chance = 3;
					box2 [2].chance = 1;
				}
				if (doorChance == 2) {
					box2 [1].chance = 1;
					box2 [2].chance = 3;
				}
			}
			if (box2 [0].chance == 1) {
				doorChance = Random.Range (2,3);
				box2 [1].chance = doorChance;
				if (box2 [1].chance == 2) {
					box2 [2].chance =3;
				}
				if (box2 [1].chance == 3) {
					box2 [2].chance =2;
				}
			}
		}
		//thrid
		for (int i = 0; i < box.Length; i++) {
			doorChance = Random.Range (1,4);
			box3 [0].chance = doorChance;
			if (box3 [0].chance == 3) {
				doorChance = Random.Range (1,2);
				box3 [1].chance = doorChance;
				if (box3 [1].chance == 2) {
					box3[2].chance =1;
				}
				if (box3 [1].chance == 1) {
					box3 [2].chance =2;
				}
			}
			if (box3 [0].chance == 2) {
				doorChance = Random.Range (1,2);
				box3 [1].chance = doorChance;
				if (doorChance == 1) {
					box3 [1].chance = 3;
					box3 [2].chance = 1;
				}
				if (doorChance == 2) {
					box3 [1].chance = 1;
					box3 [2].chance = 3;
				}
			}
			if (box3 [0].chance == 1) {
				doorChance = Random.Range (2,3);
				box3 [1].chance = doorChance;
				if (box3 [1].chance == 2) {
					box3 [2].chance =3;
				}
				if (box3 [1].chance == 3) {
					box3 [2].chance =2;
				}
			}
		}
	}

}
