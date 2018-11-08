using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public Player player;
    public Canvas canvas;
    public bool elvenswordbuttons;
    public bool lightsaberbuttons;
    public bool hpbuttons;
    public bool mannabuttons;

    public int money = 0;

    public GameObject sword;
    public GameObject elvensword;
    public GameObject lightsaber;

    public Text log;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        log.text = "Money: " + money;


       
       
    }
    public void click()
    {
        elvenswordbuttons = true;
        if (elvenswordbuttons && money >= 30)
        {
            sword.SetActive(false);
            elvensword.SetActive(true);
            lightsaber.SetActive(false);
            money -= 30;
            player.maxStrength += 4;
        }
    }
    public void swordclick()
    {
        lightsaberbuttons = true;
        if (lightsaberbuttons && money >= 70)
        {
            sword.SetActive(false);
            elvensword.SetActive(false);
            lightsaber.SetActive(true);
            money -= 70;
            player.maxStrength += 10;
        }
    }
    public void hpclick()
    {
        hpbuttons = true;
        if (hpbuttons && money >= 5)
        {
            player.hpPotions += 1;
            money -= 5;
        }
    }
    public void manaclick()
    {
        mannabuttons = true;
        if (mannabuttons && money >= 5)
        {
            player.manaPotions += 1;
            money -= 5;
        }
    }
}
