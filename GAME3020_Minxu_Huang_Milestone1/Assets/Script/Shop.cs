using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public Player player;
    public bool elvenswordbuttons;
    public bool lightsaberbuttons;
    public bool hpbuttons;
    public bool mannabuttons;

    public int money = 0;

    public GameObject sword;
    public GameObject elvensword;
	public bool brought =false;
    public GameObject lightsaber;
	public bool brought2=false;
    public Text log;
	public Text inventlog;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        log.text = "Money: " + money;
		inventlog.text = "Money: " + money;

       
       
    }
    public void click()
    {
        elvenswordbuttons = true;
		if (!brought&&elvenswordbuttons && money >= 30)
        {
            sword.SetActive(false);
            elvensword.SetActive(true);
            lightsaber.SetActive(false);
            money -= 30;
			brought = true;
        }
		if (brought && elvenswordbuttons) {
			sword.SetActive (false);
			elvensword.SetActive (true);
			lightsaber.SetActive (false);
		}
    }
    public void swordclick()
    {
        lightsaberbuttons = true;
		if (!brought2&&lightsaberbuttons && money >= 70)
        {
            sword.SetActive(false);
            elvensword.SetActive(false);
            lightsaber.SetActive(true);
            money -= 70;
			brought2 = true;
        }
		if (brought2 && lightsaberbuttons) {
			sword.SetActive (false);
			elvensword.SetActive (false);
			lightsaber.SetActive (true);
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
