using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAnimOnStart : MonoBehaviour {

	public float mainFadeSpeed;
	public float secondaryFadeSpeed;

	public Transform player;
	public Animator _player;
	public Transform mainUi;
	public CanvasGroup _mainUi;
	public GameObject startUi;
	public CanvasGroup _startUi;
	public CanvasGroup _controls;

	private float lol;
	private bool cor = false;

	void Update()
	{
		if (cor == true) {
			lol = _mainUi.alpha;
		}
	}

	public void NewGame()
	{
		StartCoroutine ("PlayerAnim");
		StartCoroutine ("StartUiFadeOut");
		StartCoroutine ("MainUiFadeIn");
		StartCoroutine ("Controls");
	}

	IEnumerator PlayerAnim()
	{
		yield return new WaitForSeconds (0);
		_player.SetBool ("walk", true);
		while (player.position.x < -1.57f) {
			player.Translate (Vector3.right * Time.deltaTime * secondaryFadeSpeed);
			yield return null;
		}
		player.position = new Vector3 (-1.57f, player.position.y, player.position.z);
		_player.SetBool ("walk", false);
		StopCoroutine ("PlayerAnim");
	}

	IEnumerator StartUiFadeOut()
	{
		yield return new WaitForSeconds (0);
		_startUi.interactable = false;
		while (_startUi.alpha > 0) {
			_startUi.alpha -= Time.deltaTime * mainFadeSpeed;
			yield return null;
		}
		Destroy (startUi);
		StopCoroutine ("StartUiFadeOut");
	}

	IEnumerator MainUiFadeIn()
	{
		cor = true;
		yield return new WaitForSeconds (2.0f);
		while (_mainUi.alpha < 1) {
			_mainUi.alpha += Time.deltaTime * mainFadeSpeed;
			if (mainUi.localPosition.y < 0) {
				mainUi.localPosition += Vector3.up * Time.deltaTime * lol * 80;
			}
			yield return null;
		}
		_mainUi.interactable = true;
		cor = false;
		mainUi.localPosition = new Vector3 (0, 0, 0);
		StopCoroutine ("MainUiFadeIn");
	}

	IEnumerator Controls()
	{
		yield return new WaitForSeconds (2.0f);
		while (_controls.alpha < 1) {
			_controls.alpha += Time.deltaTime * mainFadeSpeed;
			yield return null;
		}
		_controls.interactable = true;
		StopCoroutine ("Controls");
	}
}
