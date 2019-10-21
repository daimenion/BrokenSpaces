using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour {
	public Player player;
	public Shop shp;
	public Canvas inven;
	public GameObject sword;
	public GameObject elvensword;
	public GameObject lightsaber;
	public bool swo;
	public bool elvenswo;
	public bool lightsa;
	bool equip;
	bool pressed;
	public Text mana;
	public Text heath;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I) && !pressed&&!player.inbattle) {
			inven.gameObject.SetActive (true);
			player.encounter ();
			pressed = true;
		} else if (Input.GetKeyDown (KeyCode.I) && pressed &&!player.inbattle) {
			inven.gameObject.SetActive (false);
			player.reSet ();
			pressed = false;
		}
		heath.text = ": " + player.hpPotions;
		mana.text = ": " + player.manaPotions;

	}
	public void swoclick(){
		swo = true;
		elvenswo = false;
		lightsa = false;
		sword.SetActive (true);
		elvensword.SetActive (false);
		lightsaber.SetActive (false);
		equip = true;

	}
		public void swclick(){
		if (shp.brought) {
			sword.SetActive (false);
			elvensword.SetActive (true);
			lightsaber.SetActive (false);
			swo = false;
			elvenswo = true;
			lightsa = false;
			equip = true;

		}

	}
		public void sclick(){
		if (shp.brought2) {
			sword.SetActive (false);
			elvensword.SetActive (false);
			lightsaber.SetActive (true);
			swo = false;
			elvenswo = false;
			lightsa = true;
			equip = true;
		}

	}
}
