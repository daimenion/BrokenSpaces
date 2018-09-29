using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
public class Player : MonoBehaviour {
	public FirstPersonController firstPerson;

	public Enemy enemy;

	public GameObject battleCanvas;
	//hp
	public Slider hpBar;
	public Slider manaBar;
	private float sliderHp;
	public  float currentHealth = 20;
	private float maxHealth = 20;
	public float currentMana= 10;
	private float maxMana=10;

	public float strength = 2;
	public float magicPower= 1;
	public float defends=2; 

	// Use this for initialization
	void Start () {
		currentHealth = 20;
		currentMana= 10;
	}
	
	// Update is called once per frame
	void Update () {
		
		hpBar.maxValue = maxHealth;
		hpBar.value = currentHealth;
		manaBar.value = currentMana;
		manaBar.maxValue = maxMana;
		
	}
	public void dealDmg(float damage){
		currentHealth -= damage;
		if (currentHealth<=0) {
			//daelth scren;
		}
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {
			firstPerson.m_WalkSpeed = (0);
			firstPerson.m_JumpSpeed = (0);
			firstPerson.m_MouseLook.lockCursor = false;
			Cursor.visible = true;
			Screen.lockCursor = false;
			firstPerson.enabled = false;
			battleCanvas.SetActive(true);
		}
	
	}
	public void reSet(){
		firstPerson.m_WalkSpeed = (5);
		firstPerson.m_JumpSpeed = (10);
		firstPerson.m_MouseLook.lockCursor = true;
		Cursor.visible = false;
		Screen.lockCursor = true;
		firstPerson.enabled = true;
		battleCanvas.SetActive(false);


	}
	public void attack(){
		enemy.dealDmg (1+strength);
	}
	public void fireBall(){
		if (currentMana > 0) {
			enemy.dealDmg (4+magicPower);
				currentMana -= 2;
		}

	}
	public void increaseStrength(){
		if (currentMana > 0) {
			strength += magicPower;
			currentMana -= 1;
		}
	}
	public void levelUp(){
		strength += 2;
		magicPower += 2;
		defends += 2;
		maxHealth += 5;
		maxMana += 5;
	}
}
