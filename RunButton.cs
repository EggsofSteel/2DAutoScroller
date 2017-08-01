using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RunButton : MonoBehaviour {

	private Animator anim;
	private PlayerMovement transformPlayer;

	void Start()
	{
		this.GetComponent<Button>().onClick.AddListener (TaskOnClick);
		anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
		transformPlayer = GameObject.FindWithTag ("Player").GetComponent<PlayerMovement> ();
	}

	public void TaskOnClick()
	{
		transformPlayer.enabled = !transformPlayer.enabled;
		if(transformPlayer.enabled == false)
			anim.SetBool ("walk", false);
	}
}
