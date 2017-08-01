using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationEventsGoHere : MonoBehaviour {

	public float maxEnemyHp;
	public float enemyBarRatio;

	public float curEnemyHp;

	public float maxHealth;
	public float health;
	public float heroBarRatio;

	public float amountOfDamage;

	public Text curHeroHp;
	public Image heroHpBar;
	public GameObject heroBar;

	public Text _curEnemyHp;
	public Text _maxEnemyHp;
	public Image _EnemyBar;
	public GameObject EnemyBar;
	public GameObject EnemyHpTxt;
	public float scaleSpeed;


	private bool Blocking;
	private bool stopped;		//Stop bar starting animation.

	private EnemiesDamageAnimsHolder enemiesDamage;
	private AttackingScript attackingScript;
	private AttackButton attackButton;
	private SpawnManagment targetEnemy;


	void Update () 
	{
		targetEnemy = GameObject.FindWithTag ("Spawner").GetComponent<SpawnManagment> ();

		if (targetEnemy.spawnedEnemy != null) 
		{
			attackingScript = GameObject.FindWithTag ("Enemies").GetComponent<AttackingScript> ();
			enemiesDamage = GameObject.FindWithTag ("Enemies").GetComponent<EnemiesDamageAnimsHolder> ();
		}

		HeroHpCalc();
		EnemyHpCalc();

	}

	void DamageCheck()
	{
		if (targetEnemy.spawnedEnemy != null && attackingScript.inBattle == true) 
		{
			curEnemyHp = curEnemyHp - amountOfDamage;
		}
	}

	void BlockIn()
	{
		if (targetEnemy.spawnedEnemy != null && attackingScript.inBattle == true) 
		{
			enemiesDamage.DamageDealt = 0;
		}
	}

	void BlockOut()
	{
		if (targetEnemy.spawnedEnemy != null && attackingScript.inBattle == true) 
		{
			enemiesDamage.DamageDealt = enemiesDamage.DamageDealtHolder;
		}
	}

	IEnumerator ScaleBar()
	{
		while (_EnemyBar.transform.localScale.x < 1) {
			_EnemyBar.transform.localScale += transform.right * Time.deltaTime * scaleSpeed;
			yield return null;
		}
		stopped = true;
	}

	void HeroHpCalc()
	{
		heroBarRatio = health / maxHealth;

		if (health < 0.01f) 
			{
				heroBarRatio = 0;
				health = 0;
			}

		heroHpBar.rectTransform.localScale = new Vector3 (1, heroBarRatio, 1);
		curHeroHp.text = (heroBarRatio * 100).ToString ("0");
	}

	void EnemyHpCalc()
	{
		
		if (targetEnemy.spawnedEnemy != null && attackingScript.inBattle == true) 
		{
			EnemyBar.SetActive (true);

			enemyBarRatio = curEnemyHp / maxEnemyHp;
			if (curEnemyHp < 0.01f) 
			{
				enemyBarRatio = 0;
				curEnemyHp = 0;
			}

			if (stopped == false) {
				StartCoroutine (ScaleBar ());
			}

			if (stopped == true) {
				StopCoroutine (ScaleBar ());
				EnemyHpTxt.SetActive (true);
				_EnemyBar.rectTransform.localScale = new Vector3 (enemyBarRatio, 1, 1);
				_curEnemyHp.text = (curEnemyHp * 100).ToString ("0");
				_maxEnemyHp.text = (maxEnemyHp * 100).ToString ("0");
			}
		}

		if (targetEnemy.spawnedEnemy == null) {
			EnemyHpTxt.SetActive (false);
			curEnemyHp = maxEnemyHp;
			stopped = false;
		}
	}
}
