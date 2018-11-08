using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {
	public FirstPersonController firstPerson;
	public Enemy[] enemy;
	public int enemies = 0;
	public GameObject battleCanvas;
    public Animator shop;
    public Canvas shopcan;
	//hp
	public Slider hpBar;
	public Slider manaBar;
	private float sliderHp;
	public  float currentHealth = 20;
	private float maxHealth = 20;
	public float currentMana= 10;
	private float maxMana=10;

	public float strength;
    public float maxStrength=2;
	public float magicPower= 1;
	public float defends=2; 


	public int hpPotions = 2;
	public int manaPotions = 2;
    public int lvl=1;

	public BattleSystem battle;

	public Text log;
	public Text mana;
	public Text HP;

	int scene;
	// Use this for initialization
	void Start () {
		currentHealth = 20;
		currentMana= 10;

	}
	
	// Update is called once per frame
	void Update () {
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
	}
	public void dealDmg(float damage){
		currentHealth -= damage;
		log.text = "player take : " + damage+" damage";
		if (currentHealth<=0) {
			//daelth scren;
		}
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {

            encounter();
			battleCanvas.SetActive(true);
			battle.playerTurn = true;
			log.text= "Encounter enemy!!";
		}
        else if (other.tag == "Shop")
        {
            shop.Play("shopanim");
            log.text = "Welcome to the shop.";
            shopcan.gameObject.SetActive(true);
            encounter();
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
		enemy[enemies].dealDmg (1+strength);
		float dmg = 1 + strength;
		log.text = "Player attack and deals " + dmg +" to enemy";
	}
	public void fireBall(){
		if (currentMana > 0) {
			enemy[enemies].dealDmg (4+magicPower);
			float dmg = 4 + magicPower;
			log.text = "Player uses fire ball and deals " + dmg +" to enemy";
				currentMana -= 2;
		} else {
			log.text = "not enough mana";
		}

	}
	public void increaseStrength(){
		if (currentMana > 0) {
			strength += magicPower;
			log.text = "Player strength increase by " + magicPower;
			currentMana -= 1;
		} else {
			log.text = "not enough mana";
		}
	}
	public void levelUp(){
		maxStrength += 2;
		magicPower += 2;
		defends += 2;
        maxHealth += 5;
        currentHealth += 5;
        maxMana += 3;
        currentMana += 3;
        lvl++;
	}
	public void drinkHPPotion(){
		if (hpPotions > 0) {
			currentHealth += 5;
			log.text = "Player used hp potion and heals " + 5 + " hp";
			hpPotions--;
		} else if (hpPotions <= 0) {
			log.text= "No more hp potion ";
		}
	}
	public void drinkManaPotion(){
		if (manaPotions > 0) {
			currentMana += 5;
			log.text="Player used mana potion and heals " + 5+" mana";
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
}
