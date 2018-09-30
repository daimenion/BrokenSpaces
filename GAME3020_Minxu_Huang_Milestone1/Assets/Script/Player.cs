using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
public class Player : MonoBehaviour {
	public FirstPersonController firstPerson;
	public Enemy[] enemy;
	public int enemies = 0;
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
		manaBar.maxValue = maxMana;
		hpBar.maxValue = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		

		hpBar.value = currentHealth;

		manaBar.value = currentMana;
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
		enemy[enemies].dealDmg (1+strength);
	}
	public void fireBall(){
		if (currentMana > 0) {
			enemy[enemies].dealDmg (4+magicPower);
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
	}
}
