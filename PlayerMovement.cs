using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float speed;

	private Animator anim;

	void Start ()
	{
		anim = this.GetComponent<Animator> ();
	}

	void Update() 
	{
		Camera.main.transform.Translate(Vector3.right * speed * Time.deltaTime);
		transform.Translate(Vector3.right * speed * Time.deltaTime);
		anim.SetBool ("walk", true);
	}
}
