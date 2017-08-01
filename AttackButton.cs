using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour {

	public float damageDelay;

	private Animator anima;
	private PlayerMovement transformPlayer;

	void Start()
	{
		anima = GameObject.FindWithTag("Player").GetComponent<Animator>();
		transformPlayer = GameObject.FindWithTag("Player").GetComponent<PlayerMovement> ();
	}

	public void Attack()
	{
		
		transformPlayer.enabled = false;
		anima.SetTrigger ("attack");
		anima.SetBool ("walk", false);
	}
}