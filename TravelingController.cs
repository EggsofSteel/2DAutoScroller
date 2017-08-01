using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelingController : MonoBehaviour {

	public GameObject hideChanges;
	public GameObject player;
	public Button forestButton;
	public Button desertButton;
	public GameObject travel;
	public GameObject travelMenuSwitch;
	public GameObject[] locations;
	public GameObject[] enemies;
	public float fadeSpeed;

	private Animator anim;
	private AttackingScript attackingScript;
	private SpawnManagment targetEnemy;
	private PlayerMovement transformPlayer;
	private GameObject enemy;
	private GameObject currentLocation;
	private GameObject currentEnemies;
	private CanvasGroup canvasGroup;
	private bool Switch;


	void Start () 
	{
		Switch = false;
		canvasGroup = hideChanges.GetComponent<CanvasGroup> ();
		anim = player.GetComponent<Animator>();
		transformPlayer = player.GetComponent<PlayerMovement> ();
	
	}
	

	void Update () 
	{
		currentEnemies = GameObject.FindWithTag ("Spawner");

		if (currentEnemies != null) {
			targetEnemy = currentEnemies.GetComponent<SpawnManagment> ();
		}

		currentLocation = GameObject.FindWithTag ("Location");

		if (targetEnemy.spawnedEnemy != null) {
			enemy = GameObject.FindWithTag ("Enemies");
			attackingScript = enemy.GetComponent<AttackingScript> ();

			if (attackingScript.inBattle == true) {
				travel.SetActive (false);
			}
		}
	}

	public void Expand()
	{
		Switch = !Switch;
		travelMenuSwitch.SetActive (Switch);
	}

	public void ChangeToForest()
	{
		canvasGroup.blocksRaycasts = true;
		StartCoroutine (FadeInToForest ());
		travelMenuSwitch.SetActive (false);
		Switch = false;
		transformPlayer.enabled = true;
		anim.SetBool ("walk", true);
	}

	public void ChangeToDesert()
	{
		canvasGroup.blocksRaycasts = true;
		StartCoroutine (FadeInToDesert ());
		travelMenuSwitch.SetActive (false);
		Switch = false;
		transformPlayer.enabled = true;
		anim.SetBool ("walk", true);
	}

	void ToForest()
	{
		Destroy (currentLocation.gameObject);
		Destroy (currentEnemies.gameObject);
		Instantiate (locations [0]);
		Instantiate (enemies [0]);
		forestButton.interactable = false;
		desertButton.interactable = true;
		Camera.main.transform.position = new Vector3 (2.5f, -0.2f, -3);
		player.transform.position = new Vector3 (-1.57f, -2, -3);
	}

	void ToDesert()
	{
		Destroy (currentLocation.gameObject);
		Destroy (currentEnemies.gameObject);
		Instantiate (locations [1]);
		Instantiate (enemies [1]);
		forestButton.interactable = true;
		desertButton.interactable = false;
		Camera.main.transform.position = new Vector3 (2.5f, -0.2f, -3);
		player.transform.position = new Vector3 (-1.57f, -2, -3);
	}

	IEnumerator FadeOut()
	{
		yield return new WaitForSeconds (1.0f);
		while (canvasGroup.alpha > 0) {
			canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
			yield return null;
		}
		canvasGroup.blocksRaycasts = false;
	}

	IEnumerator FadeInToForest()
	{
		while (canvasGroup.alpha < 1) {
			canvasGroup.alpha += Time.deltaTime * fadeSpeed;
			yield return null;
		}
		if (canvasGroup.alpha >= 1.0f) {
			if (targetEnemy.spawnedEnemy != null) {
				Destroy (enemy);
			}
			transformPlayer.enabled = false;
			anim.SetBool ("walk", false);
			ToForest ();
			StartCoroutine (FadeOut());
		}
	}

	IEnumerator FadeInToDesert()
	{
		while (canvasGroup.alpha < 1) {
			canvasGroup.alpha += Time.deltaTime * fadeSpeed;
			yield return null;
		}
		if (canvasGroup.alpha >= 1.0f) {
			if (targetEnemy.spawnedEnemy != null) {
				Destroy (enemy);
			}
			transformPlayer.enabled = false;
			anim.SetBool ("walk", false);
			ToDesert ();
			StartCoroutine (FadeOut());
		}
	}
}
