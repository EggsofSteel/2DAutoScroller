using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackingScript : MonoBehaviour {

	public float maxTimeAttacks;
	public float minTimeAttacks;
	public float maxChanseOfAttack;
	public float minChanseOfAttack;
	public float enemyHealth;
	public float maxGold;
	public float minGold;
	public float maxExp;
	public float minExp;
	public string AttackName;
	public string AttackName_1;
	public bool inBattle;
	public bool destroyed;

	private Animator _anim;
	private Animator toIdle;
	private PlayerMovement playerMovement;
	private AnimationEventsGoHere onAttack;
	private StatsController statsController;
	private GameObject button;
	private GameObject travel;

	private float Delay;
	private float Chanse;

	void Start()
	{
		statsController = GameObject.FindWithTag("Manager").GetComponent<StatsController> ();
		destroyed = true;
		inBattle = false;
		travel = GameObject.Find ("ChangeLocation");
		toIdle = GameObject.FindWithTag ("Player").GetComponent<Animator>();
		playerMovement = GameObject.FindWithTag ("Player").GetComponent<PlayerMovement>();
		onAttack = GameObject.FindWithTag ("Player").GetComponent<AnimationEventsGoHere>();
		_anim = this.GetComponent<Animator> ();
	}

	void Update () 
	{
		Delay = Random.Range (minTimeAttacks, maxTimeAttacks);
		Chanse = Random.Range (minChanseOfAttack, maxChanseOfAttack);
		if (inBattle == true && button != null) 
		{
			button.gameObject.SetActive (false);
		}
		if (onAttack.curEnemyHp <= 0) 
		{
			travel.SetActive (true);
			Destroy (gameObject);
			button.gameObject.SetActive (true);
			statsController.goldAmount = statsController.goldAmount + Random.Range (minGold, maxGold);
			statsController.currentExp = statsController.currentExp + Random.Range (minExp, maxExp);
		}
	}

	public void StartTheAttack()
	{
		if(Chanse < ((minChanseOfAttack + maxChanseOfAttack) / 2))
			StartCoroutine (WaitBeforAttack ());
		if(Chanse > ((minChanseOfAttack + maxChanseOfAttack) / 2))
			StartCoroutine (WaitBeforAttack ());
	}

	IEnumerator WaitBeforAttack()
	{
		while (true)
		{
			yield return new WaitForSeconds (Delay);
			_anim.SetTrigger (AttackName);
		}
	}

	IEnumerator WaitBeforAttack_1()
	{
		while (true)
		{
			yield return new WaitForSeconds (Delay);
			_anim.SetTrigger (AttackName_1);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			inBattle = true;
			button = GameObject.Find ("RunButton");
			Invoke ("StartTheAttack", (Delay / 2));
			playerMovement.enabled = false;
			toIdle.SetBool ("walk", false);
			playerMovement.enabled = false;
		}
	}
}
