using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public Player playerScrip;
    public GameObject player;
    public Transform target;
    public BattleSystem battle;
    public GameObject batle;
    // Use this for initialization
    float speed=20;
    void Start () {
        GameObject player = GameObject.Find("FPSController");
        playerScrip = player.GetComponent<Player>();

        GameObject batl = GameObject.Find("battlesystem");
        battle = batl.GetComponent<BattleSystem>();

        GameObject tar = GameObject.FindGameObjectWithTag("Target");
        target = tar.transform;
        this.transform.LookAt(target);
    }
	
	// Update is called once per frame
	void Update () {
        float step = 10 * Time.deltaTime;
        transform.Translate(Vector3.forward*step);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            Destroy(this.gameObject);
            playerScrip.fireBall();
            battle.playerTurn = false;
        }
    }
}
