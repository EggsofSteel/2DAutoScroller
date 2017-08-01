using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BlockButton : MonoBehaviour {

	private Animator anim;
	private PlayerMovement transformPlayer;

	void Start()
	{
		anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
		transformPlayer = GameObject.FindWithTag ("Player").GetComponent<PlayerMovement> ();
	}

		
	public void Blocking()
	{
		transformPlayer.enabled = false;
		anim.SetBool ("walk", false);
		anim.SetTrigger ("block");
		anim.SetBool ("isHolding", true);
	}

	public void StopBlocking()
	{
		anim.SetBool ("isHolding", false);
	}
}